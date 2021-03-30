using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodDatabaseImplement.Models;
using System.Linq;

namespace UrskiyPeriodDatabaseImplement.Implements
{
    public class UserStorage : IUserStorage
    {       
        public UserViewModel GetElement(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.Users.FirstOrDefault(rec => rec.Id == model.Id || rec.Email == model.Email);
                return user != null ? CreateModel(user) : null;
            }
        }

        public List<UserViewModel> GetFilteredList(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Users.Where(rec => rec.Login == model.Login).Select(CreateModel).ToList();
            }
        }

        public List<UserViewModel> GetFullList()
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                return context.Users.Select(CreateModel).ToList();
            }
        }

        public void Insert(UserBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                context.Users.Add(CreateModel(new User(), model));
                context.SaveChanges();
            }
        }

        public void Update(UserBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(user, model);
                context.SaveChanges();
            }
        }

        public void Delete(UserBindingModel model)
        {
            using (var context = new UrskiyPeriodDatabase())
            {
                var user = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Клиент не найден");
                }
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        private UserViewModel CreateModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Login = user.Login
            };
        }

        private User CreateModel(User user, UserBindingModel model)
        {
            user.Email = model.Email;
            user.Login = model.Login;
            user.Password = model.Password;
            return user;
        }
    }
}
