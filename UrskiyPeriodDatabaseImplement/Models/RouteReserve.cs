using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class RouteReserve
    {
        public int Id { get; set; }

        public int ReserveId { get; set; }

        public int RouteId { get; set; }

        public virtual Reserve Reserve { get; set; }

        public virtual Route Route { get; set; }
    }
}
