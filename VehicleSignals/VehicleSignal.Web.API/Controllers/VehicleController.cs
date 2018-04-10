using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using VehicleSignal.Domain.Interfaces.IServices;
using VehicleSignal.Web.API.DTOs;

namespace VehicleSignal.Web.API.Controllers
{
    /// <summary>
    /// Aha
    /// </summary>
    [Route("api/Vehicle")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _service;

        /// <summary>
        /// Vehivle controller to access the vehicle request
        /// </summary>
        /// <param name="service"></param>
        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Fetch all exist vehicles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetVehicles")]
        public List<VehicleDTO> GetVehicles()
        {
            List<VehicleDTO> vehiclesDTOLst = new List<VehicleDTO>();
            return AutoMapper.Mapper.Map(_service.GetVehicles(), vehiclesDTOLst);
        }
        /// <summary>
        /// Update vehicle status
        /// </summary>
        /// <param name="vehicleStatus"></param>
        [HttpPost]
        [Route("UpdateVehicle")]
        public void UpdateVehicle([FromBody]VehicleStatusDTO vehicleStatus)
        {
            _service.UpdateVehicleStatus(vehicleStatus.VehicleId,vehicleStatus.StatusId);
        }
    }
}