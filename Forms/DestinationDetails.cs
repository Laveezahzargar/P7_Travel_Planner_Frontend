using P7_Travel_Planner_Frontend.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P7_Travel_Planner_Frontend.Services;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class DestinationDetails : Form
    {
        private readonly ApiService _apiservice;
        private readonly int _destinationId;
        public DestinationDetails(DestinationDto destination, ApiService apiservice)
        {
            InitializeComponent();

            lblName.Text = destination.Name;
            lblCountry.Text = destination.Country;
            lblDescription.Text = destination.Description;
            _destinationId = destination.Id;
            _apiservice = apiservice;
        }
        private void dataGridViewPlaces_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridViewPlaces.Columns[e.ColumnIndex].Name == "View")
            {
                PlaceDto place =
                    (PlaceDto)dataGridViewPlaces
                    .Rows[e.RowIndex]
                    .DataBoundItem;

                //PlaceDetails form =
                //    new PlaceDetails(place);

                // form.ShowDialog();
            }
        }
        private async void DestinationDetails_Load(object sender, EventArgs e)
        {
            await LoadPlaces();

            if (!dataGridViewPlaces.Columns.Contains("View Weather"))
            {
                DataGridViewButtonColumn btn =
                    new DataGridViewButtonColumn();

                btn.Name = "View Weather";
                btn.HeaderText = "View Weather";
                btn.Text = "View Weather";
                btn.UseColumnTextForButtonValue = true;

                dataGridViewPlaces.Columns.Add(btn);
            }
        }
        async Task LoadPlaces()
        {
            try
            {
                var places = await _apiservice.GetAsync<List<PlaceDto>>($"places/{_destinationId}");
                dataGridViewPlaces.DataSource = places;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading places: " + ex.Message);
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
