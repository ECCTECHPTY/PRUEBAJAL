using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewCargaOpenKmCedulacion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Log from Information and above
                .WriteTo.File(
                    path: "logs\\cargador.log",            // Folder + filename
                    rollingInterval: RollingInterval.Day, // Create one log per day
                    retainedFileCountLimit: 30,       // Optional: keep last 30 days
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();

            try {
                Log.Information("Application starting");

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

                Log.Information("Application closing normally");
            }
            catch (Exception ex) {
                Log.Fatal(ex, "Application terminated unexpectedly");
            }
            finally {
                Log.CloseAndFlush();
            }
        }
    }
}
