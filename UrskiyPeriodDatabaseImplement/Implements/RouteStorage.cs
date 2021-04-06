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
                var route = context.Routes.Include(rec => rec. RouteUser)
                    .ThenInclude(rec => rec.User).Include(rec => rec.RouteReserve).ThenInclude(rec => rec.Reserve).FirstOrDefault(rec => rec.Id == model.Id);
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
                return context.Routes.Include(rec => rec.RouteUser).ThenInclude(rec => rec.User)
                    .Include(rec => rec.RouteReserve).ThenInclude(rec => rec.Reserve)
                    .Where(rec => model.DateFrom.HasValue && model.DateTo.HasValue && model.DateFrom.Value.Date <= rec.DateVisit.Date
                     && rec.DateVisit.Date <= model.DateTo.Value.Date &&
                     rec.RouteUser.Select(x => x.UserId).Contains(model.UserId.Value)
                     || (model.UserId.HasValue && !model.DateFrom.HasValue && rec.RouteUser.Select(x => x.UserId).Contains(model.UserId.Value)))
                    .ToList().Select(CreateModel).ToList();
            }
        }

        public List<RouteViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Include(rec => rec.RouteUser).ThenInclude(rec => rec.User)
                    .Include(rec => rec.RouteReserve).ThenInclude(rec => rec.Reserve).Select(CreateModel).ToList();
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
                    catch (Exception ex)
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
                RouteUsers = route.RouteUser.ToDictionary(x => x.UserId, x => x.User.Email),
                RouteReverces = route.RouteReserve.ToDictionary(x => x.ReserveId, x => x.Reserve.Name)
            };
        }

        private Route CreateModel(Route route, RouteBindingModel model)
        {
            route.Cost = model.Cost;
            route.Count = model.Count;
            route.Name = model.Name;
            route.DateVisit = model.DateVisit; 
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

                var routeUser = context.RouteUsers.Where(rec =>
                rec.RouteId == model.Id.Value).ToList();
                // удаляем те, которых нет в модели
                context.RouteUsers.RemoveRange(routeUser.Where(rec =>
                !model.RouteUsers.ContainsKey(rec.UserId)).ToList());
                context.SaveChanges();

                foreach (var updateReserve in routeReserve)
                {
                    model.RouteReverces.Remove(updateReserve.ReserveId);
                }

                foreach (var updateUser in routeUser)
                {
                    model.RouteUsers.Remove(updateUser.UserId);
                }
            }

            foreach (var routeUser in model.RouteUsers)
            {
                context.RouteUsers.Add(new RouteUser
                {
                    UserId = routeUser.Key,
                    RouteId = route.Id
                });
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
