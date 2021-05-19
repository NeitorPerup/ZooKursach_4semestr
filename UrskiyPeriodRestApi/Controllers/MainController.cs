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
    public class MainController : Controller
    {
        private readonly RouteLogic _route;

        private readonly ReserveLogic _reserve;

        public MainController(RouteLogic route, ReserveLogic reserve)
        {
            _route = route;
            _reserve = reserve;
        }

        [HttpGet]
        public List<RouteViewModel> GetRoutes(int userId) => _route.Read(new RouteBindingModel { UserId = userId });

        [HttpGet]
        public List<ReserveViewModel> GetReserveList() => _reserve.Read(null)?.ToList();

        [HttpGet]
        public ReserveViewModel GetReserve(int id) => _reserve.Read(new ReserveBindingModel { Id = id})?[0];

        [HttpGet]
        public RouteViewModel GetRoute(int id) => _route.Read(new RouteBindingModel { Id = id })?[0];

        [HttpPost]
        public void CreateRoute(RouteBindingModel model) => _route.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteRoute(RouteBindingModel model) => _route.Delete(model);
    }
}
