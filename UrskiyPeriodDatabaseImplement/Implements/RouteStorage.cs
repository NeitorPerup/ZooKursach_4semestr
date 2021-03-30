using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodDatabaseImplement.Models;
using System.Linq;

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
                var route = context.Routes.FirstOrDefault(rec => rec.Id == model.Id);
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
                return context.Routes.Where(rec => rec.DateVisit == model.DateVisit).Select(CreateModel).ToList();
            }
        }

        public List<RouteViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Routes.Select(CreateModel).ToList();
            }
        }

        public void Insert(RouteBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                context.Routes.Add(CreateModel(new Route(), model));
                context.SaveChanges();
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
                DateVisit = route.DateVisit
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
    }
}
