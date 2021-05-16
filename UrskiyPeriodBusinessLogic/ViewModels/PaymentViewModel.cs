using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UrskiyPeriodBusinessLogic.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }

        public int ReserveId { get; set; }

        public int UserId { get; set; }

        [DisplayName("Оплачено")]
        public decimal? Sum { get; set; }

        [DisplayName("Дата оплаты")]
        public DateTime? PaymentDate { get; set; }
    }
}
