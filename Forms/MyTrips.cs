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
        private int? _editingTripId = null;
        public MyTrips()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }
        private async void MyTripsForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadStatuses();
                ConfigureGrid();
                await LoadDestinations();
                await LoadTrips();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigureGrid()
        {
            if (dataGridViewTrips.Columns.Count > 0)
                return;

            DataGridViewButtonColumn viewBtn = new()
            {
                Name = "View",
                HeaderText = "View",
                Text = "Details",
                UseColumnTextForButtonValue = true
            };

            DataGridViewButtonColumn editBtn = new()
            {
                Name = "Edit",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };

            DataGridViewButtonColumn deleteBtn = new()
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };

            dataGridViewTrips.Columns.Add(viewBtn);
            dataGridViewTrips.Columns.Add(editBtn);
            dataGridViewTrips.Columns.Add(deleteBtn);

        }
        private async Task LoadTrips()
        {
            try
            {
                var trips =
                    await _apiService.GetAsync<List<TripDto>>("trips") ?? new List<TripDto>();

                dataGridViewTrips.DataSource = null;
                dataGridViewTrips.DataSource = trips;

                dataGridViewTrips.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load trips.\n{ex.Message}", "Error");
            }

        }
        private async Task LoadDestinations()
        {
            try
            {
                var response =
                    await _apiService.GetAsync<PagedResponseDto<DestinationDto>>(
                        "destinations?page=1&pageSize=100");

                var destinations = response?.Data ?? new List<DestinationDto>() ?? new List<DestinationDto>();

                cmbDestination.DataSource = destinations;
                cmbDestination.DisplayMember = "Name";
                cmbDestination.ValueMember = "Id";
                cmbDestination.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load destinations.\n{ex.Message}", "Error");
            }
        }
        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.AddRange(new[]
            {
                "Planned",
                "In Progress",
                "Completed",
                "Cancelled"
            });

            cmbStatus.SelectedIndex = -1;
        }
        private async void btnCreateTrip_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            try
            {

                var trip = new TripDto
                {
                    Id = _editingTripId ?? 0,
                    Title = txtTitle.Text.Trim(),
                    DestinationId = (int)cmbDestination.SelectedValue,
                    Destination = cmbDestination.Text.Trim(),
                    StartDate = StartDate.Value,
                    EndDate = EndDate.Value,
                    Status = cmbStatus.SelectedIndex
                };
                if (_editingTripId.HasValue)
                {
                    await _apiService.PutAsync($"trips/{_editingTripId}", trip);
                    MessageBox.Show("Trip updated successfully.", "Success");
                }
                else
                {
                    var response = await _apiService.PostAsync("trips", trip);

                    var error = await response.Content.ReadAsStringAsync();

                    MessageBox.Show(error);

                    MessageBox.Show("Trip created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                ResetForm();
                await LoadTrips();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Enter a title.");
                return false;
            }

            if (txtTitle.Text.Length < 5 || txtTitle.Text.Length > 100)
            {
                MessageBox.Show("Title must be between 5 and 100 characters.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbDestination.SelectedIndex == -1)
            {
                MessageBox.Show("Select a destination.");
                return false;
            }
            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Select a status.");
                return false;
            }

            if (StartDate.Value.Date >= EndDate.Value.Date)
            {
                MessageBox.Show("End date must be after start date.");
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            txtTitle.Clear();

            cmbDestination.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;

            StartDate.Value = DateTime.Today;
            EndDate.Value = DateTime.Today;

            _editingTripId = null;

            btnCreateTrip.Text = "Create Trip";

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
                _editingTripId = trip.Id;
                txtTitle.Text = trip.Title;
                cmbDestination.SelectedIndex = cmbDestination.FindStringExact(trip.Destination);
                cmbStatus.SelectedIndex = trip.Status;
                StartDate.Value = trip.StartDate;
                EndDate.Value = trip.EndDate;
                btnCreateTrip.Text = "Update Trip";

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
                    try
                    {


                        await _apiService.DeleteAsync($"trips/{trip.Id}");
                        await LoadTrips();

                        MessageBox.Show("Trip deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete trip.\n{ex.Message}", "Error");
                    }
                }

            }
        }
    }
}
