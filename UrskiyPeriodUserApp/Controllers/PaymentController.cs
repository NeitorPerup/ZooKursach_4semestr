using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodUserApp.Models;

namespace UrskiyPeriodUserApp.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult Index(int RouteId)
        {
            ViewBag.Route = APIUser.GetRequest<RouteViewModel>($"api/main/GetRoute?id={RouteId}");
            ViewBag.Reserve = new MultiSelectList(APIUser.GetRequest<List<ReserveViewModel>>
                ($"api/main/GetFilteredReserveList?id={RouteId}"), "Id", "Name", "Price");
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("ReserveId", "Sum")] PaymentBindingModel model)
        {
            model.UserId = Program.User.Id;
            APIUser.PostRequest("api/payment/Pay", model);
            return Redirect("~/Home/Index");
        }

        public decimal CalcSum(int Id)
        {
            return APIUser.GetRequest<ReserveViewModel>($"api/main/GetReserve?id={Id}").Price;
        }
    }
}
