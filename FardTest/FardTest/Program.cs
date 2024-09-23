using FardTest.Dbcontext;
using FardTest.Models;
using FardTest.Service;
using FardTest.Service.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FardTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Set up dependency injection
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            var calculator = serviceProvider.GetRequiredService<ICongestionTaxCalculator>();

            // Test vehicle and date entries
            //The car is example for tax vehichle if you want get free vehicle just change the VehicleType
            var vehicle = new Vehicle { LicensePlate = "ABC123", Type = VehicleType.Car };

            //You can add or subtract dates
            DateTime[] dates = new DateTime[]
            {
                DateTime.Parse("2013-01-14 21:00:00"),
                DateTime.Parse("2013-01-15 21:00:00"),
                DateTime.Parse("2013-02-07 06:23:27"),
                DateTime.Parse("2013-02-07 15:27:00"),
                DateTime.Parse("2013-02-08 06:27:00"),
                DateTime.Parse("2013-02-08 06:20:27"),
                //DateTime.Parse("2013-02-08 14:35:00"),
                //DateTime.Parse("2013-02-08 15:29:00"),
                //DateTime.Parse("2013-02-08 15:47:00"),
                //DateTime.Parse("2013-02-08 16:01:00"),
                //DateTime.Parse("2013-02-08 16:48:00"),
                //DateTime.Parse("2013-02-08 17:49:00"),
                //DateTime.Parse("2013-02-08 18:29:00"),
                //DateTime.Parse("2013-02-08 18:35:00"),
                //DateTime.Parse("2013-03-26 14:25:00"),
                //DateTime.Parse("2013-03-28 14:07:27"),
                //DateTime.Parse("2013-07-08 06:27:00") // July month, no toll
            };

            // Calculate tax and print results
            int totalTax = calculator.GetTax(vehicle, dates, "Gothenburg");

            Console.WriteLine($"Total tax: {totalTax} SEK");
        }

        private static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<CongestionTaxDbContext>();
            services.AddScoped<ITaxRuleService, TaxRuleService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<ICongestionTaxCalculator, CongestionTaxCalculator>();
            return services;
        }
    }
}
