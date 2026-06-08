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

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class Weather : Form
    {
        private readonly ApiService _apiService;
        public Weather(SelectedPlaceContext context, ApiService apiService)
        {
            InitializeComponent();

            lblDestination.Text = context.DestinationName;
            lblPlace.Text = context.PlaceName;
     
            _apiService = apiService;

            LoadWeather(context);
        }

        private async Task LoadWeather(SelectedPlaceContext context)
        {
            try
            {
                var weather = await _apiService.GetAsync<WeatherDto>(
                    $"weather/{context.DestinationId}"
                );

                if (weather != null)
                {
                    lblTemperature.Text = weather.Temperature + " °C";
                    lblCondition.Text = weather.Condition;
                    lblHumidity.Text = weather.Humidity + " %";
                    lblWind.Text = weather.WindSpeed + " km/h";
                }

                var forecast = await _apiService.GetAsync<List<WeatherDto>>(
                    $"weather/forecast/{context.DestinationId}"
                );

                dataGridViewForecast.DataSource = forecast;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Weather error: " + ex.Message);
            }
        }
    }
}
