using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UrskiyPeriodBusinessLogic.BusinessLogics;
using UrskiyPeriodBusinessLogic.BindingModels;
using UrskiyPeriodBusinessLogic.ViewModels;

namespace UrskiyPeriodRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserLogic _logic;

        public UserController(UserLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public UserViewModel Login(string login, string password) => _logic.Read(new UserBindingModel
            { Email = login, Login = login, Password = password })?[0];

        [HttpPost]
        public void Register(UserBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(UserBindingModel model) => _logic.CreateOrUpdate(model);
    }
}

