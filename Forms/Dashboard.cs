using P7_Travel_Planner_Frontend.Helpers;
using Serilog;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                lblUsername.Text =
                    $"Welcome, {SessionManager.Username}!";

                Log.Information(
                    "Dashboard loaded for user {Username}",
                    SessionManager.Username);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to load dashboard");

                MessageBox.Show(
                    "Failed to load dashboard.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnViewDestinations_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Log.Information(
                    "User {Username} opened Destinations",
                    SessionManager.Username);

                Hide();

                using var destinations = new Destinations();
                destinations.ShowDialog();

                Show();
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to open Destinations form");

                MessageBox.Show(
                    "Unable to open Destinations.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Show();
            }
        }

        private void btnMyTrips_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                Log.Information(
                    "User {Username} opened My Trips",
                    SessionManager.Username);

                Hide();

                using var myTrips = new MyTrips();
                myTrips.ShowDialog();

                Show();
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Failed to open MyTrips form");

                MessageBox.Show(
                    "Unable to open My Trips.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Show();
            }
        }

        private void btnLogout_Click(
            object sender,
            EventArgs e)
        {
            Log.Information(
                "User {Username} logged out",
                SessionManager.Username);

            Application.Exit();
        }
    }
}