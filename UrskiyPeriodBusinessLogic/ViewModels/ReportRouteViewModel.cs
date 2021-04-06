using System;
using System.Collections.Generic;
using System.Text;

namespace UrskiyPeriodBusinessLogic.ViewModels
{
    public class ReportRouteViewModel
    {
        public string Name { get; set; }

        public int Count { get; set; }

        public List<ReserveViewModel> Reserves { get; set; }

        public DateTime DateVisit { get; set; }

        public decimal Cost { get; set; }
    }
}
