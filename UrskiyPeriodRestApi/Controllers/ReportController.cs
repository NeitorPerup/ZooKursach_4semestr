using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly ReportLogic _report;

        private readonly RouteLogic _route;

        public ReportController(ReportLogic report, RouteLogic route)
        {
            _report = report;
            _route = route;
        }

        [HttpPost]
        public void MakeDoc(ReportBindingModel model) => _report.SaveRoutesToWordFile(model);

        [HttpPost]
        public void MakeExcel(ReportBindingModel model) => _report.SaveReservesToExcelFile(model);

        [HttpGet]
        public ReportBindingModel GetRoutes(int UserId) 
        {
            return new ReportBindingModel
            {
                UserId = UserId,
                RouteId = _route.Read(new RouteBindingModel { UserId = UserId }).Select(x => x.Id).ToList()
            };
        } 
    }
}
