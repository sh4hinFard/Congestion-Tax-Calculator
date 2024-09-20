using FardTest.Models;
using System;
using System.Linq;

namespace FardTest.Service
{
    public class CongestionTaxCalculator
    {
        private readonly ITaxRuleService _taxRuleService;
        private readonly IVehicleService _vehicleService;

        public CongestionTaxCalculator(ITaxRuleService taxRuleService, IVehicleService vehicleService)
        {
            _taxRuleService = taxRuleService;
            _vehicleService = vehicleService;
        }

        public List<decimal> CalculateTaxes(Vehicle vehicle, DateTime[] entryTimes, string city)
        {
            var taxes = new List<decimal>();

            // Return a list of zeroes if the vehicle is toll-free
            if (_vehicleService.IsTollFreeVehicle(vehicle))
            {
                return entryTimes.Select(_ => 0m).ToList();
            }

            decimal totalTax = 0;
            DateTime intervalStart = entryTimes[0];

            foreach (var entryTime in entryTimes.OrderBy(d => d))
            {
                // Skip toll-free dates or toll-free month (July)
                if (IsWeekend(entryTime) || IsTollFreeMonth(entryTime))
                {
                    taxes.Add(0); // No tax on weekends or in July
                    continue;
                }

                decimal nextTax = _taxRuleService.GetTollAmount(entryTime, city);
                decimal currentTax = _taxRuleService.GetTollAmount(intervalStart, city);

                if (IsWithinSameHour(intervalStart, entryTime))
                {
                    // Use the highest tax within the same hour
                    totalTax -= currentTax;
                    totalTax += Math.Max(currentTax, nextTax);
                }
                else
                {
                    totalTax += nextTax;
                    intervalStart = entryTime; // Reset interval start to current entry time
                }

                // Apply daily cap of 60 SEK
                totalTax = Math.Min(totalTax, 60);

                // Add the current tax to the list
                taxes.Add(nextTax);
            }

            return taxes;
        }

        private bool IsTollFreeMonth(DateTime date)
        {
            // The entire month of July is toll-free
            return date.Month == 7;
        }

        private bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday
                || date.DayOfWeek == DayOfWeek.Sunday;
        }


        private bool IsWithinSameHour(DateTime intervalStart, DateTime currentDateTime)
        {
            return (currentDateTime - intervalStart).TotalMinutes <= 60;
        }
    }
}
