using Microsoft.Extensions.DependencyInjection;

namespace ZayavkaTom1Tom2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Настройка DI контейнера
            var services = new ServiceCollection();
            services.AddSingleton<ExcelReader>();
            services.AddSingleton<OrderListReader>();
            services.AddSingleton<ReportGenerator>();
            services.AddSingleton<OrderProcessor>();
            services.AddTransient<MainForm>();

            var serviceProvider = services.BuildServiceProvider();


            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<MainForm>());
        }
    }
}