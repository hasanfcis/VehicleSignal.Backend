using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleSignal.Web.API.DTOs
{
    public class VehicleStatusDTO
    {
        public long VehicleId { get; set; }
        public int StatusId { get; set; }
    }
}
