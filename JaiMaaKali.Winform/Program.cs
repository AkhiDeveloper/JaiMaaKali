using JaiMaaKali.WinForm.Data.Repository;
using JaiMaaKali.WinForm.Map;
using JaiMaaKali.WinForm.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JaiMaaKali.WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            
            ApplicationConfiguration.Initialize();
            Application.Run(ServiceProvider.GetRequiredService<MainWindow>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }


        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddAutoMapper(cfg => {
                        AppDomain.CurrentDomain.GetAssemblies();
                        cfg.AddProfile<MappingProfile>();
                    });
                    services.AddTransient<MainWindow>();
                    services.AddScoped<IRepository<Data.Model.AmountDiscount>, BaseRepository<Data.Model.AmountDiscount>>();
                    services.AddScoped<IRepository<Data.Model.PartyClaimCriteria>,BaseRepository<Data.Model.PartyClaimCriteria>>();
                    services.AddScoped<IRepository<Data.Model.BillItem>, BaseRepository<Data.Model.BillItem>>();
                });
        }
    }
}