using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Forms;
using P7_Travel_Planner_Frontend.Services;
using Serilog;
using System.Text.RegularExpressions;

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

                btnRegister.Enabled = false;
                btnRegister.Text = "Registering...";
                Cursor = Cursors.WaitCursor;

                var dto = new RegisterDto
                {
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text
                };

                Log.Information(
                    "Registration attempt for Username {Username}",
                    dto.Username);

                var response = await _apiService.PostAsync(
                    "users/register",
                    dto);

                if (response.IsSuccessStatusCode)
                {
                    Log.Information(
                        "User registered successfully: {Username}",
                        dto.Username);

                    MessageBox.Show(
                        "Registration successful!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Hide();

                    using var login = new Login();
                    login.ShowDialog();

                    Close();
                }
                else
                {
                    var errorMessage =
                        await response.Content.ReadAsStringAsync();

                    Log.Warning(
                        "Registration failed for Username {Username}. Response: {Response}",
                        dto.Username,
                        errorMessage);

                    MessageBox.Show(
                        errorMessage,
                        "Registration Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Unexpected error during registration");

                MessageBox.Show(
                    "An unexpected error occurred while registering.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
                btnRegister.Text = "Register";
                Cursor = Cursors.Default;
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
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (txtUsername.Text.Length < 3 ||
                txtFullName.Text.Length < 3)
            {
                MessageBox.Show(
                    "Username and full name must be at least 3 characters long.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (!Regex.IsMatch(
                txtEmail.Text,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show(
                    "Password must be at least 6 characters long.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void linkLogin_LinkClicked(
            object sender,
            LinkLabelLinkClickedEventArgs e)
        {
            Log.Information("Navigating to Login form");

            var login = new Login();
            login.Show();

            Hide();
        }
    }
}