using System;
using System.Collections.Generic;
using VehicleSignal.Domain.Entities;

namespace VehicleSignal.Domain.Interfaces.IServices
{
    public interface IVehicleService
    {
        IEnumerable<Vehicle> GetVehicles();
        void UpdateVehicleStatus(long vehicleId, int statusId);

    }
}
