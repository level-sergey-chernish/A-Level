using Square.Logic.Models;
using Square.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Square.Controllers
{
    public class DecisionController : Controller
    {
        // GET: Decision
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Input model)
        {
            ICalculateService service = new CalculateServiceMock();

            service.Calculate(model);

            return View(model);
        }
    }
}