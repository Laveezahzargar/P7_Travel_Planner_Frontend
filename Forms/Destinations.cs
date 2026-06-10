using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;
using Serilog;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class Destinations : Form
    {
        private readonly ApiService _apiService;
        private List<DestinationDto> _destinations = new();

        public Destinations()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void Destinations_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadDestinations();

                Log.Information("Destinations form loaded");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load destinations");

                MessageBox.Show(
                    "Failed to load destinations.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private async Task LoadDestinations()
        {
            var response =
                await _apiService.GetAsync<PagedResponseDto<DestinationDto>>(
                    "destinations?page=1&pageSize=100");

            _destinations = response?.Data ?? new List<DestinationDto>();

            dataGridViewDestinations.DataSource = null;
            dataGridViewDestinations.DataSource = _destinations;

            AddViewButton();

            dataGridViewDestinations.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            Log.Information(
                "Loaded {Count} destinations",
                _destinations.Count);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword =
                    txtSearch.Text.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    dataGridViewDestinations.DataSource = null;
                    dataGridViewDestinations.DataSource = _destinations;
                    return;
                }

                var response =
                    await _apiService.GetAsync<PagedResponseDto<DestinationDto>>(
                        $"destinations?search={keyword}&page=1&pageSize=100");

                var results =
                    response?.Data ?? new List<DestinationDto>();

                dataGridViewDestinations.DataSource = null;
                dataGridViewDestinations.DataSource = results;

                AddViewButton();

                Log.Information(
                    "Destination search '{Keyword}' returned {Count} results",
                    keyword,
                    results.Count);
            }
            catch (Exception ex)
            {
                Log.Error(ex,
                    "Destination search failed");

                MessageBox.Show(
                    "Search failed.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtSearch_KeyDown(
            object sender,
            KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Clear();

            dataGridViewDestinations.DataSource = null;
            dataGridViewDestinations.DataSource = _destinations;

            Log.Information("Destination search cleared");
        }

        private void dataGridViewDestinations_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                if (dataGridViewDestinations.Columns[e.ColumnIndex].Name != "View")
                    return;

                var destination =
                    (DestinationDto)dataGridViewDestinations
                    .Rows[e.RowIndex]
                    .DataBoundItem;

                Log.Information(
                    "Viewing destination {DestinationId} - {DestinationName}",
                    destination.Id,
                    destination.Name);

                using var details =
                    new DestinationDetails(destination, _apiService);

                details.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error(ex,
                    "Failed to open destination details");

                MessageBox.Show(
                    "Unable to open destination details.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddViewButton()
        {
            if (dataGridViewDestinations.Columns["View"] != null)
            {
                dataGridViewDestinations.Columns.Remove("View");
            }

            var btn = new DataGridViewButtonColumn
            {
                Name = "View",
                HeaderText = "View Details",
                Text = "View",
                UseColumnTextForButtonValue = true
            };

            dataGridViewDestinations.Columns.Add(btn);

            btn.DisplayIndex =
                dataGridViewDestinations.Columns.Count - 1;
        }
    }
}