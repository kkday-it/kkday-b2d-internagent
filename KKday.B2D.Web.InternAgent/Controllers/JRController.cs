using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KKday.B2D.Web.InternAgent.Models.Model;
using KKday.B2D.Web.InternAgent.Proxy;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=3978601``1                                                                      78
namespace KKday.B2D.Web.InternAgent.Controllers
{
    [Route("{culture=zh-TW}/Vert/JR")]
    public class JRController : Controller
    {
        // GET: /Vert/JR
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("Booking")]
        [HttpPost("Booking")]
        public IActionResult Booking(JrBookingRouteQuery routeQuery)
        {
            routeQuery = routeQuery ?? new JrBookingRouteQuery();

            var payload = new
            {
                routeKey = routeQuery.RouteKey ?? "",
                serviceName = routeQuery.ServiceName ?? "",
                depCode = routeQuery.DepCode ?? "",
                arrCode = routeQuery.ArrCode ?? "",
                depName = routeQuery.DepName ?? "",
                arrName = routeQuery.ArrName ?? "",
                depDate = routeQuery.DepDate ?? "",
                arrDate = routeQuery.ArrDate ?? ""
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
            ViewData["JrBookingRouteData"] = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));

            return View(routeQuery);
        }

        [HttpGet("countryList")]
        public IActionResult GetIsoCountryList(string locale)
        {
            var commonProxy = HttpContext.RequestServices.GetService<CommonProxy>();
            var result = commonProxy.GetIsoCountryInfo(locale);
            var resp = System.Text.Json.JsonSerializer.Deserialize<IsoCountryRespModel>(result);

            var countries = (resp?.countries ?? new List<IsoCountryModel>()).Select(c => new
            {
                code = c.iso_country_code,
                name = c.name,
                telArea = c.tel_area
            });

            return Ok(new { countries });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string locale, string state, string query, int start, int count,
            string departure_location_codes, string arrival_location_codes)
        {
            var jrProxy = HttpContext.RequestServices.GetService<JrProxy>();
            var resp = await jrProxy.SearchAsync(locale, state, start, count, query, departure_location_codes, arrival_location_codes);

            var locations = (resp.data?.locations ?? new List<JrLocationDto>()).Select(l => new
            {
                locationCode = l.location_code,
                name = l.name,
                locationLevel = l.location_level,
                ancestorLocationCodes = l.ancestor_location_codes
            });

            return Ok(new
            {
                locations,
                totalCount = resp.metadata?.pagination?.total_count ?? 0
            });
        }

        [HttpGet("sellableDate")]
        public async Task<IActionResult> GetSellableDateAsync(string locale)
        {
            var jrProxy = HttpContext.RequestServices.GetService<JrProxy>();
            var resp = await jrProxy.GetSellableDateAsync(locale);

            return Ok(new
            {
                maxSellableDate = resp.data?.max_sellable_date,
                preSellDates = resp.data?.pre_sellable_dates ?? new List<string>()
            });
        }

        [HttpGet("factorList")]
        public async Task<IActionResult> GetFactorListAsync(string locale, List<string> serviceNameList)
        {
            var jrProxy = HttpContext.RequestServices.GetService<JrProxy>();
            var resp = await jrProxy.GetFactorListAsync(locale, serviceNameList);

            return Ok(new
            {
                factorTypeList = (resp.data?.factor_type_list ?? new List<JrFactorTypeDto>())
                    .Select(t => new { key = t.key, name = t.name }),
                factorList = (resp.data?.factor_list ?? new List<JrFactorDto>())
                    .Select(f => new { key = f.key, type = f.type, name = f.name })
            });
        }

        [HttpGet("route")]
        public async Task<IActionResult> GetRouteAsync(string locale, string state, string depType, string depCode, string depDate,
            string arrType, string arrCode, int page, int perPage, List<string> filterParam)
        {
            var jrProxy = HttpContext.RequestServices.GetService<JrProxy>();
            var resp = await jrProxy.GetRouteAsync(locale, state, depType, depCode, depDate, arrType, arrCode, page, perPage, filterParam);

            var routeList = (resp.data?.route_list ?? new List<JrRouteItemDto>()).Select(r => new
            {
                routeKey = r.route_key,
                routeName = r.route_name,
                depTime = r.dep_time,
                arrTime = r.arr_time,
                depDate = r.dep_date,
                arrDate = r.arr_date,
                duration = r.duration,
                isSellable = r.is_sellable,
                routeB2bMinPrice = r.route_b2b_min_price,
                serviceName = r.service_name,
                labels = (r.labels ?? new List<JrRouteLabelDto>()).Select(l => new { name = l.name })
            });

            return Ok(new
            {
                metadata = new
                {
                    pagination = new
                    {
                        total = resp.metadata?.pagination?.total ?? 0,
                        totalPages = resp.metadata?.pagination?.total_pages ?? 1,
                        currentPage = resp.metadata?.pagination?.current_page ?? page
                    }
                },
                data = new { routeList }
            });
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetRouteDetailAsync(string serviceName, string locale, string routeKey)
        {
            var jrProxy = HttpContext.RequestServices.GetService<JrProxy>();
            var resp = await jrProxy.GetRouteDetailAsync(serviceName, locale, routeKey);

            var stepDetailList = (resp.data?.step_detail_list ?? new List<JrStepDetailDto>()).Select(s => new
            {
                stepKey = s.step_key,
                trainName = s.train_name,
                depTime = s.dep_time,
                arrTime = s.arr_time,
                duration = s.duration,
                depStationCode = s.dep_station_code,
                depStationName = s.dep_station_name,
                arrStationCode = s.arr_station_code,
                arrStationName = s.arr_station_name,
                cancelDescription = (s.cancel_description?.list ?? new List<JrCancelDescItemDto>())
                    .Select(c => new { title = c.title, value = c.value }),
                seatOptions = (s.seat_options ?? new List<JrSeatOptionDto>()).Select(o => new
                {
                    key = o.key,
                    name = o.name,
                    description = o.detail?.description,
                    allowedSeatType = o.allowed_seat_type,
                    allowedPassengerCounts = o.allowed_passenger_counts
                }),
                ticketRule = new
                {
                    minQuantity = s.ticket_rule?.min_quantity ?? 1,
                    maxQuantity = s.ticket_rule?.max_quantity ?? 9
                },
                schdList = (s.schd_list ?? new List<JrSchdDto>()).Select(schd => new
                {
                    schdName = schd.schd_name,
                    time = schd.time,
                    meetTime = schd.meet_time
                })
            });

            return Ok(new { routeKey = resp.data?.route_key, stepDetailList });
        }

        [HttpGet("fare")]
        public async Task<IActionResult> GetFareAsync(string serviceName, string stepKey, string locale, string goDate,
            string depSchdCode, string arrSchdCode)
        {
            var jrProxy = HttpContext.RequestServices.GetService<JrProxy>();
            var resp = await jrProxy.GetFareAsync(serviceName, stepKey, locale, goDate, depSchdCode, arrSchdCode);

            return Ok(new
            {
                seatOptionFee = (resp.data?.detail_list?.seat_option_fee ?? new List<JrSeatOptionFeeDto>())
                    .Select(f => new { key = f.key, rate = f.rate, originRate = f.origin_rate }),
                ticketList = (resp.data?.ticket_list ?? new List<JrFareTicketDto>()).Select(t => new
                {
                    key = t.key,
                    name = t.name,
                    specTicket = t.spec_ticket,
                    sellableStatus = t.sellable_status,
                    mspPrice = t.price_detail?.msp_price ?? 0,
                    b2bPrice = t.price_detail?.b2b_price ?? 0
                })
            });
        }

        [HttpPost("booking/check")]
        public async Task<IActionResult> CheckBookingAsync([FromBody] BookingRequest dto)
        {
            var jrProxy = HttpContext.RequestServices.GetService<JrProxy>();
            var resp = await jrProxy.CheckBookingAsync(BuildBookingRequestDto(dto));

            return Ok(new
            {
                priceChanged = resp.data?.price_changed ?? false,
                totalPrice = resp.data?.total_price ?? 0
            });
        }

        [HttpPost("Booking/CreateOrder")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] BookingRequest dto)
        {
            var jrProxy = HttpContext.RequestServices.GetService<JrProxy>();
            var resp = await jrProxy.CreateBookingAsync(BuildBookingRequestDto(dto));

            if (string.IsNullOrEmpty(resp.data?.order_no))
                return Ok(new { status = "ERROR", message = resp.metadata?.message ?? "Booking failed" });

            return Ok(new { status = "OK", orderNo = resp.data.order_no });
        }

        private static JrBookingRequestDto BuildBookingRequestDto(BookingRequest dto)
        {
            return new JrBookingRequestDto
            {
                service_name = dto.ServiceName,
                locale = dto.Locale,
                state = dto.State,
                total_price = dto.TotalPrice,
                buyer_first_name = dto.BuyerFirstName,
                buyer_last_name = dto.BuyerLastName,
                buyer_email = dto.BuyerEmail,
                buyer_tel_country_code = dto.BuyerTelCountryCode,
                buyer_tel_number = dto.BuyerTelNumber,
                buyer_country = dto.BuyerCountry,
                order_note = dto.OrderNote,
                pay_type = "01",
                client_email = dto.ClientEmail,
                partner_order_no = dto.PartnerOrderNo,
                route = new JrBookingRouteDto
                {
                    route_key = dto.RouteKey,
                    route_name = dto.RouteName,
                    dep_city_key = dto.DepCityKey,
                    arr_city_key = dto.ArrCityKey,
                    dep_date = dto.DepDate,
                    dep_time = dto.DepTime,
                    dep_meet_time = dto.DepMeetTime,
                    arr_date = dto.ArrDate,
                    arr_time = dto.ArrTime,
                    dep_schd_code = dto.DepSchdCode,
                    arr_schd_code = dto.ArrSchdCode,
                    dep_name = dto.DepName,
                    arr_name = dto.ArrName,
                    route_map = (dto.RouteMap ?? new List<BookingRouteMapRequest>()).Select(m => new JrBookingRouteMapDto
                    {
                        step_key = m.StepKey,
                        dep_schd_code = m.DepSchdCode,
                        arr_schd_code = m.ArrSchdCode
                    }).ToList(),
                    seat_option = (dto.SeatOptions ?? new List<BookingSeatOptionRequest>()).Select(s => new JrBookingSeatOptionDto
                    {
                        key = s.Key,
                        name = s.Name,
                        allowed_seat_type = s.AllowedSeatType,
                        allowed_passenger_counts = s.AllowedPassengerCounts
                    }).ToList()
                },
                seats = (dto.Seats ?? new List<BookingSeatRequest>()).Select(s => new JrBookingSeatDto
                {
                    step_key = s.StepKey,
                    seat_type = s.SeatType,
                    custom_first_name = s.CustomFirstName,
                    custom_last_name = s.CustomLastName
                }).ToList(),
                ticket_qty = (dto.TicketQty ?? new List<BookingTicketQtyRequest>()).Select(t => new JrTicketQtyDto
                {
                    key = t.Key,
                    qty = t.Qty,
                    name = t.Name
                }).ToList()
            };
        }
    }
}
