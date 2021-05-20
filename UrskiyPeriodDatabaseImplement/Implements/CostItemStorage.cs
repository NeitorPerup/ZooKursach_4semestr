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
    public class CostItemStorage : ICostItemStorage
    {
        public CostItemViewModel GetElement(CostItemBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var costItem = context.CostItem.Include(x => x.CostItemRoute).ThenInclude(x => x.Route)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return costItem != null ? new CostItemViewModel 
                { 
                    Id = costItem.Id,
                    Name = costItem.Name,
                    Sum = costItem.Sum,
                    CostItemRoute = costItem.CostItemRoute.ToDictionary(x => x.RouteId, x => x.Route.Name)
                } : null;
            }
        }

        public void Insert(CostItemBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CostItem cost = CreateModel(new CostItem(), model);
                        context.CostItem.Add(cost);
                        context.SaveChanges();
                        CreateModel(cost, model, context);
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

        public void Update(CostItemBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var costItem = context.CostItem.FirstOrDefault(rec => rec.Id == model.Id);
                        if (costItem == null)
                        {
                            throw new Exception("Не найдено");
                        }
                        CreateModel(costItem, model, context);
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

        public void Delete(CostItemBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.CostItem.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Не найдено");
                }
                context.CostItem.Remove(user);
                context.SaveChanges();
            }
        }

        private CostItem CreateModel(CostItem costItem, CostItemBindingModel model)
        {
            costItem.Sum = model.Sum;
            costItem.Name = model.Name;
            return costItem;
        }

        private CostItem CreateModel(CostItem costItem, CostItemBindingModel model, UrskiyPeriodDatabase context)
        {
            costItem = CreateModel(costItem, model);

            if (model.Id.HasValue)
            {
                var routeCost = context.CostItemRoutes.Where(rec =>
                rec.CostItemId == model.Id.Value).ToList();
                // удаляем те, которых нет в модели
                context.CostItemRoutes.RemoveRange(routeCost.Where(rec =>
                !model.CostItemRoute.ContainsKey(rec.RouteId)).ToList());
                context.SaveChanges();

                foreach (var Reserve in routeCost)
                {
                    model.CostItemRoute.Remove(Reserve.RouteId);
                }
            }

            foreach (var cost in model.CostItemRoute)
            {
                context.CostItemRoutes.Add(new CostItemRoute
                {
                    CostItemId = costItem.Id,
                    RouteId = cost.Key
                });
            }
            context.SaveChanges();
            return costItem;
        }

        public int Count()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.CostItem.Count();
            }
        }
    }
}
