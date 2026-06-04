using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Services;
using System.Text.RegularExpressions;
using P7_Travel_Planner_Frontend.Forms;

namespace P7_Travel_Planner_Frontend
{
    public partial class Register : Form
    {
        private readonly ApiService _apiService;
        public Register()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs())
                    return;

                var dto = new RegisterDto
                {
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text
                };

                var response = await _apiService.PostAsync(
                           "users/register",
                           dto);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Registration successful!");

                    this.Hide();
                    new Login().ShowDialog();
                }
                else
                {
                    MessageBox.Show(
                        await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtUsername.Text.Length < 3 || txtFullName.Text.Length < 3)
            {
                MessageBox.Show("Username and full name must be at least 3 characters long.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Email validation
            if (!Regex.IsMatch(txtEmail.Text,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.",
                    "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void linkLogin_LinkClicked(
        object sender,
        LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();

            this.Hide();
        }
    }
}
