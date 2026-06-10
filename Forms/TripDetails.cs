using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;
using Serilog;

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
            if (dataGridViewDays.Columns["Activities"] == null)
            {
                var activityBtn = new DataGridViewButtonColumn
                {
                    Name = "Activities",
                    Text = "Activities",
                    UseColumnTextForButtonValue = true
                };

                dataGridViewDays.Columns.Add(activityBtn);
            }

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
            try
            {
                if (dtpDate.Value < DateTime.Parse(lblStartDate.Text) ||
                    dtpDate.Value > DateTime.Parse(lblEndDate.Text))
                {
                    MessageBox.Show(
                        "The date is outside the trip dates.",
                        "Invalid Date",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

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
                    await _apiService.PostAsync($"trips/{_tripId}/days", day);
                    Log.Information("Day added to TripId {TripId}", _tripId);
                }
                else
                {
                    await _apiService.PutAsync($"days/{_selectedDayId}", day);
                    Log.Information("Day {DayId} updated", _selectedDayId);
                }

                _selectedDayId = 0;
                ClearForm();
                await LoadDays(_tripId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error saving day for TripId {TripId}", _tripId);

                MessageBox.Show(
                    "Unable to save day information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private async void btnDeleteDay_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDays.CurrentRow == null)
                    return;

                var result = MessageBox.Show(
                            "Are you sure you want to delete this day?",
                            "Confirm Delete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                var selected = (DayDto)dataGridViewDays.CurrentRow.DataBoundItem;

                await _apiService.DeleteAsync($"days/{selected.Id}");

                Log.Information("Day {DayId} deleted", selected.Id);

                await LoadDays(_tripId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to delete day");

                MessageBox.Show(
                    "Unable to delete day.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            dtpDate.Value = DateTime.Now;
            numDayNumber.Value = 1;
            txtNotes.Clear();
        }
        private async void dataGridViewDays_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                else if (dataGridViewDays.Columns[e.ColumnIndex].Name == "Activities")
                {
                    using var activity = new Activity(_apiService, day.Id);
                    activity.ShowDialog();
                }
                else if (dataGridViewDays.Columns[e.ColumnIndex].Name == "Delete")
                {
                    await _apiService.DeleteAsync($"days/{day.Id}");

                    Log.Information("Day {DayId} deleted", day.Id);

                    await LoadDays(_tripId);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error processing grid action");

                MessageBox.Show(
                    "Operation failed.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void TripDetails_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadTripInfo();
                await LoadDays(_tripId);

                dtpDate.Value = DateTime.Parse(lblStartDate.Text);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load trip details for TripId {TripId}", _tripId);

                MessageBox.Show(
                    "Failed to load trip information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
