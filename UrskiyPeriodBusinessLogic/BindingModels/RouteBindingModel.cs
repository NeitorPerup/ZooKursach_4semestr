using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UrskiyPeriodBusinessLogic.BindingModels
{
    [DataContract]
    public class RouteBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int? UserId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Cost { get; set; }

        [DataMember]
        public DateTime DateVisit { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }

        [DataMember]
        public Dictionary<int, string> RouteReverces { get; set; } // ReverseId, ReverseName

        [DataMember]
        public Dictionary<int, decimal> CostItemRoute { get; set; } // CostItemId, sum
    }
}
