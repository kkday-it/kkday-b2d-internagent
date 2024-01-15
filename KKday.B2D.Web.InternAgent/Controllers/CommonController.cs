using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;
using KKday.B2D.Web.InternAgent.Proxy;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KKday.B2D.Web.InternAgent.Controllers
{
    public class CommonController : Controller
    {
        // GET: /<controller>/
        public IActionResult QueryMarkgetingState(string id)
        {
            var commonProxy = HttpContext.RequestServices.GetService<CommonProxy>();
            var locale = LocaleMapHelper.RfcToKKday(id);
            var result = commonProxy.GetState(locale);
            var states = JsonSerializer.Deserialize<MarketingStateModel>(result);

            return Json(states);
        }

        public IActionResult QueryCountryInfo(string id)
        {
            var commonProxy = HttpContext.RequestServices.GetService<CommonProxy>();
            var locale = LocaleMapHelper.RfcToKKday(id);
            var result = commonProxy.GetCountryInfot(locale);
            var countries = JsonSerializer.Deserialize<CountryCityRespModel>(result);

            return Json(countries);
        }
    }
}

