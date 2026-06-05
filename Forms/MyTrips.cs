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
using System.Net.Http.Json;
using System.Windows.Forms;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class MyTrips : Form
    {
        private readonly ApiService _apiService;
        public MyTrips()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }
        private async void MyTripsForm_Load(object sender, EventArgs e)
        {
             LoadStatuses();
            await LoadDestinations();   
            await LoadTrips();
        }
        private async Task LoadTrips()
        {
            var trips =
                await _apiService.GetAsync<List<TripDto>>("trips");

            dataGridViewTrips.DataSource = trips;

            dataGridViewTrips.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (!dataGridViewTrips.Columns.Contains("View"))
            {
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.Name = "View";
                viewBtn.HeaderText = "View";
                viewBtn.Text = "Details";
                viewBtn.UseColumnTextForButtonValue = true;
                dataGridViewTrips.Columns.Add(viewBtn);

                DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn();
                editBtn.Name = "Edit";
                editBtn.HeaderText = "Edit";
                editBtn.Text = "Edit";
                editBtn.UseColumnTextForButtonValue = true;
                dataGridViewTrips.Columns.Add(editBtn);

                DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn();
                deleteBtn.Name = "Delete";
                deleteBtn.HeaderText = "Delete";
                deleteBtn.Text = "Delete";
                deleteBtn.UseColumnTextForButtonValue = true;
                dataGridViewTrips.Columns.Add(deleteBtn);
            }

        }
        private async Task LoadDestinations()
        {
            var response =
                await _apiService.GetAsync<PagedResponseDto<DestinationDto>>(
                    "destinations?page=1&pageSize=100");

            var destinations = response?.Data ?? new List<DestinationDto>();

            cmbDestination.DataSource = destinations;
            cmbDestination.DisplayMember = "Name";
            cmbDestination.ValueMember = "Id";

            cmbDestination.SelectedIndex = -1;
        }
        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Planned");
            cmbStatus.Items.Add("In Progress");
            cmbStatus.Items.Add("Completed");
            cmbStatus.Items.Add("Cancelled");

            cmbStatus.SelectedIndex = -1;
        }
        private async void btnCreateTrip_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Please fill in all fields.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime startDate = DateTime.Parse(cmbStartDate.Text.ToString());
            DateTime endDate = DateTime.Parse(cmbEndDate.Text.ToString());

            var newTrip = new TripDto
            {
                Title = txtTitle.Text.Trim(),
                Destination = cmbDestination.Text.Trim(),
                StartDate = startDate,
                EndDate = endDate,
                Status = cmbStatus.SelectedIndex
            };

            await _apiService.PostAsync("trips", newTrip);

            MessageBox.Show("Trip created successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            await LoadTrips();

            txtTitle.Clear();
            cmbDestination.SelectedIndex = -1;
            cmbStartDate.SelectedIndex = -1;
            cmbEndDate.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
        }

        bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(cmbDestination.Text) ||
                string.IsNullOrWhiteSpace(cmbStartDate.Text) ||
                string.IsNullOrWhiteSpace(cmbEndDate.Text) ||
                string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                return false;
            }
            if (txtTitle.Text.Length < 5 || txtTitle.Text.Length > 100)
            {
                MessageBox.Show("Title must be between 5 and 100 characters.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateTime.TryParse(cmbStartDate.Text, out DateTime startDate) ||
        !DateTime.TryParse(cmbEndDate.Text, out DateTime endDate))
            {
                MessageBox.Show(
                    "Please select valid dates.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (startDate > endDate)
            {
                MessageBox.Show(
                    "End date must be after start date.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private async void dataGridViewTrips_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            TripDto trip =
                (TripDto)dataGridViewTrips.Rows[e.RowIndex].DataBoundItem;

            string columnName =
                dataGridViewTrips.Columns[e.ColumnIndex].Name;

            if (columnName == "View")
            {
                MessageBox.Show(
                    $"Title: {trip.Title}\n" +
                    $"Destination: {trip.Destination}\n" +
                    $"Start: {trip.StartDate:d}\n" +
                    $"End: {trip.EndDate:d}\n" +
                    $"Status: {trip.Status}",
                    "Trip Details");
            }
            else if (columnName == "Edit")
            {
                txtTitle.Text = trip.Title;
                cmbDestination.Text = trip.Destination;
                cmbStartDate.Text = trip.StartDate.ToShortDateString();
                cmbEndDate.Text = trip.EndDate.ToShortDateString();
                cmbStatus.Text = trip.Status.ToString();

                // Store trip.Id somewhere for Update operation
            }
            else if (columnName == "Delete")
            {
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this trip?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    await _apiService.DeleteAsync($"trips/{trip.Id}");
                    await LoadTrips();

                    MessageBox.Show("Trip deleted successfully.");
                }
            }

        }
    }
}
