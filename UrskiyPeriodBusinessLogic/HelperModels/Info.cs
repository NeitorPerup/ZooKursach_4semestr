using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodBusinessLogic.HelperModels
{
    public class Info
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<RouteViewModel> Routes { get; set; }
    }
}
