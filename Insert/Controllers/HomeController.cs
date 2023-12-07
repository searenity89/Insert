using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Insert.Services.Interfaces;
using Newtonsoft.Json;

namespace Insert.Controllers
{
    public class HomeController : Controller
    {
        public IMidRateService _midRateService;

        public HomeController(IMidRateService midRateService)
        {
            _midRateService = midRateService;
        }

        public ActionResult TableA()
        {
            var midRates = _midRateService.GetMidRates(Models.TableType.A);
            return View("MidRateTable", midRates);
        }

        public ActionResult TableB()
        {
            var midRates = _midRateService.GetMidRates(Models.TableType.B);
            return View("MidRateTable", midRates);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}