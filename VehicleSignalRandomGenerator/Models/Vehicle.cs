using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleSignalRandomGenerator
{
    public class Vehicle
    {
        public long Id { get; set; }

        public string VehicleIdentifier { get; set; }

        public string RegisterNumber { get; set; }

        public long CustomerId { get; set; }

        public DateTime LastSignalTime { get; set; }

        public long StatusId { get; set; }

        public string StatusName { get; set; }
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }
    }
}
