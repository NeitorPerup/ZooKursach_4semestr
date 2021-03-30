using System;
using System.Collections.Generic;
using System.Text;

namespace UrskiyPeriodBusinessLogic.BindingModels
{
    public class PaymentBindingModel
    {
        public int? Id { get; set; }

        public int RouteId { get; set; }

        public decimal? Sum { get; set; }

        public DateTime? PaymentDate { get; set; }
    }
}
