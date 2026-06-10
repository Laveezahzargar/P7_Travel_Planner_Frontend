using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;
using Serilog;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class DestinationDetails : Form
    {
        private readonly ApiService _apiService;
        private readonly int _destinationId;

        public DestinationDetails(
            DestinationDto destination,
            ApiService apiService)
        {
            InitializeComponent();

            lblName.Text = destination.Name;
            lblCountry.Text = destination.Country;
            lblDescription.Text = destination.Description;

            _destinationId = destination.Id;
            _apiService = apiService;
        }

        private async void DestinationDetails_Load(
            object sender,
            EventArgs e)
        {
            try
            {
                AddWeatherButton();

                await LoadPlaces();

                Log.Information(
                    "Destination details loaded. DestinationId={DestinationId}",
                    _destinationId);
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to load destination details. DestinationId={DestinationId}",
                    _destinationId);

                MessageBox.Show(
                    "Failed to load destination places.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadPlaces()
        {
            var places =
                await _apiService.GetAsync<List<PlaceDto>>(
                    $"places/{_destinationId}");

            dataGridViewPlaces.DataSource = places;

            Log.Information(
                "Loaded {Count} places for DestinationId {DestinationId}",
                places?.Count ?? 0,
                _destinationId);
        }

        private void AddWeatherButton()
        {
            if (dataGridViewPlaces.Columns["View Weather"] != null)
                return;

            var btn = new DataGridViewButtonColumn
            {
                Name = "View Weather",
                HeaderText = "View Weather",
                Text = "View Weather",
                UseColumnTextForButtonValue = true
            };

            dataGridViewPlaces.Columns.Add(btn);
        }

        private void dataGridViewPlaces_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dataGridViewPlaces.Columns[e.ColumnIndex].Name != "View Weather")
                    return;

                var place =
                    (PlaceDto)dataGridViewPlaces
                    .Rows[e.RowIndex]
                    .DataBoundItem;

                if (place == null)
                    return;

                Log.Information(
                    "Opening weather for PlaceId={PlaceId}, PlaceName={PlaceName}",
                    place.Id,
                    place.Name);

                using var weatherForm =
                    new Weather(
                        new SelectedPlaceContext
                        {
                            DestinationId = _destinationId,
                            DestinationName = lblName.Text,
                            PlaceId = place.Id,
                            PlaceName = place.Name,
                            Latitude = place.Latitude,
                            Longitude = place.Longitude
                        },
                        _apiService);

                weatherForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to open weather form");

                MessageBox.Show(
                    "Unable to open weather information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}