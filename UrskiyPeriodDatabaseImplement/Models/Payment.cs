using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrskiyPeriodDatabaseImplement.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int ReserveId { get; set; }

        public int UserId { get; set; }

        public virtual Reserve Reserve { get; set; }

        public virtual User User { get; set; }

        [Required]
        public decimal Sum { get; set; }
    }
}
