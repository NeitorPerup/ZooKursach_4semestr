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
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (Program.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIUser.GetRequest<List<RouteViewModel>>($"api/main/GetRoutes?userId={Program.User.Id}"));
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.User);
        }

        [HttpPost]
        public void Privacy(string email, string password, string login)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(login))
            {
                Program.User.Login = login;
                Program.User.Email = email;
                Program.User.Password = password;
                APIUser.PostRequest("api/User/updatedata", new UserBindingModel
                {
                    Id = Program.User.Id,
                    Login = login,
                    Email = email,
                    Password = password
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.User = APIUser.GetRequest<UserViewModel>($"api/User/login?login={login}&password={password }");

                if (Program.User == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public void Register(string login, string password, string email)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password)
            && !string.IsNullOrEmpty(email))
            {
                APIUser.PostRequest("api/user/register", new UserBindingModel
                {
                    Login = login,
                    Email = email,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и электронную почту");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Reserves = new MultiSelectList(APIUser.GetRequest<List<ReserveViewModel>>($"api/main/GetReserveList"), 
                "Id", "Name", "Price");
            return View(new RouteViewModel());
        }
        [HttpPost]
        public void Create(DateTime datepicker, [Bind("ReserveId", "Name")] RouteViewModel model)
        {
            List<ReserveViewModel> reserves = model.ReserveId.
                Select(x => APIUser.GetRequest<ReserveViewModel>($"api/main/GetReserve?id={x}")).ToList();
            if (string.IsNullOrEmpty(model.Name) || datepicker == null || model.ReserveId.Count == 0)
            {
                return;
            }
            APIUser.PostRequest("api/main/CreateRoute", new RouteBindingModel
            {
                UserId = Program.User.Id,
                Cost = reserves.Sum(x => x.Price),
                Count = reserves.Count,
                Name = model.Name,
                DateVisit = datepicker,
                RouteReverces = reserves.ToDictionary(x => x.Id, x => x.Name)
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public void Delete(int Id)
        {
            APIUser.PostRequest($"api/main/deleteroute", new RouteBindingModel
            {
                Id = Id
            });
            Response.Redirect("../Index");
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            var reserves = new MultiSelectList(APIUser.GetRequest<List<ReserveViewModel>>($"api/main/GetReserveList"),
                "Id", "Name", "Price");
            var route = APIUser.GetRequest<RouteViewModel>($"api/main/GetRoute?id={Id}");
            foreach (var elem in reserves)
            {
                if (route.ReserveId.Contains(Convert.ToInt32(elem.Value)))
                {
                    elem.Selected = true;
                }
            }
            ViewBag.Reserves = reserves;
            return View(route);
        }

        [HttpPost]
        public void Update(DateTime datepicker, [Bind("ReserveId", "Name", "Id")] RouteViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || datepicker == null || model.ReserveId == null || model.ReserveId.Count == 0)
            {
                return;
            }
            List<ReserveViewModel> reserves = model.ReserveId.
                Select(x => APIUser.GetRequest<ReserveViewModel>($"api/main/GetReserve?id={x}")).ToList();
            
            APIUser.PostRequest("api/main/CreateRoute", new RouteBindingModel
            {
                Id = model.Id,
                UserId = Program.User.Id,
                Cost = reserves.Sum(x => x.Price),
                Count = reserves.Count,
                Name = model.Name,
                DateVisit = datepicker,
                RouteReverces = reserves.ToDictionary(x => x.Id, x => x.Name)
            });
            Response.Redirect("../Index");
        }
    }
}
