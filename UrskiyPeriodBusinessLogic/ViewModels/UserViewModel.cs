using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace UrskiyPeriodBusinessLogic.ViewModels
{
    [DataContract]
    public class UserViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Почта")]
        public string Email { get; set; }

        [DataMember]
        [DisplayName("Имя")]
        public string Login { get; set; }

        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [DataMember]
        public Dictionary<int, int> UserRoutes { get; set; } // RouteId, Count(количество заповедников)
    }
}
