using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleSignal.Domain.Entities
{
    public class Status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public long Id { get; set; }
        public string Name { get; set; }

    }
}
