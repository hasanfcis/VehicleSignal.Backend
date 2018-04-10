using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleSignal.Domain.Entities;
using VehicleSignal.Web.API.DTOs;

namespace VehicleSignal.Web.API.AutoMapperConfiguration
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Vehicle, VehicleDTO>()
                .ForMember(dto => dto.CustomerName, opt => opt.MapFrom(vehicle => vehicle.Customer.Name))
                .ForMember(dto => dto.CustomerAddress, opt => opt.MapFrom(vehicle => vehicle.Customer.Address))
                .ForMember(dto => dto.StatusName, opt => opt.MapFrom(vehicle => vehicle.Status.Name));
            });
        }
    }
}
