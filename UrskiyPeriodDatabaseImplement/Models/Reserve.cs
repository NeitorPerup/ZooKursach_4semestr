using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class Reserve
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ReserveId")]
        public List<RouteReserve> RouteReserve { get; set; }

        [ForeignKey("ReserveId")]
        public List<Payment> Payment { get; set; }
    }
}
