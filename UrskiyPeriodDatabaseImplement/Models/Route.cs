using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class Route
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public DateTime DateVisit { get; set; }

        [ForeignKey("RouteId")]
        public List<RouteUser> RouteUser { get; set; }

        [ForeignKey("RouteId")]
        public List<Payment> Payment { get; set; }

        [ForeignKey("RouteId")]
        public List<RouteReserve> RouteReserve { get; set; }
    }
}
