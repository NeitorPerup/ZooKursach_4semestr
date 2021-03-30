using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UrskiyPeriodBusinessLogic.ViewModels
{
    public class ReserveViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Цена")]
        public decimal Price { get; set; }
    }
}
