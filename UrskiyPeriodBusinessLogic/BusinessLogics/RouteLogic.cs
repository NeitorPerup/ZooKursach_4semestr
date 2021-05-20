using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodBusinessLogic.BusinessLogics
{
    public class RouteLogic
    {
        private readonly IRouteStorage _routeStorage;

        public RouteLogic(IRouteStorage routeStorage)
        {
            _routeStorage = routeStorage;
        }

        public List<RouteViewModel> Read(RouteBindingModel model)
        {
            if (model == null)
            {
                return _routeStorage.GetFullList();
            }
            if (model.Id.HasValue || model.Name != null)
            {
                return new List<RouteViewModel> { _routeStorage.GetElement(model) };
            }
            if (model.DateFrom.HasValue && model.DateTo.HasValue && model.UserId.HasValue && model.PickedRoutes == null)
            {
                return _routeStorage.GetFilteredByDateList(model);
            }
            if (model.PickedRoutes != null && !model.DateFrom.HasValue)
            {
                return _routeStorage.GetFilteredByPickList(model);
            }
            return _routeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(RouteBindingModel model)
        {            
            if (model.Id.HasValue)
            {
                _routeStorage.Update(model);
            }
            else
            {
                var element = _routeStorage.GetElement(new RouteBindingModel
                {
                    Name = model.Name
                });
                if (element != null && element.Id != model.Id)
                {
                    throw new Exception("Уже есть маршрут с таким названием");
                }
                _routeStorage.Insert(model);
            }
        }

        public void Delete(RouteBindingModel model)
        {
            var element = _routeStorage.GetElement(new RouteBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Маршрут не найден");
            }
            else
            {
                _routeStorage.Delete(model);
            }
        }
    }
}
