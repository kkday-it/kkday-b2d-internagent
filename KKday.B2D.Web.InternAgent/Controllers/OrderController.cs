using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
                Console.WriteLine($"Order Query Req => {JsonSerializer.Serialize(req)}");
                req.order_Sdate = req.order_Sdate ?? DateTime.Today.AddMonths(-1).ToString("yyyy-MM-dd");
                var result = orderProxy.QueryOrders(req);
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

        public IActionResult QueryVoucher(string id)
        {
            try
            {
                var voucherProxy = HttpContext.RequestServices.GetService<VoucherProxy>();
                var req = new VoucherListReqModel
                {
                     order_no = id
                };
                var vouchers = voucherProxy.QueryVoucherList(req);
                  
                return Json(vouchers);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"message={ex.Message},stack_trace={ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
            }
        }

        public IActionResult Download(string id, string fid)
        { 
            var jsonData = new Dictionary<string, object>();  

            try
            {
                var voucherProxy = HttpContext.RequestServices.GetService<VoucherProxy>();
                var req = new VoucherDownloadReqModel
                {
                     order_no = id,
                     order_file_id = fid
                };

                var data = voucherProxy.Download(req);
                if (data.result == "00") {
                    if (string.IsNullOrEmpty(data.pincode))
                    {
                        jsonData.Add("status", true);
                        jsonData.Add("is_swipe", false);
                        jsonData.Add("filename", $"{data.file.file_name}");
                        jsonData.Add("mimetype", "application/octet-stream");
                        jsonData.Add("content", data.file.encode_str ?? string.Empty);
                    }
                    else
                    {
                        jsonData.Add("status", true);
                        jsonData.Add("is_swipe", true);
                        jsonData.Add("pincode", data.pincode);
                        jsonData.Add("token_url", data.token_url);
                    }
                }
                else
                {
                    throw new InvalidOperationException(data.result_msg);
                }
            }
            catch (Exception ex)
            {
                jsonData.Clear();
                jsonData.Add("status", false);
                jsonData.Add("msg", ex.Message);
            }

            return Json(jsonData);
        }

        public IActionResult Cancel([FromBody] CancelReqModel req)
        {
            try
            { 
                var orderProxy = HttpContext.RequestServices.GetService<OrderProxy>();

                orderProxy.CancelOrder(req);
                
                return Json(new { status = true });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"message={ex.Message},stack_trace={ex.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
    }
}

