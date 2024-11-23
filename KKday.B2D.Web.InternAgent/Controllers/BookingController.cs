using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks; 
using KKday.B2D.Web.InternAgent.Models.Model;
using Microsoft.AspNetCore.Mvc;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Proxy;
using System.Globalization;
using System.Net;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KKday.B2D.Web.InternAgent.Controllers
{
    public class BookingController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadData([FromBody] BookingFillReqModel req) // object req)
        {
            try
            {
                ViewData["prodOid"] = req.prod_no;

                var jsonData = new Dictionary<string, object>();

                // Get BookingField by prod_no
                var prodProxy = HttpContext.RequestServices.GetService<ProductProxy>();
                // Check current cultureinfo
                var locale = LocaleMapHelper.RfcToKKday(CultureInfo.CurrentCulture.ToString());

                var bookingfieldJson = prodProxy.GetBookingField(new BookingFieldReqModel()
                {
                    prod_no = req.prod_no,
                    locale = locale,
                    state = Website.Instance.Marketing,
                    pkg_no = req.pkg_no,
                    s_date = req.s_date
                });

                Console.WriteLine($"BookingField => {bookingfieldJson}");
                var jsonOptions = new JsonSerializerOptions()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString
                };
                var bookingfield = System.Text.Json.JsonSerializer.Deserialize<BookingField>(bookingfieldJson, jsonOptions);

                /////
                
                var bookingmodel = new B2DBookingEcModel();

                bookingmodel.guid = req.guid;
                bookingmodel.prod_no = req.prod_no.ToString();
                bookingmodel.item_no = req.item_no.ToString();
                bookingmodel.pkg_no = req.pkg_no.ToString();
                bookingmodel.state = Website.Instance.Marketing;
                bookingmodel.locale = LocaleMapHelper.RfcToKKday(CultureInfo.CurrentCulture.ToString());
                bookingmodel.skus = JsonSerializer.Deserialize<List<Sku>>(JsonSerializer.Serialize(req.skus));
                bookingmodel.pay_type = "01"; // Default is "01": Credit
                bookingmodel.total_price = req.total_price;
                bookingmodel.guide_lang = ""; 
                bookingmodel.s_date = req.s_date;
                bookingmodel.e_date = (req.e_date == null) ? req.s_date : req.e_date;
                bookingmodel.event_time = req.event_time;

                bookingmodel.buyer_country = "";
                bookingmodel.buyer_tel_country_code = "";
                bookingmodel.buyer_tel_number = "";

                var qty = req.skus.Sum(t => t.qty);

                // var cus_type = (bookingfield?.custom?.cus_type?.list_option.Where(x => x == "cus_01")?.ToList()?.Count > 0) ? "cus_01" : "cus_02";
                var has_psg = bookingfield?.custom?.cus_type?.list_option.Where(x => x == "cus_01" || x == "cus_02").Count() > 0 ? true : false;
                var allow_change_pax = req.extra.unit_code != "01" && has_psg ? true : false;

                bookingmodel.custom = new List<CustomBooking>();

                // Expand travelers
                if (has_psg)
                {
                    // Unit(01) is Traveler
                    if (req.extra.unit_code == "01")
                    {
                        for (var psg = 0; psg < qty; psg++)
                        {
                            bookingmodel.custom.Add(new CustomBooking() { cus_type = qty == 1 ? "cus_01" : "cus_02" });
                        }
                    }
                    // Other Unit
                    else bookingmodel.custom.Add(new CustomBooking() { cus_type = "cus_02" });
                }
                 
                if (bookingfield?.custom?.cus_type?.list_option.Where(x => x == "contact")?.ToList()?.Count > 0)
                {
                    bookingmodel.custom.Add(new CustomBooking() { cus_type = "contact" });
                }
                 
                if (bookingfield?.custom?.cus_type?.list_option.Where(x => x == "send")?.ToList()?.Count > 0)
                {
                    bookingmodel.custom.Add(new CustomBooking() { cus_type = "send" }); 
                }

                List<TrafficBooking> traffic = new List<TrafficBooking>();
                if (bookingfield?.traffics.Where(x => x.traffic_type.traffic_type_value == "flight").ToList()?.Count() > 0)
                {
                    traffic.Add(new TrafficBooking
                    {
                        traffic_type = "flight"
                    });
                    
                }
                if (bookingfield?.traffics.Where(x => x.traffic_type.traffic_type_value == "rentcar_01").ToList()?.Count() > 0)
                {
                    traffic.Add(new TrafficBooking
                    {
                        traffic_type = "rentcar_01"
                    });
                }
                if (bookingfield?.traffics.Where(x => x.traffic_type.traffic_type_value == "rentcar_02").ToList()?.Count() > 0)
                {
                    traffic.Add(new TrafficBooking
                    {
                        traffic_type = "rentcar_02"
                    });
                }
                if (bookingfield?.traffics.Where(x => x.traffic_type.traffic_type_value == "rentcar_03").ToList()?.Count() > 0)
                {
                    traffic.Add(new TrafficBooking
                    {
                        traffic_type = "rentcar_03"
                    });
                }

                if (bookingfield?.traffics.Where(x => x.traffic_type.traffic_type_value == "pickup_03").ToList()?.Count() > 0)
                {
                    traffic.Add(new TrafficBooking
                    {
                        traffic_type = "pickup_03"
                    });
                }
                if (bookingfield?.traffics.Where(x => x.traffic_type.traffic_type_value == "pickup_04").ToList()?.Count() > 0)
                {
                    traffic.Add(new TrafficBooking
                    {
                        traffic_type = "pickup_04"
                    });
                }
                if (bookingfield?.traffics.Where(x => x.traffic_type.traffic_type_value == "psg_qty").ToList()?.Count() > 0)
                {
                    traffic.Add(new TrafficBooking
                    {
                        traffic_type = "psg_qty",
                        carpsg_adult = "0",
                        carpsg_child = "0",
                        carpsg_infant = "0",
                        luggage_carry = "0",
                        luggage_check = "0",
                        safetyseat_self_child = "0",
                        safetyseat_sup_child = "0",
                        safetyseat_sup_infant = "0",
                        safetyseat_self_infant = "0"


                    }); ;
                }
                if (bookingfield?.traffics.Where(x => x.traffic_type.traffic_type_value == "voucher").ToList()?.Count() > 0)
                {
                    traffic.Add(new TrafficBooking
                    {
                        traffic_type = "voucher"
                    });
                }

                bookingmodel.traffic = traffic;
                if(bookingfield?.mobile_device != null) {
                    bookingmodel.mobile_device = new MobileDeviceBooking() {
                        mobile_model_no = "",
                        IMEI ="",
                        active_date =""      
                    };
                }
                  
                jsonData.Add("booking", bookingmodel);
                jsonData.Add("bookingfield", bookingfield);
                jsonData.Add("allow_change_pax", allow_change_pax);
                jsonData.Add("prod_info", req.extra);

                return Json(jsonData);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public IActionResult Booking([FromBody] B2DBookingEcModel req)
        {
           // req = JsonConvert.DeserializeObject<B2DBookingEcModel>("{\"contact\":{\"cus_type\":\"contact\",\"english_last_name\":null,\"english_first_name\":null,\"native_last_name\":\"峰\",\"native_first_name\":\"張\",\"tel_country_code\":\"886\",\"tel_number\":\"09383838384\",\"gender\":null,\"contact_app\":null,\"contact_app_account\":null,\"country_cities\":null,\"zipcode\":null,\"address\":null,\"hotel_name\":null,\"hotel_tel_number\":null,\"booking_order_no\":null,\"booking_website\":null,\"check_in_date\":null,\"check_out_date\":null,\"nationality\":null,\"mtp_no\":null,\"id_no\":null,\"passport_no\":null,\"passport_expdate\":null,\"birth\":null,\"height\":null,\"height_unit\":null,\"weight\":null,\"weight_unit\":null,\"shoe\":null,\"shoe_unit\":null,\"shoe_type\":null,\"glass_degree\":null,\"meal\":null,\"allergy_food\":null,\"have_app\":null},\"guid\":\"42b24e7425045b8abe6776416f3c2b7d\",\"partner_order_no\":null,\"prod_no\":\"103966\",\"pkg_no\":\"313920\",\"item_no\":\"59697\",\"locale\":\"zh-tw\",\"state\":\"TW\",\"buyer_first_name\":\"是人\",\"buyer_last_name\":\"我\",\"buyer_Email\":\"kkday@intern.xxx.com\",\"buyer_tel_country_code\":\"886\",\"buyer_tel_number\":\"3939889\",\"buyer_country\":\"A01-001\",\"s_date\":\"2024-02-29\",\"e_date\":\"2024-02-29\",\"event_time\":null,\"skus\":[{\"sku_id\":\"fb0dbc6f7afae01a6ae0d87b03769aed\",\"qty\":2,\"price\":765}],\"custom\":[{\"cus_type\":\"cus_02\",\"english_last_name\":\"feng jung\",\"english_first_name\":\"chang\",\"native_last_name\":null,\"native_first_name\":null,\"tel_country_code\":\"886\",\"tel_number\":\"09383838383\",\"gender\":\"M\",\"contact_app\":null,\"contact_app_account\":null,\"country_cities\":null,\"zipcode\":null,\"address\":null,\"hotel_name\":null,\"hotel_tel_number\":null,\"booking_order_no\":null,\"booking_website\":null,\"check_in_date\":null,\"check_out_date\":null,\"nationality\":null,\"mtp_no\":null,\"id_no\":null,\"passport_no\":\"T1I2II\",\"passport_expdate\":null,\"birth\":\"1988-01-01\",\"height\":null,\"height_unit\":null,\"weight\":null,\"weight_unit\":null,\"shoe\":null,\"shoe_unit\":null,\"shoe_type\":null,\"glass_degree\":null,\"meal\":\"0001\",\"allergy_food\":null,\"have_app\":null},{\"cus_type\":\"cus_02\",\"english_last_name\":\"feng jung\",\"english_first_name\":\"chang\",\"native_last_name\":null,\"native_first_name\":null,\"tel_country_code\":\"886\",\"tel_number\":\"09383838383\",\"gender\":\"M\",\"contact_app\":null,\"contact_app_account\":null,\"country_cities\":null,\"zipcode\":null,\"address\":null,\"hotel_name\":null,\"hotel_tel_number\":null,\"booking_order_no\":null,\"booking_website\":null,\"check_in_date\":null,\"check_out_date\":null,\"nationality\":null,\"mtp_no\":null,\"id_no\":null,\"passport_no\":\"T1I2II\",\"passport_expdate\":null,\"birth\":\"1988-01-01\",\"height\":null,\"height_unit\":null,\"weight\":null,\"weight_unit\":null,\"shoe\":null,\"shoe_unit\":null,\"shoe_type\":null,\"glass_degree\":null,\"meal\":\"0001\",\"allergy_food\":null,\"have_app\":null}],\"traffic\":null,\"mobile_device\":null,\"guide_lang\":\"zh-tw\",\"order_note\":null,\"total_price\":1530,\"pay_type\":\"01\"}");

            Dictionary<string, string> rs = new Dictionary<string, string>();
            try
            {
                B2DBookingModel booking = JsonSerializer.Deserialize<B2DBookingModel>(JsonSerializer.Serialize(req));

                if (booking != null)
                {
                    //call booking
                    var bookProxy = HttpContext.RequestServices.GetService<BookingProxy>();
                    var result = bookProxy.Booking(booking);
                    if (!string.IsNullOrEmpty(result.order_no))
                    {
                        rs.Add("order_no", result.order_no);
                    }
                    else
                    {
                        throw new Exception(result.result_msg);
                    }
                }

                rs.Add("status", "OK");
                return Json(rs);
            }
            catch (Exception ex)
            {
                rs.Add("status", "FAIL");
                rs.Add("msg", $"Booking Failure: {ex.Message}");
                return Json(rs);
            }
        }
    }
}

