using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FardTest.Models
{
    public class TaxRule
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Amount { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
    }

}
