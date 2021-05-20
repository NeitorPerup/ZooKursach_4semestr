using System;
using System.Collections.Generic;
using System.Linq;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.Interfaces;

namespace UrskiyPeriodBusinessLogic.BusinessLogics
{
    public class GraphicLogic
    {
        private readonly IRouteStorage storage;

        public GraphicLogic(IRouteStorage route)
        {
            storage = route;
        }

        public GraphicViewModel GetGraphicByPrice(int userId)
        {
            return new GraphicViewModel
            {
                Title = "Диаграмма стоимости маршрутов",
                ColumnName = "Маршрут",
                ValueName = "Стоимость маршрута",
                Data = GetRoute(userId).Select(rec => new Tuple<string, int>(rec.Name, Convert.ToInt32(rec.Cost))).ToList()
            };
        }

        public GraphicViewModel GetGraphicByCount(int userId)
        {
            return new GraphicViewModel
            {
                Title = "Диаграмма количества маршрутов",
                ColumnName = "Маршрут",
                ValueName = "Количество маршрутов",
                Data = GetRoute(userId).Select(rec => new Tuple<string, int>(rec.Name, rec.Count)).ToList()
            };
        }

        private List<RouteViewModel> GetRoute(int userId)
        {
            return storage.GetFilteredList(new RouteBindingModel { UserId = userId});
        }
    }
}
