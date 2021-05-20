using System;
using System.Collections.Generic;
using System.Linq;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodRestApi
{
    public class DatabaseHelper
    {
        private ReserveLogic _reserveLogic;

        private RouteLogic _routeLogic;

        private CostItemLogic _costItemLogic;

        public DatabaseHelper(ReserveLogic reserveLogic, RouteLogic routeLogic, CostItemLogic costItemLogic)
        {
            _reserveLogic = reserveLogic;
            _routeLogic = routeLogic;
            _costItemLogic = costItemLogic;
        }

        public void Load()
        {           
            ReservesLoad();
            CostUtemLoad();
        }

        public void ReservesLoad()
        {            
            var list = _reserveLogic.Read(null);
            List<ReserveBindingModel>  reserves = new List<ReserveBindingModel>{ new ReserveBindingModel { Name = "Бастак", Price = 199},
                    new ReserveBindingModel{ Name = "Белогорье", Price = 220}, new ReserveBindingModel{ Name = "Галичья гора", Price = 250},
                    new ReserveBindingModel{ Name = "Денежкин камень", Price = 350}, new ReserveBindingModel{ Name = "Кедровая Падь", Price = 220},
                    new ReserveBindingModel{ Name = "Кивач", Price = 200}, new ReserveBindingModel{ Name = "Нургуш", Price = 250},
                    new ReserveBindingModel{ Name = "Пасвик", Price = 230}, new ReserveBindingModel{ Name = "Ильменский заповедник", Price = 350},
                    new ReserveBindingModel{ Name = "Столбы", Price = 200}, new ReserveBindingModel{ Name = "Стрим Стэса", Price = 50}};
            if (list.Count < reserves.Count)
            {
                try
                {
                    foreach (var res in reserves)
                    {
                        var listName = list.Select(x => x.Name).ToList();
                        if (!listName.Contains(res.Name))
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
        
        public void CostUtemLoad()
        {
            List<CostItemBindingModel> list = new List<CostItemBindingModel>
                {
                    new CostItemBindingModel { Name = "Мясо", Sum = 10000},
                    new CostItemBindingModel { Name = "Питьевая вода", Sum = 3000},
                    new CostItemBindingModel { Name = "Расчёски для пингвинов", Sum = 800},
                    new CostItemBindingModel { Name = "Сахарная вата для гориллы", Sum = 1234},
                    new CostItemBindingModel { Name = "Львиная зубная нить", Sum = 4321},
                    new CostItemBindingModel { Name = "И", Sum = 6666},
                    new CostItemBindingModel { Name = "Ещё", Sum = 5674},
                    new CostItemBindingModel { Name = "5", Sum = 3643},
                    new CostItemBindingModel { Name = "Статей", Sum = 23467},
                    new CostItemBindingModel { Name = "Затрат", Sum = 99999},
                    new CostItemBindingModel { Name = "Бэргеры", Sum = 5}
                };
            var routes = _routeLogic.Read(new RouteBindingModel { NoCost = true });
            if ((routes == null || routes.Count == 0) && _costItemLogic.Count() >= list.Count)
                return;
            try
            {
                Random rand = new Random();
                foreach (var route in routes)
                {                   
                    int costCount = rand.Next(1, list.Count - 1);
                    int start = rand.Next(0, list.Count - 2);
                    if (start > costCount)
                    {
                        int temp = start;
                        start = costCount;
                        costCount = temp;
                    }
                    for (int i = start; i <= costCount; ++i)
                    {
                        var cost = list[i];
                        if (cost.CostItemRoute == null)
                        {
                            var elem = _costItemLogic.GetElement(cost);
                            if (elem != null)
                            {
                                cost.CostItemRoute = elem.CostItemRoute;
                                cost.Id = elem.Id;
                            }
                            else
                            {
                                cost.CostItemRoute = new Dictionary<int, string>();
                            }
                        }
                        if (!cost.CostItemRoute.ContainsKey(route.Id))
                        {
                            cost.CostItemRoute.Add(route.Id, route.Name);
                        }
                    }
                }
                foreach (var cost in list)
                {
                    if (cost.CostItemRoute != null && cost.CostItemRoute.Count > 0)
                    {
                        _costItemLogic.CreateOrUpdate(cost);
                    }
                }




                //Random rnd = new Random(1000);
                //int costCount = 0;
                //while (routes.Count() > 0)
                //{
                //    int count = routes.Count();
                //    costCount += rnd.Next(0, (list.Count - 1) / 2);
                //    for (int i = 0; i < costCount; ++i)
                //    {
                //        var cost = list[i];
                //        var elem = _costItemLogic.GetElement(cost);
                //        if (elem != null)
                //        {
                //            cost.Id = elem.Id;
                //            cost.CostItemRoute = elem.CostItemRoute;
                //            // Добавляем статью затрат к нескольким маршрутам без статей затрат
                //            int n = rnd.Next(count == 1 ? 0 : 1, count - 1);
                //            for (int j = 0; j <= n; j++)
                //            {
                //                var rt = routes[rnd.Next(0, count - 1)];
                //                elem.CostItemRoute.Add(rt.Id, rt.Name);
                //            }
                //        }
                //        else
                //        {
                //            cost.CostItemRoute = routes.Skip(rnd.Next(0, count / 3)).Take(rnd.Next(1, count / 2))
                //                .ToDictionary(x => x.Id, x => x.Name);
                //        }
                //        for (int k = 0; k < routes.Count; ++k)
                //        {
                //            if (routes[k].CostItemRoute.Count > 0)
                //            {
                //                routes.RemoveAt(k);
                //                k--;
                //            }
                //        }
                //        _costItemLogic.CreateOrUpdate(cost);
                //    }
                
            }
            catch
            {
                throw;
            }
        }
    }
}
