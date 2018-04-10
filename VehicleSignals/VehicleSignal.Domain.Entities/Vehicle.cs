using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleSignal.Domain.Entities
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string VehicleIdentifier { get; set; }

        public string RegisterNumber { get; set; }

        public long CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Status Status { get; set; }
        public DateTime LastSignalTime { get; set; }

        public long StatusId { get; set; }
    }
}
