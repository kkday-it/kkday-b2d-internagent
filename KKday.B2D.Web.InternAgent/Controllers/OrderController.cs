using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json; 
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;
using KKday.B2D.Web.InternAgent.Proxy;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KKday.B2D.Web.InternAgent.Controllers
{
    public class OrderController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Query([FromBody]QuerytOrdersReqModel req)
        {
            try
            {
                var orderProxy = HttpContext.RequestServices.GetService<OrderProxy>(); 
                // Console.WriteLine($"Order Query Req => {JsonSerializer.Serialize(req)}");

                var result = orderProxy.GetOrders(req);
                // Console.WriteLine($"Order Query Resp => {result}");

                var orders = JsonSerializer.Deserialize<QuerytOrdersRespModel>(result);

                return Json(orders);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"message={ex.Message},stack_trace={ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
    }
}

