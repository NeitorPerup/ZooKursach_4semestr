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
                    .Include(x => x.CostItemRoute).ThenInclude(x => x.CostItem).
                    FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return route != null ? CreateModel(route) : null;
            }
        }

        public List<RouteViewModel> GetFilteredList(RouteBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Include(x => x.User).Include(x => x.RouteReserve).ThenInclude(x => x.Reserve)
                    .Include(x => x.CostItemRoute).ThenInclude(x => x.CostItem)
                    // сортируем по дате(для отчёта) и по клиенту
                    .Where(rec => (model.DateFrom.HasValue && model.DateTo.HasValue && model.DateFrom.Value.Date <= rec.DateVisit.Date
                     && rec.DateVisit.Date <= model.DateTo.Value.Date && model.UserId.HasValue && model.UserId == rec.UserId)
                     // сортируем по клиенту
                     || (model.UserId.HasValue && !model.DateFrom.HasValue && model.UserId == rec.UserId))
                    .ToList().Select(CreateModel).ToList();
            }
        }

        public List<RouteViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Include(x => x.User).Include(x => x.RouteReserve).ThenInclude(x => x.Reserve)
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
                Count = route.Count,
                Name = route.Name,
                DateVisit = route.DateVisit,
                RouteReverces = route.RouteReserve.ToDictionary(x => x.ReserveId, x => x.Reserve.Name),
                CostItemRoute = route.CostItemRoute.ToDictionary(x => x.CostItemId, x => x.CostItem.Sum)
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
