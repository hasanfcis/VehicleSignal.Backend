using System;
using System.Collections.Generic;
using VehicleSignal.Domain.Entities;

namespace VehicleSignal.Domain.Interfaces.IRepositories
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetVehicles();
        void UpdateVehicleStatus(long vehicleId,int statusId);
    }
}
