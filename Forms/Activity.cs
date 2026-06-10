using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;
using Serilog;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class Activity : Form
    {
        private readonly ApiService _apiService;
        private readonly int _dayId;
        private int _selectedActivityId = 0;

        public Activity(ApiService apiService, int dayId)
        {
            InitializeComponent();

            _apiService = apiService;
            _dayId = dayId;

            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "hh:mm tt";
            dtpStart.ShowUpDown = true;

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "hh:mm tt";
            dtpEnd.ShowUpDown = true;

            numCost.Minimum = 0;
            numCost.Maximum = 100000;
            numCost.DecimalPlaces = 2;
        }

        private async void ActivityForm_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                await LoadActivities();

                Log.Information(
                    "Activity form loaded for DayId {DayId}",
                    _dayId);
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to load activities for DayId {DayId}",
                    _dayId);

                MessageBox.Show(
                    "Failed to load activities.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadActivities()
        {
            var activities =
                await _apiService.GetAsync<List<ActivityDto>>(
                    $"days/{_dayId}/activities");

            dataGridViewActivity.DataSource = activities;

            dataGridViewActivity.Columns["StartTime"].DefaultCellStyle.Format = @"hh\:mm";
            dataGridViewActivity.Columns["EndTime"].DefaultCellStyle.Format = @"hh\:mm";

            Log.Information(
                "Loaded {Count} activities for DayId {DayId}",
                activities?.Count ?? 0,
                _dayId);

            AddActionButtons();
        }

        private void AddActionButtons()
        {
            if (dataGridViewActivity.Columns["Edit"] == null)
            {
                dataGridViewActivity.Columns.Add(
                    new DataGridViewButtonColumn
                    {
                        Name = "Edit",
                        Text = "Edit",
                        UseColumnTextForButtonValue = true
                    });
            }

            if (dataGridViewActivity.Columns["Delete"] == null)
            {
                dataGridViewActivity.Columns.Add(
                    new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    });
            }
        }

        private async void btnAdd_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show(
                        "Please enter an activity name.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (dtpEnd.Value <= dtpStart.Value)
                {
                    MessageBox.Show(
                        "End time must be after start time.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                var activity = new ActivityDto
                {
                    Name = txtName.Text.Trim(),
                    Location = txtLocation.Text.Trim(),
                    Cost = numCost.Value,
                    StartTime = dtpStart.Value.TimeOfDay,
                    EndTime = dtpEnd.Value.TimeOfDay
                };

                if (_selectedActivityId == 0)
                {
                    await _apiService.PostAsync(
                        $"days/{_dayId}/activities",
                        activity);

                    Log.Information(
                        "Activity created: {Name}",
                        activity.Name);
                }
                else
                {
                    activity.Id = _selectedActivityId;

                    await _apiService.PutAsync(
                        $"activities/{_selectedActivityId}",
                        activity);

                    Log.Information(
                        "Activity updated: {Id}",
                        _selectedActivityId);
                }

                ClearForm();

                await LoadActivities();
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to add activity for DayId {DayId}",
                    _dayId);

                MessageBox.Show(
                    "Failed to add activity.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (_selectedActivityId == 0)
                    return;

                await _apiService.DeleteAsync(
                    $"activities/{_selectedActivityId}");

                Log.Information(
                    "Activity deleted. ActivityId={ActivityId}",
                    _selectedActivityId);

                _selectedActivityId = 0;

                ClearForm();

                await LoadActivities();
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to delete activity");

                MessageBox.Show(
                    "Failed to delete activity.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async void dataGridViewActivity_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var activity =
                    (ActivityDto)dataGridViewActivity
                    .Rows[e.RowIndex]
                    .DataBoundItem;

                string column =
                    dataGridViewActivity.Columns[e.ColumnIndex].Name;

                if (column == "Edit")
                {
                    _selectedActivityId = activity.Id;

                    txtName.Text = activity.Name;
                    txtLocation.Text = activity.Location;
                    numCost.Value = activity.Cost;

                    dtpStart.Value =
                        DateTime.Today.Add(activity.StartTime);

                    dtpEnd.Value =
                        DateTime.Today.Add(activity.EndTime);

                    btnAdd.Text = "Update";
                }
                else if (column == "Delete")
                {
                    var result = MessageBox.Show(
                        "Delete this activity?",
                        "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result != DialogResult.Yes)
                        return;

                    await _apiService.DeleteAsync(
                        $"activities/{activity.Id}");

                    await LoadActivities();

                    Log.Information(
                        "Activity deleted: {Id}",
                        activity.Id);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex,
                    "Activity grid operation failed");
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtLocation.Clear();

            numCost.Value = 0;

            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;

            _selectedActivityId = 0;

            btnAdd.Text = "Add Activity";
        }
    }
}