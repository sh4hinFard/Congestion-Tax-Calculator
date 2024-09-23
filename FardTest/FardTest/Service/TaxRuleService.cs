using FardTest.Dbcontext;
using FardTest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FardTest.Service
{
    public class TaxRuleService : ITaxRuleService
    {
        private readonly CongestionTaxDbContext _context;

        public TaxRuleService(CongestionTaxDbContext context)
        {
            _context = context;
        }

        public int GetTollAmount(DateTime date, string city)
        {
            var timeOfDay = date.TimeOfDay;
            var taxRule = _context.TaxRules
                .Where(t => t.Year == date.Year && t.City == city)
                .FirstOrDefault(t => timeOfDay >= t.StartTime && timeOfDay <= t.EndTime);

            return taxRule?.Amount ?? 0;
        }
    }

}
