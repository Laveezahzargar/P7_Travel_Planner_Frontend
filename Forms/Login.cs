using P7_Travel_Planner_Frontend.DTOs;
using P7_Travel_Planner_Frontend.Helpers;
using P7_Travel_Planner_Frontend.Services;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Serilog;

namespace P7_Travel_Planner_Frontend.Forms
{
    public partial class Login : Form
    {
        private readonly ApiService _apiService;
        public Login()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Email validation
                if (!Regex.IsMatch(txtEmail.Text,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Please enter a valid email address.",
                        "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                btnLogin.Enabled = false;
                btnLogin.Text = "Logging in...";
                Cursor = Cursors.WaitCursor;

                var dto = new LoginDto
                {
                    Email = txtEmail.Text.Trim(),
                    Password = txtPassword.Text
                };

                Log.Information(
                "Login attempt for Email {Email}",
                dto.Email);

                var response = await _apiService.PostAsync(
                    "users/login",
                    dto);

                if (response.IsSuccessStatusCode)
                {
                    var result =
                        await response.Content.ReadFromJsonAsync<LoginResponseDto>();

                    if (result == null)
                    {
                        Log.Warning(
                    "Login returned null response for Email {Email}",
                    dto.Email);
                        MessageBox.Show("Invalid server response.");
                        return;
                    }

                    SessionManager.Token = result!.Token;
                    SessionManager.UserId = result.Id;
                    SessionManager.Role = result.Role.ToString();
                    SessionManager.Username = result.Username;

                    _apiService.SetToken(result.Token);

                    Log.Information(
                "User logged in successfully. UserId={UserId}, Username={Username}",
                result.Id,
                result.Username);

                    MessageBox.Show("Login Successful!");

                    this.Hide();

                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog();

                    this.Show();


                }
                else
                {
                    MessageBox.Show(
                        await response.Content.ReadAsStringAsync(),
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log.Error(
                    ex,
                    "Unexpected error during login");

                MessageBox.Show(
                    "An unexpected error occurred while logging in.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
                Cursor = Cursors.Default;
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Log.Information("Navigating to Register form");

            Register register = new Register();
            register.Show();

            this.Hide();
        }
    }
    
}
