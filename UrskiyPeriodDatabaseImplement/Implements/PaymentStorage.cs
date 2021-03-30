using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodDatabaseImplement.Models;
using System.Linq;

namespace UrskiyPeriodDatabaseImplement.Implements
{
    public class PaymentStorage : IPaymentStorage
    {
        public PaymentViewModel GetElement(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new UrskiyPeriodDatabase())
            {
                var route = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);
                return route != null ? CreateModel(route) : null;
            }
        }

        public List<PaymentViewModel> GetFilteredList(PaymentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Payments.Where(rec => rec.PaymentDate == model.PaymentDate).Select(CreateModel).ToList();
            }
        }

        public List<PaymentViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Payments.Select(CreateModel).ToList();
            }
        }

        public void Insert(PaymentBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                context.Payments.Add(CreateModel(new Payment(), model));
                context.SaveChanges();
            }
        }

        public void Update(PaymentBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Не найдено");
                }
                CreateModel(user, model);
                context.SaveChanges();
            }
        }

        public void Delete(PaymentBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.Payments.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Не найдено");
                }
                context.Payments.Remove(user);
                context.SaveChanges();
            }
        }

        private PaymentViewModel CreateModel(Payment payment)
        {
            return new PaymentViewModel
            {
                Id = payment.Id,
                Sum = payment.Sum,
                PaymentDate = payment.PaymentDate,
                RouteId = payment.RouteId
            };
        }

        private Payment CreateModel(Payment payment, PaymentBindingModel model)
        {
            payment.Sum = model.Sum;
            payment.PaymentDate = model.PaymentDate;
            payment.RouteId = model.RouteId;
            return payment;
        }
    }
}
