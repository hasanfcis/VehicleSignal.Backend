using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleSignal.Domain.Entities;

namespace VehicleSignal.Infrastructure.Data
{
    public class VehicleSignalInitializer
    {
        private VehicleSignalContext _context;

        public VehicleSignalInitializer(VehicleSignalContext context)
        {
            _context = context;
        }


        public async Task Seed()
        {

            var _customer = new List<Customer>()
            {
                new Customer()
                    {
                        Name ="Kalles Grustransporter",Address="AB Cementvägen 8, 111 11 Södertälje ", Vehicles = new List<Vehicle>{
                        new Vehicle()
                        {
                            VehicleIdentifier="YS2R4X20005399401",
                            LastSignalTime=DateTime.Now,
                            RegisterNumber="ABC123",
                            Status = new Status{Id = 0, Name = "Disconnected"}
                        }
                        ,
                        new Vehicle()
                        {
                            VehicleIdentifier="VLUR4X20009093588",
                            LastSignalTime=DateTime.Now,
                            RegisterNumber="DEF456",
                            Status = new Status{Id = 1, Name = "Connected"}
                        },
                        new Vehicle()
                        {
                            VehicleIdentifier="VLUR4X20009048066",
                            LastSignalTime=DateTime.Now,
                            RegisterNumber="GHI789",
                            Status = new Status{Id = 1, Name = "Connected"}
                        }
                    }

                    },
                 new Customer()
                    {
                        Name ="Johans Bulk AB",Address="Balkvägen 12, 222 22 Stockholm", Vehicles = new List<Vehicle>{
                        new Vehicle()
                        {
                            VehicleIdentifier="YS2R4X20005388011",
                            LastSignalTime=DateTime.Now,
                            RegisterNumber="JKL012",
                            Status = new Status{Id = 0, Name = "Disconnected"}
                        }
                        ,
                        new Vehicle()
                        {
                            VehicleIdentifier="YS2R4X20005387949",
                            LastSignalTime=DateTime.Now,
                            RegisterNumber="MNO345",
                            Status = new Status{Id = 1, Name = "Connected"}
                        }
                       }

                    },
                 new Customer()
                    {
                        Name ="Haralds Värdetransporter AB",Address="Budgetvägen 1, 333 33 Uppsala", Vehicles = new List<Vehicle>{
                        new Vehicle()
                        {
                            VehicleIdentifier="YS2R4X20005387765",
                            LastSignalTime=DateTime.Now,
                            RegisterNumber="PQR678",
                            Status = new Status{Id = 0, Name = "Disconnected"}
                        }
                        ,
                        new Vehicle()
                        {
                            VehicleIdentifier="YS2R4X20005387055",
                            LastSignalTime=DateTime.Now,
                            RegisterNumber="STU901",
                            Status = new Status{Id = 1, Name = "Connected"}
                        }
                       }

                    },

            };

            var _status = new List<Status>()
            {
                new Status(){Name="Connected",Id=1},new Status {Name="Disconnected",Id=0}
            };

            if (!_context.Status.Any())
            {
                _context.AddRange(_status);
                await _context.SaveChangesAsync();
            }


            if (!_context.Customer.Any())
            {
                _context.AddRange(_customer);
                await _context.SaveChangesAsync();
            }

        }
    }
}
