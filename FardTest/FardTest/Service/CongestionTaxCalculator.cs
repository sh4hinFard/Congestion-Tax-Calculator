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


        public int GetTax(Vehicle vehicle, DateTime[] dates, string city)
        {
            if (dates == null || dates.Length == 0) return 0;

            // Check if the vehicle is toll-free
            if (_vehicleService.IsTollFreeVehicle(vehicle))
            {
                return 0; // No tax for toll-free vehicles
            }

            DateTime intervalStart = dates[0];
            int totalFee = 0;

            foreach (var date in dates.OrderBy(d => d))
            {
                // Skip toll-free dates
                if (IsTollFreeDate(date))
                {
                    continue; // No tax for toll-free dates
                }

                int nextFee = _taxRuleService.GetTollAmount(date, city);
                int intervalStartFee = _taxRuleService.GetTollAmount(intervalStart, city);

                // Calculate time difference in minutes
                TimeSpan timeDifference = date - intervalStart;
                double minutesDifference = timeDifference.TotalMinutes;

                if (minutesDifference <= 60)
                {
                    // Use the higher fee within the same hour
                    totalFee -= intervalStartFee;
                    totalFee += Math.Max(intervalStartFee, nextFee);
                }
                else
                {
                    // If more than 60 minutes, reset interval start
                    totalFee += nextFee;
                    intervalStart = date;
                }

                // Cap the total fee for the day at 60 SEK
                if (totalFee >= 60)
                {
                    return 60; // Cap reached
                }
            }

            return totalFee;
        }
        private bool IsTollFreeDate(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            // Toll-free on weekends
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return true;

            // Toll-free for the entire month of July
            if (month == 7)
                return true;

            // Toll-free specific dates in 2013
            if (year == 2013)
            {
                if (month == 1 && day == 1 ||
                    month == 3 && (day == 28 || day == 29) ||
                    month == 4 && (day == 1 || day == 30) ||
                    month == 5 && (day == 1 || day == 8 || day == 9) ||
                    month == 6 && (day == 5 || day == 6 || day == 21) ||
                    month == 11 && day == 1 ||
                    month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
