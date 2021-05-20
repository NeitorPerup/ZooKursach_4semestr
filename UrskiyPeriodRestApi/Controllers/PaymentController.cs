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
    public class PaymentController : Controller
    {
        private readonly PaymentLogic _payment;

        public PaymentController(PaymentLogic payment)
        {
            _payment = payment;
        }

        [HttpPost]
        public void Pay(PaymentBindingModel model) => _payment.CreateOrUpdate(model);
    }
}
