using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodDatabaseImplement.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UrskiyPeriodDatabaseImplement.Implements
{
    public class RouteStorage : IRouteStorage
    {        
        public RouteViewModel GetElement(RouteBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new UrskiyPeriodDatabase())
            {
                var route = context.Routes.Include(x => x.User).Include(x => x.RouteReserve).ThenInclude(x => x.Reserve)
                    .ThenInclude(x => x.Payment)
                    .Include(x => x.CostItemRoute).ThenInclude(x => x.CostItem).
                    FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return route != null ? CreateModel(route) : null;
            }
        }

        public List<RouteViewModel> GetFilteredList(RouteBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Include(x => x.User).Include(x => x.RouteReserve).ThenInclude(x => x.Reserve)
                    .ThenInclude(x => x.Payment)
                    .Include(x => x.CostItemRoute).ThenInclude(x => x.CostItem)
                    .Where(rec =>
                     // сортируем по клиенту
                     (model.UserId.HasValue && !model.DateFrom.HasValue && model.PickedRoutes == null && model.UserId == rec.UserId) ||
                    // маршруты без статей затрат для заполнения бд
                    (!model.DateFrom.HasValue && model.PickedRoutes == null && !model.UserId.HasValue && model.NoCost.HasValue &&
                    model.NoCost.Value && rec.CostItemRoute.Count == 0))
                    .ToList().Select(CreateModel).ToList();
            }
        }

        public List<RouteViewModel> GetFilteredByPickList(RouteBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Include(x => x.User).Include(x => x.RouteReserve).ThenInclude(x => x.Reserve)
                    .Where(x => model.PickedRoutes.Contains(x.Id)).Select(x => new RouteViewModel
                    {
                        Reserves = x.RouteReserve.Select(rec => new ReserveViewModel
                        {
                            Name = rec.Reserve.Name,
                            Price = rec.Reserve.Price
                        }).ToList(),
                        Name = x.Name,
                        Cost = x.Cost
                    }).ToList();
            }
        }

        public List<RouteViewModel> GetFilteredByDateList(RouteBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Include(x => x.User).Include(x => x.CostItemRoute).ThenInclude(x => x.CostItem)
                    .Where(rec => model.DateFrom.HasValue && model.DateFrom.HasValue && 
                    model.DateFrom.Value.Date <= rec.DateVisit.Date &&
                    rec.DateVisit.Date <= model.DateTo.Value.Date && model.UserId == rec.UserId)
                    .Select(x => new RouteViewModel
                    {
                        CostItems = x.CostItemRoute.Select(rec => new CostItemViewModel
                        {
                            Name = rec.CostItem.Name,
                            Sum = rec.CostItem.Sum
                        }).ToList(),
                        Name = x.Name,
                        Cost = x.Cost,
                        DateVisit = x.DateVisit,
                        Count = x.Count
                    }).ToList();
            }
        }

        public List<RouteViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Include(x => x.User).Include(x => x.RouteReserve).ThenInclude(x => x.Reserve)
                    .ThenInclude(x => x.Payment)
                    .Include(x => x.CostItemRoute).ThenInclude(x => x.CostItem)
                    .Select(CreateModel).ToList();
            }
        }

        public void Insert(RouteBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (context.Routes.FirstOrDefault(rec => rec.Name == model.Name) != null)
                            return;

                        Route route = CreateModel(new Route(), model);
                        context.Routes.Add(route);
                        context.SaveChanges();
                        CreateModel(route, model, context);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(RouteBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var route = context.Routes.FirstOrDefault(rec => rec.Id == model.Id);
                        if (route == null)
                        {
                            throw new Exception("Маршрут не найден");
                        }
                        CreateModel(route, model, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(RouteBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var route = context.Routes.FirstOrDefault(rec => rec.Id == model.Id);
                if (route == null)
                {
                    throw new Exception("Маршрут не найден");
                }
                context.Routes.Remove(route);
                context.SaveChanges();
            }
        }

        private RouteViewModel CreateModel(Route route)
        {
            return new RouteViewModel
            {
                Id = route.Id,
                Cost = route.Cost,
                CostToPay = route.Cost - route.RouteReserve.Sum(x => x.Reserve.Payment.Sum(y => y.Sum)),
                Count = route.Count,
                Name = route.Name,
                DateVisit = route.DateVisit,
                RouteReverces = route.RouteReserve.ToDictionary(x => x.ReserveId, x => x.Reserve.Name),
                CostItemRoute = route.CostItemRoute.ToDictionary(x => x.CostItemId, x => x.CostItem.Sum),
                CostItems = route.CostItemRoute.Select(x => new CostItemViewModel
                {
                    Id = x.CostItemId,
                    Name = x.CostItem.Name,
                    Sum = x.CostItem.Sum
                }).ToList(),
                UserId = route.UserId,
                Reserves = route.RouteReserve.Select(rec => new ReserveViewModel
                {
                    Id = rec.ReserveId,
                    Name = rec.Reserve.Name,
                    Price = rec.Reserve.Price
                }).ToList(),
                ReserveId = route.RouteReserve.Select(x => x.ReserveId).ToList()
            };
        }

        private Route CreateModel(Route route, RouteBindingModel model)
        {
            route.Cost = model.Cost;
            route.Count = model.Count;
            route.Name = model.Name;
            route.DateVisit = model.DateVisit;
            route.UserId = model.UserId.Value;
            return route;
        }

        private Route CreateModel(Route route, RouteBindingModel model, UrskiyPeriodDatabase context)
        {
            route = CreateModel(route, model);
            
            if (model.Id.HasValue)
            {
                var routeReserve = context.RouteReserves.Where(rec =>
                rec.RouteId == model.Id.Value).ToList();
                // удаляем те, которых нет в модели
                context.RouteReserves.RemoveRange(routeReserve.Where(rec =>
                !model.RouteReverces.ContainsKey(rec.ReserveId)).ToList());
                context.SaveChanges();

                foreach (var Reserve in routeReserve)
                {
                    model.RouteReverces.Remove(Reserve.ReserveId);
                }
            }

            foreach (var routeReserve in model.RouteReverces)
            {
                context.RouteReserves.Add(new RouteReserve
                {
                    ReserveId = routeReserve.Key,
                    RouteId = route.Id
                });
            }
            context.SaveChanges();
            return route;
        }
    }
}
