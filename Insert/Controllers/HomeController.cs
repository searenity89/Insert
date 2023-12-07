using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Insert.Db;
using Insert.Services.Interfaces;
using Newtonsoft.Json;

namespace Insert.Controllers
{
    public class HomeController : Controller
    {
        public IMidRateService _midRateService;
        public IRateService _rateService;

        public HomeController(IMidRateService midRateService, IRateService rateService)
        {
            _midRateService = midRateService;
            _rateService = rateService;
        }

        public async Task<ActionResult> TableA()
        {
            var midRates = await _midRateService.GetMidRates(Models.TableType.A);
            return View("MidRateTable", midRates);
        }

        public async Task<ActionResult> TableB()
        {
            var midRates = await _midRateService.GetMidRates(Models.TableType.B);
            return View("MidRateTable", midRates);
        }

        public async Task<ActionResult> TableC()
        {
            var rates = await _rateService.GetRates(Models.TableType.C);
            return View("RateTable", rates);
        }
    }
}