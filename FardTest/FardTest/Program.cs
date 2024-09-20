using FardTest.Dbcontext;
using FardTest.Models;
using FardTest.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FardTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<CongestionTaxDbContext>();

            // Register services
            services.AddScoped<ITaxRuleService, TaxRuleService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<CongestionTaxCalculator>();

            var serviceProvider = services.BuildServiceProvider();
            var calculator = serviceProvider.GetService<CongestionTaxCalculator>();

            // Example vehicle and dates (add your test cases here)
            var vehicle = new Vehicle { LicensePlate = "ABC123", Type = VehicleType.Car }; // Car is subject to toll You can use Any type here
            DateTime[] dates = new DateTime[]
 {
    DateTime.Parse("2013-01-14 21:00:00"),
    DateTime.Parse("2013-01-15 21:00:00"),
    DateTime.Parse("2013-02-07 06:23:27"),
    DateTime.Parse("2013-02-07 15:27:00"),
    DateTime.Parse("2013-02-08 06:27:00"),
    DateTime.Parse("2013-02-08 06:20:27"),
    DateTime.Parse("2013-02-08 14:35:00"),
    DateTime.Parse("2013-02-08 15:29:00"),
    DateTime.Parse("2013-02-08 15:47:00"),
    DateTime.Parse("2013-02-08 16:01:00"),
    DateTime.Parse("2013-02-08 16:48:00"),
    DateTime.Parse("2013-02-08 17:49:00"),
    DateTime.Parse("2013-02-08 18:29:00"),
    DateTime.Parse("2013-02-08 18:35:00"),
    DateTime.Parse("2013-03-26 14:25:00"),
    DateTime.Parse("2013-03-28 14:07:27"),
    DateTime.Parse("2013-07-08 06:27:00")//its july month and its free
 };


            var taxes = calculator.CalculateTaxes(vehicle, dates, "Gothenburg");

            Console.WriteLine("Individual taxes:");
            foreach (var tax in taxes)
            {
                Console.WriteLine($"{tax} SEK");
            }

            // Alternatively, you can print the total tax sum (if needed):
            decimal totalTax = taxes.Sum();
            Console.WriteLine($"Total tax: {totalTax} SEK");
        }
    }
}
