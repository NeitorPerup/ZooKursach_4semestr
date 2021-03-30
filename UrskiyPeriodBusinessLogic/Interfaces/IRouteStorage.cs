using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodBusinessLogic.Interfaces
{
    public interface IRouteStorage
    {
        List<RouteViewModel> GetFullList();

        List<RouteViewModel> GetFilteredList(RouteBindingModel model);

        RouteViewModel GetElement(RouteBindingModel model);

        void Insert(RouteBindingModel model);

        void Update(RouteBindingModel model);

        void Delete(RouteBindingModel model);
    }
}
