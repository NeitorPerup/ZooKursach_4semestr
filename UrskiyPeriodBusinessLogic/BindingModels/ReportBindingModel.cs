using System;
using System.Collections.Generic;
using System.ComponentModel;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodBusinessLogic.BindingModels
{
    public class ReportBindingModel
    {
        public string FileName { get; set; }

        public int? UserId { get; set; }

        public string UserEmail { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public List<RouteViewModel> Routes { get; set; }

        [DisplayName("Маршруты")]
        public List<int> RouteId { get; set; }
    }
}
