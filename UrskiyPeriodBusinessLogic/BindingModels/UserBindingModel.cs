using System;
using System.Collections.Generic;
using System.Text;

namespace UrskiyPeriodBusinessLogic.BindingModels
{
    public class UserBindingModel
    {
        public int? Id { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Dictionary<int, int> UserRoutes { get; set; } // RouteId, Count(количество заповедников)
    }
}
