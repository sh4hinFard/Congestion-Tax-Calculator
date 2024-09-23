using FardTest.Models;
using FardTest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FardTest.Service
{
    public class VehicleService : IVehicleService
    {
        public bool IsTollFreeVehicle(Vehicle vehicle)
        {
            return vehicle.Type == VehicleType.Emergency ||
                   vehicle.Type == VehicleType.Bus ||
                   vehicle.Type == VehicleType.Diplomat ||
                   vehicle.Type == VehicleType.Motorcycle ||
                   vehicle.Type == VehicleType.Military ||
                   vehicle.Type == VehicleType.Foreign;
        }
    }

}
