using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace UrskiyPeriodBusinessLogic.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [DisplayName("Почта")]
        public string Email { get; set; }

        [DisplayName("Имя")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        public Dictionary<int, int> UserRoutes { get; set; } // RouteId, Count(количество заповедников)
    }
}
