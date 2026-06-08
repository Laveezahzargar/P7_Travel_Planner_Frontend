using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using P7_Travel_Planner_Frontend.Helpers;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnViewDestinations_Click(object sender, EventArgs e)
        {
            this.Hide();

            Destinations destinations = new Destinations();
            destinations.ShowDialog();

            this.Show();
        }

        private void btnMyTrips_Click(object sender, EventArgs e)
        {
            this.Hide();

            MyTrips myTrips = new MyTrips();
            myTrips.ShowDialog();

            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblUsername.Text = $"Welcome, {SessionManager.Username}!";
        }
    }
}
