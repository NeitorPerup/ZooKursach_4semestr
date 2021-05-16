using System;
using System.Collections.Generic;
using System.Text;

namespace UrskiyPeriodBusinessLogic.BindingModels
{
    public class PaymentBindingModel
    {
        public int? Id { get; set; }

        public int ReserveId { get; set; }

        public int UserId { get; set; }

        public decimal? Sum { get; set; }
    }
}
