using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodUserApp.Models;

namespace UrskiyPeriodUserApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public ReportController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            if (Program.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.RouteId = new MultiSelectList(APIUser.GetRequest<List<RouteViewModel>>
                ($"api/main/getroutes?UserId={Program.User.Id}"), "Id", "Name");
            return View();
        }

        public IActionResult Email()
        {
            if (Program.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        [HttpPost]
        public IActionResult ReportDoc([Bind("RouteId")] ReportBindingModel model)
        {
            model.FileName = @"..\UrskiyPeriodUserAPP\wwwroot\report\Report.doc";
            APIUser.PostRequest("api/report/MakeDoc", model);

            var fileName = "Report.doc";
            var filePath = _environment.WebRootPath + @"\report\" + fileName;
            return PhysicalFile(filePath, "application/doc", fileName);
        }

        [HttpPost]
        public IActionResult ReportXls([Bind("RouteId")] ReportBindingModel model)
        {
            model.FileName = @"..\UrskiyPeriodUserAPP\wwwroot\report\Report.xls";
            APIUser.PostRequest("api/report/MakeExcel", model);

            var fileName = "Report.xls";
            var filePath = _environment.WebRootPath + @"\report\" + fileName;
            return PhysicalFile(filePath, "application/xls", fileName);
        }

        [HttpPost]
        public IActionResult ReportPdf([Bind("DateTo,DateFrom")] ReportBindingModel model)
        {
            model.UserId = Program.User.Id;
            model.FileName = @"..\UrskiyPeriodUserAPP\wwwroot\report\Report.pdf";
            APIUser.PostRequest("api/report/MakePdf", model);

            var fileName = "Report.pdf";
            var filePath = _environment.WebRootPath + @"\report\" + fileName;
            return PhysicalFile(filePath, "application/pdf", fileName);
        }

        [HttpPost]
        public IActionResult SendMail([Bind("DateTo,DateFrom")] ReportBindingModel model)
        {
            model.UserId = Program.User.Id;
            model.UserEmail = Program.User.Email;
            model.FileName = @"..\UrskiyPeriodUserAPP\wwwroot\report\Report.pdf";
            APIUser.PostRequest("api/report/SendMail", model);
            return Redirect("~/Home/Index");
        }
    }
}
