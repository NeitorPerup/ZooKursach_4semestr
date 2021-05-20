using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace UrskiyPeriodUserApp.Controllers
{
    public class GraphicController : Controller
    {
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    if (Program.User == null)
        //    {
        //        return Redirect("~/Home/Enter");
        //    }
        //    ViewBag.Routes = new SelectList(APIUser.GetRequest<List<RouteViewModel>>
        //        ($"api/main/GetRoutes?userId={Program.User.Id}"), "Id", "Name");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            if (Program.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            //ViewBag.Routes = new SelectList(APIUser.GetRequest<List<RouteViewModel>>
            //    ($"api/main/GetRoutes?userId={Program.User.Id}"), "Id", "Name");
            var model = APIUser.GetRequest<GraphicViewModel[]>($"api/graphic/GetGraphic?userId={Program.User.Id}");
            return View(model);
        }
    }
}
