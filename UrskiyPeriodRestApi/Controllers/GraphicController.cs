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
    public class GraphicController : Controller
    {
        private readonly GraphicLogic logic;

        public GraphicController(GraphicLogic graphicLogic)
        {
            logic = graphicLogic;
        }

        [HttpGet]
        public GraphicViewModel[] GetGraphic(int userId) 
        {
            return new GraphicViewModel[]
            {
                logic.GetGraphicByCount(userId),
                logic.GetGraphicByPrice(userId)
            };
        } 
    }
}
