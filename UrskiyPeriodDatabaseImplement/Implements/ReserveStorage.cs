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
    public class ReserveStorage : IReserveStorage
    {
        public ReserveViewModel GetElement(ReserveBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new UrskiyPeriodDatabase())
            {
                var route = context.Reserves.Include(x => x.Payment)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return route != null ? CreateModel(route) : null;
            }
        }

        public List<ReserveViewModel> GetFilteredList(ReserveBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Reserves.Include(x => x.Payment)
                    .Where(rec => rec.RouteReserve.Select(x => x.RouteId).Contains(model.RouteId)).Select(CreateModel).ToList();
            }
        }

        public List<ReserveViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Reserves.Include(x => x.Payment).Select(CreateModel).ToList();
            }
        }

        public void Insert(ReserveBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                if (context.Reserves.FirstOrDefault(rec => rec.Name == model.Name) != null)
                    return;
                context.Reserves.Add(CreateModel(new Reserve(), model));
                context.SaveChanges();
            }
        }

        public void Update(ReserveBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.Reserves.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Заповедник не найден");
                }
                CreateModel(user, model);
                context.SaveChanges();
            }
        }

        public void Delete(ReserveBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.Reserves.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Заповедник не найден");
                }
                context.Reserves.Remove(user);
                context.SaveChanges();
            }
        }

        private ReserveViewModel CreateModel(Reserve reserve)
        {
            return new ReserveViewModel
            {
                Id = reserve.Id,
                Name = reserve.Name,
                Price = reserve.Price,
                PriceToPay = reserve.Price - reserve.Payment.Sum(x => x.Sum)
            };
        }

        private Reserve CreateModel(Reserve reserve, ReserveBindingModel model)
        {
            reserve.Name = model.Name;
            reserve.Price = model.Price;
            return reserve;
        }
    }
}
