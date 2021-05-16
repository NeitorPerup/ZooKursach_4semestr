using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class Route
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Cost { get; set; }

        [Required]
        public DateTime DateVisit { get; set; }    

        [ForeignKey("RouteId")]
        public List<RouteReserve> RouteReserve { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("RouteId")]
        public List<CostItemRoute> CostItemRoute { get; set; }
    }
}
