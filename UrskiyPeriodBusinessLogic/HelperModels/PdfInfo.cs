using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodBusinessLogic.HelperModels
{
    public class PdfInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public List<RouteViewModel> Routes { get; set; }
    }
}
