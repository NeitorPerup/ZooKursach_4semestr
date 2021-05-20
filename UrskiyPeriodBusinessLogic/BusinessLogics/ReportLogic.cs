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

        public List<RouteViewModel> GetRoutes(ReportBindingModel model)
        {
            return _routeStorage.GetFilteredByDateList(new RouteBindingModel
            {
                UserId = model.UserId,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            }).ToList();
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
                Routes = _routeStorage.GetFilteredByPickList(new RouteBindingModel
                {
                    PickedRoutes = model.RouteId
                })
            }) ;
        }
        /// <summary>
        /// Сохранение заповедников с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveReservesToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new Info
            {
                FileName = model.FileName,
                Title = "Список заповедников",
                Routes = _routeStorage.GetFilteredByPickList(new RouteBindingModel
                {
                    PickedRoutes = model.RouteId
                })
            });
        }

        /// <summary>
        /// Сохранение маршрутов в Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveRoutesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список маршрутов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Routes = GetRoutes(model)
            });
        }
    }
}
