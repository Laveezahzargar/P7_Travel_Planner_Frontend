using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;
using Serilog;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class Weather : Form
    {
        private readonly ApiService _apiService;
        private readonly SelectedPlaceContext _context;

        public Weather(SelectedPlaceContext context, ApiService apiService)
        {
            InitializeComponent();

            _context = context;
            _apiService = apiService;

            lblDestination.Text = context.DestinationName;
            lblPlace.Text = context.PlaceName;
        }

        private async void Weather_Load(object sender, EventArgs e)
        {
            try
            {
                Log.Information(
                    "Loading weather for DestinationId {DestinationId}",
                    _context.DestinationId);

                var weather = await _apiService.GetAsync<WeatherDto>(
                    $"weather/{_context.DestinationId}");

                if (weather != null)
                {
                    lblTemperature.Text = $"{weather.Temperature} °C";
                    lblCondition.Text = weather.Condition;
                    lblHumidity.Text = $"{weather.Humidity} %";
                    lblWind.Text = $"{weather.WindSpeed} km/h";
                }

                var forecast = await _apiService.GetAsync<List<WeatherDto>>(
                    $"weather/forecast/{_context.DestinationId}");

                dataGridViewForecast.DataSource = forecast;

                Log.Information(
                    "Weather loaded successfully for DestinationId {DestinationId}",
                    _context.DestinationId);
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to load weather for DestinationId {DestinationId}",
                    _context.DestinationId);

                MessageBox.Show(
                    "Unable to load weather information.",
                    "Weather Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}