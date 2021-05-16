using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodBusinessLogic.BusinessLogics
{
    public class ReserveLogic
    {
        private readonly IReserveStorage _reserveStorage;

        public ReserveLogic(IReserveStorage routeStorage)
        {
            _reserveStorage = routeStorage;
        }

        public List<ReserveViewModel> Read(ReserveBindingModel model)
        {
            if (model == null)
            {
                return _reserveStorage.GetFullList();
            }
            if (model.Id.HasValue || model.Name != null)
            {
                return new List<ReserveViewModel> { _reserveStorage.GetElement(model) };
            }
            return _reserveStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ReserveBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _reserveStorage.Update(model);
            }
            else
            {
                _reserveStorage.Insert(model);
            }
        }

        public void Delete(ReserveBindingModel model)
        {
            var element = _reserveStorage.GetElement(new ReserveBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Заповедник найден");
            }
            _reserveStorage.Delete(model);
        }
    }
}
