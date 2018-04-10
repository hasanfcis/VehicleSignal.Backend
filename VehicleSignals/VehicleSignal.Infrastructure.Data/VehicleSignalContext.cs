using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleSignal.Domain.Entities;

namespace VehicleSignal.Infrastructure.Data
{
    public class VehicleSignalContext : DbContext
    {
        public VehicleSignalContext(DbContextOptions<VehicleSignalContext> options) : base(options) => Database.EnsureCreated();

        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Status> Status { get; set; }
        
    }
}
