using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using WinFormsGraphicsEditor.Servises;
using System.Windows.Forms;

namespace WinFormsGraphicsEditor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();

            ConfigureServices(services);

            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var form1 = serviceProvider.GetRequiredService<GraphicsEditor>();
                Application.Run(form1);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IDraw, Draw>();
            services.AddScoped<GraphicsEditor>();
        }
    }

}