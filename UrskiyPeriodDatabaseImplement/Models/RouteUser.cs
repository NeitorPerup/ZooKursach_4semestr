using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class RouteUser
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Route Route { get; set; }
    }
}
