using FardTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FardTest.Service.Contracts
{
    public interface IVehicleService
    {
        bool IsTollFreeVehicle(Vehicle vehicle);
    }

}
