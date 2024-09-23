using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FardTest.Service.Repositories
{
    public interface ITaxRuleService
    {
        int GetTollAmount(DateTime date, string city);
    }

}
