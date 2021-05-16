using System;
using System.Collections.Generic;
using System.Linq;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodView
{
    public static class DatabaseHelper
    {
        private static ReserveLogic _reserveLogic;

        private static RouteLogic _routeLogic;

        private static UserLogic _userLogic;

        private static CostItemLogic _costItemLogic;

        public static void Load(ReserveLogic reserveLogic, RouteLogic routeLogic, UserLogic userLogic, CostItemLogic costItemLogic)
        {
            _reserveLogic = reserveLogic;
            _routeLogic = routeLogic;
            _userLogic = userLogic;
            _costItemLogic = costItemLogic;
            ReservesLoad();
            CostUtemLoad();
        }

        public static void ReservesLoad()
        {            
            var list = _reserveLogic.Read(null);
            List<ReserveBindingModel>  reserves = new List<ReserveBindingModel>{ new ReserveBindingModel { Name = "Бастак", Price = 199},
                    new ReserveBindingModel{ Name = "Белогорье", Price = 220}, new ReserveBindingModel{ Name = "Галичья гора", Price = 250},
                    new ReserveBindingModel{ Name = "Денежкин камень", Price = 350}, new ReserveBindingModel{ Name = "Кедровая Падь", Price = 220},
                    new ReserveBindingModel{ Name = "Кивач", Price = 200}, new ReserveBindingModel{ Name = "Нургуш", Price = 250},
                    new ReserveBindingModel{ Name = "Пасвик", Price = 230}, new ReserveBindingModel{ Name = "Ильменский заповедник", Price = 350},
                    new ReserveBindingModel{ Name = "Столбы", Price = 200}};
            if (list.Count < 10)
            {
                try
                {
                    foreach (var res in reserves)
                    {
                        if (_reserveLogic.Read(res)?[0] == null)
                        {
                            _reserveLogic.CreateOrUpdate(res);
                        }                       
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        
        public static void CostUtemLoad()
        {
            if (_costItemLogic.Count() < 10)
            {                
                List<CostItemBindingModel> list = new List<CostItemBindingModel>
                {
                    new CostItemBindingModel { Name = "Мясо", Sum = 10000},
                    new CostItemBindingModel { Name = "Питьевая вода", Sum = 3000},
                    new CostItemBindingModel { Name = "Расчёски для пингвинов", Sum = 800},
                    new CostItemBindingModel { Name = "Сахарная вата для гориллы", Sum = 1234},
                    new CostItemBindingModel { Name = "Львиная зубная нить", Sum = 4321},
                    new CostItemBindingModel { Name = "", Sum = 6666},
                    new CostItemBindingModel { Name = "", Sum = 5674},
                    new CostItemBindingModel { Name = "", Sum = 3643},
                    new CostItemBindingModel { Name = "", Sum = 23467},
                    new CostItemBindingModel { Name = "", Sum = 99999},
                };

                try
                {
                    var routes = _routeLogic.Read(null);
                    if (routes == null)
                        return;
                    int count = routes.Count();
                    Random rnd = new Random();
                    foreach (var cost in list)
                    {
                        var elem = _costItemLogic.GetElement(cost);
                        if (elem != null)
                        {
                            cost.Id = elem.Id;
                            cost.CostItemRoute = elem.CostItemRoute;
                        }
                        else
                        {
                            cost.CostItemRoute = routes.Skip(rnd.Next(0, count / 3)).Take(rnd.Next(1, count / 3))
                                .ToDictionary(x => x.Id, x => x.Name);
                        }
                        _costItemLogic.CreateOrUpdate(cost);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
