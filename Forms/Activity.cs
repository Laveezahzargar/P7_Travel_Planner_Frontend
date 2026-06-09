using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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
            await LoadActivities();
        }

        private async Task LoadActivities()
        {
            var activities =
                await _apiService.GetAsync<List<ActivityDto>>
                ($"days/{_dayId}/activities");

            dataGridViewActivity.DataSource = activities;
        }
        private async void btnAdd_Click(
    object sender,
    EventArgs e)
        {
            var activity = new ActivityDto
            {
                Name = txtName.Text,
                Location = txtLocation.Text,
                Cost = numCost.Value,
                StartTime = dtpStart.Value,
                EndTime = dtpEnd.Value
            };

            await _apiService.PostAsync(
                $"days/{_dayId}/activities",
                activity);

            await LoadActivities();
        }
        private async void btnDelete_Click(
    object sender,
    EventArgs e)
        {
            if (_selectedActivityId == 0)
                return;

            await _apiService.DeleteAsync(
                $"activities/{_selectedActivityId}");

            await LoadActivities();
        }
        private void dataGridViewActivities_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var activity =
                (ActivityDto)dataGridViewActivity
                    .Rows[e.RowIndex]
                    .DataBoundItem;

            _selectedActivityId = activity.Id;

            txtName.Text = activity.Name;
            txtLocation.Text = activity.Location;
            numCost.Value = activity.Cost;
            dtpStart.Value = activity.StartTime;
            dtpEnd.Value = activity.EndTime;
        }
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }
    }
}
