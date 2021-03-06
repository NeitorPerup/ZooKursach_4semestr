using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace UrskiyPeriodBusinessLogic.BindingModels
{
    [DataContract]
    public class UserBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}
