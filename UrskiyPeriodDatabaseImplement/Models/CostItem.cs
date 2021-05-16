using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class CostItem
    {
        public int Id { get; set; }

        public decimal Sum { get; set; }

        public string Name { get; set; }

        [ForeignKey("CostItemId")]
        public List<CostItemRoute> CostItemRoute { get; set; }
    }
}
