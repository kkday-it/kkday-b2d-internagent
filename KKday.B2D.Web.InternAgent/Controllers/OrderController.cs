using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json; 
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;
using KKday.B2D.Web.InternAgent.Proxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KKday.B2D.Web.InternAgent.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHtmlLocalizer<ProductController> _localizer;

        public OrderController(IHtmlLocalizer<ProductController> localizer)
        {
            _localizer = localizer;
        }

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

        public IActionResult Detail(string id)
        {
            return View();
        }

        public IActionResult GetDetail(string id)
        {
            try
            {
                var prodProxy = HttpContext.RequestServices.GetService<ProductProxy>();
                var orderProxy = HttpContext.RequestServices.GetService<OrderProxy>();
                // Console.WriteLine($"Order Query Req => {JsonSerializer.Serialize(req)}");

                #region Order Detail

                var order_result = orderProxy.GetOrderDetail(id);
                Console.WriteLine($"Order Query Resp => {order_result}");
                var dtl = JsonSerializer.Deserialize<OrderRespModel>(order_result);

                #endregion Order Detail

                /////////

                #region Product & Package Info

                if (dtl != null && dtl.prod_no > 0)
                {
                    // Check current cultureinfo
                    var locale = LocaleMapHelper.RfcToKKday(CultureInfo.CurrentCulture.ToString());

                    var prod_result = prodProxy.GetProduct(new ProductReqModel()
                    {
                        prod_no = dtl.prod_no.ToString(),
                        locale = locale,
                        state = Website.Instance.Marketing // Default country (eg.TW)
                    });
                    Console.WriteLine($"Product Query Resp => {prod_result}");
                    var pd_resp = JsonSerializer.Deserialize<ProductRespModel>(prod_result);


                    dtl.prod_name = pd_resp?.prod.prod_name ?? string.Empty;
                    dtl.prod_img_url = pd_resp?.prod.img_list.FirstOrDefault() ?? string.Empty;
                    dtl.pkg_name = pd_resp?.pkg.Where(pk => pk.pkg_no == dtl.pkg_no).FirstOrDefault()?.pkg_name ?? string.Empty;
                }

                #endregion Product & Package Info
            
                return Json(dtl);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"message={ex.Message},stack_trace={ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
    }
}

