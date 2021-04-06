using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public virtual Route Route { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }
    }
}
