using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace UrskiyPeriodBusinessLogic.ViewModels
{
    [DataContract]
    public class RouteViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DataMember]
        [DisplayName("Количество заповедников")]
        public int Count { get; set; }

        [DataMember]
        [DisplayName("Стоимость")]
        public decimal Cost { get; set; }

        [DataMember]
        [DisplayName("Дата посещения")]
        public DateTime DateVisit { get; set; }

        [DataMember]
        public Dictionary<int, string> RouteReverces { get; set; } // ReverseId, ReverseName

        [DataMember]
        public Dictionary<int, string> RouteUsers { get; set; } // UserId, Email
    }
}
