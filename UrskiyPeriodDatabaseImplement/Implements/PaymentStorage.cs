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
                var route = context.Payment.FirstOrDefault(rec => rec.Id == model.Id);
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
                return context.Payment.Where(rec => rec.Sum == model.Sum).Select(CreateModel).ToList();
            }
        }

        public List<PaymentViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Payment.Select(CreateModel).ToList();
            }
        }

        public void Insert(PaymentBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                context.Payment.Add(CreateModel(new Payment(), model));
                context.SaveChanges();
            }
        }

        public void Update(PaymentBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var payment = context.Payment.FirstOrDefault(rec => rec.Id == model.Id);
                if (payment == null)
                {
                    throw new Exception("Не найдено");
                }
                CreateModel(payment, model);
                context.SaveChanges();
            }
        }

        public void Delete(PaymentBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.Payment.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Не найдено");
                }
                context.Payment.Remove(user);
                context.SaveChanges();
            }
        }

        private PaymentViewModel CreateModel(Payment payment)
        {
            return new PaymentViewModel
            {
                Id = payment.Id,
                Sum = payment.Sum,
                ReserveId = payment.ReserveId,
                UserId = payment.UserId
            };
        }

        private Payment CreateModel(Payment payment, PaymentBindingModel model)
        {
            payment.Sum = model.Sum.Value;
            payment.ReserveId = model.ReserveId;
            payment.UserId = model.UserId;
            return payment;
        }
    }
}
