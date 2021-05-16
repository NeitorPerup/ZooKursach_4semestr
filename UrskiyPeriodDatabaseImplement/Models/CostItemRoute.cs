using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class CostItemRoute
    {
        public int Id { get; set; }

        public int CostItemId { get; set; }

        public int RouteId { get; set; }

        public virtual CostItem CostItem { get; set; }

        public virtual Route Route { get; set; }
    }
}
