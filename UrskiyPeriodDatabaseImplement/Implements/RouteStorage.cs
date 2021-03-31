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
                var route = context.Routes.Include(rec => rec. RouteUser).ThenInclude(rec => rec.User).FirstOrDefault(rec => rec.Id == model.Id);
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
                return context.Routes.Include(rec => rec.RouteUser).ThenInclude(rec => rec.User).ToList()
                    .Select(CreateModel).ToList();
            }
        }

        public List<RouteViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Include(rec => rec.RouteUser).ThenInclude(rec => rec.User).Select(CreateModel).ToList();
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
                var user = context.Routes.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Маршрут не найден");
                }
                CreateModel(user, model);
                context.SaveChanges();
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
                //RouteReverces = route.RouteReserve.ToDictionary(x => x.ReserveId, x => x.Reserve.Name)
                RouteReverces = null
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
            
            foreach (var routeUser in model.RouteUsers)
            {
                context.RouteUsers.Add(new RouteUser
                {
                    UserId = routeUser.Key,
                    RouteId = route.Id
                });
            }
            context.SaveChanges();
            return route;
        }
    }
}
