using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;
using P7_Travel_Planner_Frontend.DTOs;

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
            var response =
                await _apiService.GetAsync<PagedResponseDto<DestinationDto>>(
                    "destinations?page=1&pageSize=100");

            _destinations = response?.Data ?? new List<DestinationDto>();

            dataGridViewDestinations.DataSource = _destinations;

            if (!dataGridViewDestinations.Columns.Contains("View"))
            {
                DataGridViewButtonColumn btn =
                    new DataGridViewButtonColumn();

                btn.Name = "View";
                btn.HeaderText = "View Details";
                btn.Text = "View";
                btn.UseColumnTextForButtonValue = true;

                dataGridViewDestinations.Columns.Add(btn);
            }

            // Move button to last column
            dataGridViewDestinations.Columns["View"].DisplayIndex =
                dataGridViewDestinations.Columns.Count - 1;

            dataGridViewDestinations.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dataGridViewDestinations.DataSource = null;
                dataGridViewDestinations.DataSource = _destinations;
                return;
            }

            try
            {

                var response =
           await _apiService.GetAsync<PagedResponseDto<DestinationDto>>(
               $"destinations?search={keyword}&page=1&pageSize=100");

                var results = response?.Data ?? new List<DestinationDto>();

                dataGridViewDestinations.DataSource = null;
                dataGridViewDestinations.DataSource = results;

                AddViewButton();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed.\n{ex.Message}", "Error");
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();

            dataGridViewDestinations.DataSource = null;
            dataGridViewDestinations.DataSource = _destinations;
        }

        private void dataGridViewDestinations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridViewDestinations.Columns[e.ColumnIndex].Name == "View")
            {
                DestinationDto destination =
                    (DestinationDto)dataGridViewDestinations
                    .Rows[e.RowIndex]
                    .DataBoundItem;

                DestinationDetails details =
                 new DestinationDetails(destination,this._apiService);

                details.ShowDialog();
            }
        }

        private void AddViewButton()
        {
            if (dataGridViewDestinations.Columns["View"] != null)
            {
                dataGridViewDestinations.Columns.Remove("View");
            }

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn
            {
                Name = "View",
                HeaderText = "View Details",
                Text = "View",
                UseColumnTextForButtonValue = true
            };

            dataGridViewDestinations.Columns.Add(btn);

            // Force it to be last
            btn.DisplayIndex = dataGridViewDestinations.Columns.Count - 1;
        }
    }
}
