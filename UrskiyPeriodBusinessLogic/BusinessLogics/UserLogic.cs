using System;
using System.Collections.Generic;
using System.Text;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodBusinessLogic.BusinessLogics
{
    public class UserLogic
    {
        private readonly IUserStorage _userStorage;

        public UserLogic(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public List<UserViewModel> Read(UserBindingModel model)
        {
            if (model == null)
            {
                return _userStorage.GetFullList();
            }
            if (model.Id.HasValue || model.Email != null || model.Login != null)
            {
                return new List<UserViewModel> { _userStorage.GetElement(model) };
            }
            return _userStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(UserBindingModel model)
        {
            var element = _userStorage.GetElement(new UserBindingModel
            {
                Email = model.Email,
                Login = model.Login
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть учётная запись с данной электронной почтой или логином");
            }
            if (model.Id.HasValue)
            {
                _userStorage.Update(model);
            }
            else
            {
                _userStorage.Insert(model);
            }
        }

        public void Delete(UserBindingModel model)
        {
            var element = _userStorage.GetElement(new UserBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Клиент не найден");
            }
            _userStorage.Delete(model);
        }
    }
}
