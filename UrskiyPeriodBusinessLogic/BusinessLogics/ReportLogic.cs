using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.Interfaces;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.HelperModels;
using UrskiyPeriodBusinessLogic.ViewModels;
using System.Linq;

namespace UrskiyPeriodBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IUserStorage _userStorage;

        private readonly IRouteStorage _routeStorage;

        private readonly IReserveStorage _reserveStorage;

        public ReportLogic(IUserStorage userStorage, IRouteStorage
        routeStorage, IReserveStorage reserveStorage)
        {
            _userStorage = userStorage;
            _routeStorage = routeStorage;
            _reserveStorage = reserveStorage;
        }

        public List<ReportRouteViewModel> GetRoutes(ReportBindingModel model)
        {
            return _routeStorage.GetFilteredList(new RouteBindingModel
            {
                UserId = model.UserId,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportRouteViewModel
            {
                DateVisit = x.DateVisit,
                Name = x.Name,
                Count = x.Count,
                Cost = x.Cost,
                Reserves = _reserveStorage.GetFilteredList(new ReserveBindingModel { RouteId = x.Id})
            })
            .ToList();
        }
        /// <summary>
        /// Сохранение изделия в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveRoutesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new Info
            {
                FileName = model.FileName,
                Title = "Список заповедников",
                Routes = model.Routes
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveReservesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new Info
            {
                FileName = model.FileName,
                Title = "Список заповедников",
                Routes = model.Routes
            });
        }
    }
}
