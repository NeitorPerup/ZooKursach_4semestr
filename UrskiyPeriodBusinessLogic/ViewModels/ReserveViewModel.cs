using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace UrskiyPeriodBusinessLogic.ViewModels
{
    [DataContract]
    public class ReserveViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Название")]
        public string Name { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal Price { get; set; }

        [DataMember]
        [DisplayName("Цена")]
        public decimal PriceToPay { get; set; }
    }
}
