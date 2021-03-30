using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UrskiyPeriodBusinessLogic.ViewModels
{
    public class RouteViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Количество заповедников")]
        public int Count { get; set; }

        [DisplayName("Стоимость")]
        public decimal Cost { get; set; }

        [DisplayName("Дата посещения")]
        public DateTime DateVisit { get; set; }

        public Dictionary<int, string> RouteReverces { get; set; } // ReverseId, ReverseName
    }
}
