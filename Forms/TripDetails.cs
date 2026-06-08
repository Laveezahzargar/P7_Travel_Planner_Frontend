using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class TripDetails : Form
    {
        private readonly ApiService _apiService;
        private readonly int _tripId;
        private int _selectedDayId = 0;
        public TripDetails(ApiService apiService, int tripId)
        {
            InitializeComponent();
            _apiService = apiService;
            _tripId = tripId;
        }
        private void dataGridViewDays_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var day = (DayDto)dataGridViewDays.Rows[e.RowIndex].DataBoundItem;

            _selectedDayId = day.Id;

            dtpDate.Value = day.Date;
            numDayNumber.Value = day.DayNumber;
            txtNotes.Text = day.Notes;
        }
        private async Task LoadTripInfo()
        {
            var trip = await _apiService.GetAsync<TripDto>($"trips/{_tripId}");

            lblTitle.Text = trip.Title;
            lblDestination.Text = trip.Destination;
            lblStartDate.Text = $"{trip.StartDate:d}";
            lblEndDate.Text = $"{trip.EndDate:d}";
            lblStatus.Text = trip.Status.ToString();
        }
        private async Task LoadDays(int tripId)
        {
            var days = await _apiService.GetAsync<List<DayDto>>(
                $"trips/{tripId}/days"
            );

            dataGridViewDays.DataSource = days;

            AddActionButtons();
        }
        private void AddActionButtons()
        {
            if (dataGridViewDays.Columns["Edit"] == null)
            {
                var editBtn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    Text = "Edit",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewDays.Columns.Add(editBtn);
            }

            if (dataGridViewDays.Columns["Delete"] == null)
            {
                var deleteBtn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewDays.Columns.Add(deleteBtn);
            }
        }
        private async void btnAddDay_Click(object sender, EventArgs e)
        {
            var day = new DayDto
            {
                Id = _selectedDayId,
                TripId = _tripId,
                Date = dtpDate.Value,
                Destination = lblDestination.Text,
                DayNumber = (int)numDayNumber.Value,
                Notes = txtNotes.Text
            };

            if (_selectedDayId == 0)
            {
                // ADD
                await _apiService.PostAsync($"trips/{_tripId}/days", day);
            }
            else
            {
                // UPDATE
                await _apiService.PutAsync($"days/{_selectedDayId}", day);
            }

            _selectedDayId = 0;
            ClearForm();
            await LoadDays(_tripId);
        }
        private async void btnDeleteDay_Click(object sender, EventArgs e)
        {
            if (dataGridViewDays.CurrentRow == null) return;

            var selected = (DayDto)dataGridViewDays.CurrentRow.DataBoundItem;

            await _apiService.DeleteAsync(
                $"days/{selected.Id}"
            );

            await LoadDays(_tripId);
        }
        private void ClearForm()
        {
            dtpDate.Value = DateTime.Now;
            numDayNumber.Value = 1;
            txtNotes.Clear();
        }
        private async void dataGridViewDays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var day = (DayDto)dataGridViewDays.Rows[e.RowIndex].DataBoundItem;

            if (dataGridViewDays.Columns[e.ColumnIndex].Name == "Edit")
            {
                _selectedDayId = day.Id;

                dtpDate.Value = day.Date;
                numDayNumber.Value = day.DayNumber;
                txtNotes.Text = day.Notes;
            }
            else if (dataGridViewDays.Columns[e.ColumnIndex].Name == "Delete")
            {
                await _apiService.DeleteAsync($"days/{day.Id}");
                await LoadDays(_tripId);
            }
        }

        private async void TripDetails_Load(object sender, EventArgs e)
        {
            await LoadTripInfo();
            await LoadDays(_tripId);
        }
    }
}
