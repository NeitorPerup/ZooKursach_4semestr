using Microsoft.AspNetCore.Mvc;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodUserApp.Controllers
{
    public class GraphicController : Controller
    {
        public IActionResult Index()
        {
            if (Program.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            var model = APIUser.GetRequest<GraphicViewModel[]>($"api/graphic/GetGraphic?userId={Program.User.Id}");
            return View(model);
        }
    }
}
