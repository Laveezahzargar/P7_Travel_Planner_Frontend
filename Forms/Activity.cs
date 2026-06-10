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

            Log.Information(
                "Loaded {Count} activities for DayId {DayId}",
                activities?.Count ?? 0,
                _dayId);
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

                await _apiService.PostAsync(
                    $"days/{_dayId}/activities",
                    activity);

                Log.Information(
                    "Activity added for DayId {DayId}. Name={ActivityName}",
                    _dayId,
                    activity.Name);

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

        private void dataGridViewActivities_CellClick(
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

                _selectedActivityId = activity.Id;

                txtName.Text = activity.Name;
                txtLocation.Text = activity.Location;
                numCost.Value = activity.Cost;

                dtpStart.Value =
                    DateTime.Today.Add(activity.StartTime);

                dtpEnd.Value =
                    DateTime.Today.Add(activity.EndTime);

                Log.Information(
                    "Selected ActivityId {ActivityId}",
                    activity.Id);
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to select activity");

                MessageBox.Show(
                    "Failed to load activity details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
        }
    }
}