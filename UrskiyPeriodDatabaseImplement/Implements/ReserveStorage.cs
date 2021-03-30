using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodDatabaseImplement.Models;
using System.Linq;

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
                var route = context.Reserves.FirstOrDefault(rec => rec.Id == model.Id);
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
                return context.Reserves.Where(rec => rec.Price == model.Price).Select(CreateModel).ToList();
            }
        }

        public List<ReserveViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Reserves.Select(CreateModel).ToList();
            }
        }

        public void Insert(ReserveBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
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
                Price = reserve.Price
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
