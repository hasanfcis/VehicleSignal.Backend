using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VehicleSignal.Domain.Entities;
using VehicleSignal.Domain.Interfaces;
using VehicleSignal.Domain.Interfaces.IRepositories;
using VehicleSignal.Infrastructure.Data;

namespace IVehicleSignal.Infrastructure.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        public readonly VehicleSignalContext _context;

        public VehicleRepository(VehicleSignalContext context)
        {
            this._context = context;
        }
        public IEnumerable<Vehicle> GetVehicles()
        {
            return _context.Vehicle.Include(v => v.Customer).Include(v => v.Status);
        }

        public void UpdateVehicleStatus(long vehicleId, int statusId)
        {
            Vehicle vehicle = _context.Vehicle.First<Vehicle>(v => v.Id == vehicleId);

            vehicle.StatusId = statusId;
            _context.Update<Vehicle>(vehicle);
            _context.SaveChanges();

        }
    }
}
