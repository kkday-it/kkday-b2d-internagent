using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;
using KKday.B2D.Web.InternAgent.Proxy;
using Microsoft.AspNetCore.Mvc; 

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KKday.B2D.Web.InternAgent.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        // [Route("{culture}/{controller}/{prod_no?}")] 
        public IActionResult Index(Int64 prod_no)
        {
            return View();
        }

        public IActionResult GetData(Int64 id)
        {
            try
            {
                var prodProxy = HttpContext.RequestServices.GetService<ProductProxy>();

                // Check current cultureinfo
                var locale = LocaleMapHelper.RfcToKKday(CultureInfo.CurrentCulture.ToString());

                var result = prodProxy.GetProduct(new ProductReqModel()
                {
                    prod_no = id.ToString(),
                    locale = locale,
                    state = Website.Instance.Marketing // Default country (eg.TW)
                });

                var prod = JsonSerializer.Deserialize<ProductRespModel>(result);

                return Json(prod);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"message={ex.Message},stack_trace={ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        } 
        
        public IActionResult GetPackage([FromBody] PackageReqModel req)
        {
            try
            {
                var prodProxy = HttpContext.RequestServices.GetService<ProductProxy>();

                // Check current cultureinfo
                var locale = LocaleMapHelper.RfcToKKday(CultureInfo.CurrentCulture.ToString());

                req.locale = locale;
                req.state = Website.Instance.Marketing; // Default country (eg.TW)

                var result = prodProxy.GetPackage(req);

                Console.WriteLine($"pkg => {result}");
                var pkg = JsonSerializer.Deserialize<PackageRespModel>(result);
                return Json(pkg);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"message={ex.Message},stack_trace={ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        public IActionResult GetAllotment([FromBody] AllotmentReqModel req)
        {
            try
            {
                var prodProxy = HttpContext.RequestServices.GetService<ProductProxy>();

                // Check current cultureinfo
                var locale = LocaleMapHelper.RfcToKKday(CultureInfo.CurrentCulture.ToString());

                req.locale = locale;
                req.state = Website.Instance.Marketing; // Default country (eg.TW)

                var result = prodProxy.GetAllotment(req);
                Console.WriteLine($"allotment => {JsonSerializer.Serialize(result)}");

                return Json(result);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"message={ex.Message},stack_trace={ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}

