using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodBusinessLogic.BusinessLogics
{
    public class CostItemLogic
    {
        private readonly ICostItemStorage _costItemStorage;

        public CostItemLogic(ICostItemStorage routeStorage)
        {
            _costItemStorage = routeStorage;
        }

        public void CreateOrUpdate(CostItemBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _costItemStorage.Update(model);
            }
            else
            {
                _costItemStorage.Insert(model);
            }
        }

        public void Delete(CostItemBindingModel model)
        {
            var element = _costItemStorage.GetElement(new CostItemBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Не найдено");
            }
            _costItemStorage.Delete(model);
        }

        public int Count()
        {
            return _costItemStorage.Count();
        }

        public CostItemViewModel GetElement(CostItemBindingModel model)
        {
            if (model == null)
                return null;
            return _costItemStorage.GetElement(model);
        }
    }
}
