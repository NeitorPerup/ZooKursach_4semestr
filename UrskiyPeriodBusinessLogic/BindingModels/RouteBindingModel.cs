using System;
using System.Collections.Generic;
using System.Text;

namespace UrskiyPeriodBusinessLogic.BindingModels
{
    public class RouteBindingModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public decimal Cost { get; set; }

        public DateTime DateVisit { get; set; }

        public Dictionary<int, string> RouteReverces { get; set; } // ReverseId, ReverseName
    }
}
