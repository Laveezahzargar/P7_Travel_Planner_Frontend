using Serilog;
using Serilog.Events;

namespace P7_Travel_Planner_Frontend
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            Directory.CreateDirectory(logPath);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(logPath, "info-.txt"),
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} | {Level:u3} | {Message:lj}{NewLine}{Exception}{NewLine}------------------------{NewLine}"
                )
                .WriteTo.File(
                    Path.Combine(logPath, "error-.txt"),
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Error,
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} | {Level:u3} | {Message:lj}{NewLine}{Exception}{NewLine}------------------------{NewLine}"
                )
                .CreateLogger();

            try
            {
                Log.Information("Application starting");

                ApplicationConfiguration.Initialize();

                Log.Information("Opening Register form");

                Application.Run(new Register());

                Log.Information("Application closed normally");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application terminated unexpectedly");

                MessageBox.Show(
                    "An unexpected error occurred. Please check the log files.",
                    "Application Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Log.Information("Shutting down logging");
                Log.CloseAndFlush();
            }
        }
    }
}