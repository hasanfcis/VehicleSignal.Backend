using System;
using System.Collections.Generic;
using VehicleSignal.Domain.Entities;
using VehicleSignal.Domain.Interfaces.IRepositories;
using VehicleSignal.Domain.Interfaces.IServices;

namespace VehicleSignal.Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _repository.GetVehicles();
        }
        public void UpdateVehicleStatus(long vehicleId, int statusId)
        {
            _repository.UpdateVehicleStatus(vehicleId, statusId);
        }


    }
}
