using System;
using System.Collections.Generic;
using System.Text;

namespace UrskiyPeriodBusinessLogic.BindingModels
{
    public class CostItemBindingModel
    {
        public int? Id { get; set; }

        public decimal Sum { get; set; }

        public string Name { get; set; }

        public Dictionary<int, string> CostItemRoute { get; set; }
    }
}
