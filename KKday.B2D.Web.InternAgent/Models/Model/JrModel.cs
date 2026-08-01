using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    // Wire-format DTOs for the Vert JR API (https://api-b2d-10.sit.kkday.com/swagger/vert-jr/swagger.json).
    // Property names match the API's snake_case JSON exactly so Newtonsoft can bind without attributes.

    public class JrApiResponse<TMetadata, TData>
    {
        public TMetadata metadata { get; set; }
        public TData data { get; set; }
    }

    public class JrMetadata
    {
        public string status { get; set; }
        public string message { get; set; }
    }

    public class JrSearchPagination
    {
        public int start { get; set; }
        public int count { get; set; }
        public long total_count { get; set; }
    }

    public class JrSearchMetadata : JrMetadata
    {
        public JrSearchPagination pagination { get; set; }
    }

    public class JrLocationDto
    {
        public string location_code { get; set; }
        public int location_level { get; set; }
        public string name { get; set; }
        public List<string> ancestor_location_codes { get; set; }
    }

    public class JrSearchLocationData
    {
        public List<JrLocationDto> locations { get; set; }
    }

    public class JrSellableDateData
    {
        public string max_sellable_date { get; set; }
        public List<string> pre_sellable_dates { get; set; }
    }

    public class JrFactorTypeDto
    {
        public int key { get; set; }
        public string name { get; set; }
    }

    public class JrFactorDto
    {
        public int key { get; set; }
        public int type { get; set; }
        public string name { get; set; }
    }

    public class JrFactorListData
    {
        public List<JrFactorTypeDto> factor_type_list { get; set; }
        public List<JrFactorDto> factor_list { get; set; }
    }

    public class JrRouteLabelDto
    {
        public string name { get; set; }
    }

    public class JrRouteItemDto
    {
        public string route_key { get; set; }
        public string route_name { get; set; }
        public string dep_date { get; set; }
        public string dep_time { get; set; }
        public string arr_date { get; set; }
        public string arr_time { get; set; }
        public string duration { get; set; }
        public decimal? route_b2b_min_price { get; set; }
        public bool is_sellable { get; set; }
        public string service_name { get; set; }
        public List<JrRouteLabelDto> labels { get; set; }
    }

    public class JrRouteResultData
    {
        public List<JrRouteItemDto> route_list { get; set; }
    }

    public class JrRoutePagination
    {
        public int total { get; set; }
        public int per_page { get; set; }
        public int current_page { get; set; }
        public int total_pages { get; set; }
    }

    public class JrRouteMetadata : JrMetadata
    {
        public JrRoutePagination pagination { get; set; }
    }

    public class JrSchdDto
    {
        public string schd_name { get; set; }
        public string meet_time { get; set; }
        public string time { get; set; }
    }

    public class JrCancelDescItemDto
    {
        public string title { get; set; }
        public string value { get; set; }
    }

    public class JrCancelDescriptionDto
    {
        public string type { get; set; }
        public string message { get; set; }
        public List<JrCancelDescItemDto> list { get; set; }
    }

    public class JrSeatOptionDetailDto
    {
        public string description { get; set; }
    }

    public class JrSeatOptionDto
    {
        public string key { get; set; }
        public string name { get; set; }
        public JrSeatOptionDetailDto detail { get; set; }
        public List<string> allowed_seat_type { get; set; }
        public List<int> allowed_passenger_counts { get; set; }
    }

    public class JrTicketRuleDto
    {
        public int max_quantity { get; set; }
        public int min_quantity { get; set; }
    }

    public class JrStepDetailDto
    {
        public string step_key { get; set; }
        public string train_name { get; set; }
        public string dep_time { get; set; }
        public string arr_time { get; set; }
        public string duration { get; set; }
        public string dep_station_code { get; set; }
        public string dep_station_name { get; set; }
        public string arr_station_code { get; set; }
        public string arr_station_name { get; set; }
        public JrCancelDescriptionDto cancel_description { get; set; }
        public List<JrSeatOptionDto> seat_options { get; set; }
        public JrTicketRuleDto ticket_rule { get; set; }
        public List<JrSchdDto> schd_list { get; set; }
    }

    public class JrRouteDetailData
    {
        public string route_key { get; set; }
        public List<JrStepDetailDto> step_detail_list { get; set; }
    }

    public class JrRouteDetailRequest
    {
        public string service_name { get; set; }
        public string locale { get; set; }
        public string route_key { get; set; }
    }

    // Wire-format DTOs for POST /vert/jr/Route/fare
    public class JrQueryFareDto
    {
        public string service_name { get; set; }
        public string step_key { get; set; }
        public string locale { get; set; }
        public string go_date { get; set; }
        public string dep_schd_code { get; set; }
        public string arr_schd_code { get; set; }
    }

    public class JrPriceDetailDto
    {
        public decimal? msp_price { get; set; }
        public decimal? b2c_booking_fee { get; set; }
        public decimal? b2b_price { get; set; }
        public decimal? usd_msp_price { get; set; }
        public decimal? usd_b2b_price { get; set; }
    }

    public class JrFareTicketDto
    {
        public string key { get; set; }
        public string name { get; set; }
        public string spec_ticket { get; set; }
        public string sellable_status { get; set; }
        public JrPriceDetailDto price_detail { get; set; }
    }

    public class JrSeatOptionFeeDto
    {
        public string key { get; set; }
        public double rate { get; set; }
        public double origin_rate { get; set; }
    }

    public class JrFareDetailListDto
    {
        public List<JrSeatOptionFeeDto> seat_option_fee { get; set; }
    }

    public class JrFareDataDto
    {
        public JrFareDetailListDto detail_list { get; set; }
        public List<JrFareTicketDto> ticket_list { get; set; }
    }

    // Wire-format DTOs for POST /vert/jr/Booking and /vert/jr/Booking/check
    public class JrBookingRouteMapDto
    {
        public string step_key { get; set; }
        public string dep_schd_code { get; set; }
        public string arr_schd_code { get; set; }
    }

    public class JrBookingSeatOptionDto
    {
        public string key { get; set; }
        public string name { get; set; }
        public List<string> allowed_seat_type { get; set; }
        public List<int> allowed_passenger_counts { get; set; }
    }

    public class JrBookingRouteDto
    {
        public string route_key { get; set; }
        public string route_name { get; set; }
        public string dep_city_key { get; set; }
        public string arr_city_key { get; set; }
        public string dep_date { get; set; }
        public string dep_time { get; set; }
        public string dep_meet_time { get; set; }
        public string arr_date { get; set; }
        public string arr_time { get; set; }
        public string dep_schd_code { get; set; }
        public string arr_schd_code { get; set; }
        public string dep_name { get; set; }
        public string arr_name { get; set; }
        public List<JrBookingRouteMapDto> route_map { get; set; }
        public List<JrBookingSeatOptionDto> seat_option { get; set; }
    }

    public class JrBookingSeatDto
    {
        public string step_key { get; set; }
        public string seat_type { get; set; }
        public string custom_first_name { get; set; }
        public string custom_last_name { get; set; }
    }

    public class JrTicketQtyDto
    {
        public string key { get; set; }
        public int qty { get; set; }
        public string name { get; set; }
    }

    public class JrBookingRequestDto
    {
        public string service_name { get; set; }
        public string locale { get; set; }
        public string state { get; set; }
        public decimal total_price { get; set; }
        public string buyer_first_name { get; set; }
        public string buyer_last_name { get; set; }
        public string buyer_email { get; set; }
        public string buyer_tel_country_code { get; set; }
        public string buyer_tel_number { get; set; }
        public string buyer_country { get; set; }
        public string order_note { get; set; }
        public string pay_type { get; set; }
        public string client_email { get; set; }
        public string partner_order_no { get; set; }
        public JrBookingRouteDto route { get; set; }
        public List<JrBookingSeatDto> seats { get; set; }
        public List<JrTicketQtyDto> ticket_qty { get; set; }
    }

    public class JrBookingCheckTicketDto
    {
        public string key { get; set; }
        public string name { get; set; }
        public JrPriceDetailDto price_detail { get; set; }
        public decimal? partial_sum { get; set; }
    }

    public class JrBookingCheckData
    {
        public bool price_changed { get; set; }
        public decimal total_price { get; set; }
        public List<JrBookingCheckTicketDto> ticket_list { get; set; }
        public decimal? partial_sum { get; set; }
    }

    public class JrBookingMetadata : JrMetadata
    {
        public string reason_code { get; set; }
    }

    public class JrBookingResultData
    {
        public string order_no { get; set; }
        public string order_oid { get; set; }
        public string partner_order_no { get; set; }
        public string order_master_mid { get; set; }
    }

    // Client-facing request shape posted from Views/JR/Index.cshtml's goBooking to
    // GET/POST /Vert/JR/Booking, so the Booking view can be rendered with the
    // selected route already resolved server-side.
    public class JrBookingRouteQuery
    {
        public string RouteKey { get; set; }
        public string ServiceName { get; set; }
        public string DepCode { get; set; }
        public string ArrCode { get; set; }
        public string DepName { get; set; }
        public string ArrName { get; set; }
        public string DepDate { get; set; }
        public string ArrDate { get; set; }
    }

    // Client-facing request shape posted from Views/JR/Booking.cshtml.
    public class BookingRouteMapRequest
    {
        public string StepKey { get; set; }
        public string DepSchdCode { get; set; }
        public string ArrSchdCode { get; set; }
    }

    public class BookingSeatOptionRequest
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public List<string> AllowedSeatType { get; set; }
        public List<int> AllowedPassengerCounts { get; set; }
    }

    public class BookingSeatRequest
    {
        public string StepKey { get; set; }
        public string SeatType { get; set; }
        public string CustomFirstName { get; set; }
        public string CustomLastName { get; set; }
    }

    public class BookingTicketQtyRequest
    {
        public string Key { get; set; }
        public int Qty { get; set; }
        public string Name { get; set; }
    }

    public class BookingRequest
    {
        public string Locale { get; set; }
        public string State { get; set; }
        public string ServiceName { get; set; }
        public string RouteKey { get; set; }
        public string RouteName { get; set; }
        public string DepCityKey { get; set; }
        public string ArrCityKey { get; set; }
        public string DepDate { get; set; }
        public string DepTime { get; set; }
        public string DepMeetTime { get; set; }
        public string ArrDate { get; set; }
        public string ArrTime { get; set; }
        public string DepSchdCode { get; set; }
        public string ArrSchdCode { get; set; }
        public string DepName { get; set; }
        public string ArrName { get; set; }
        public List<BookingRouteMapRequest> RouteMap { get; set; }
        public List<BookingSeatOptionRequest> SeatOptions { get; set; }
        public List<BookingSeatRequest> Seats { get; set; }
        public List<BookingTicketQtyRequest> TicketQty { get; set; }
        public decimal TotalPrice { get; set; }
        public string BuyerFirstName { get; set; }
        public string BuyerLastName { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerTelCountryCode { get; set; }
        public string BuyerTelNumber { get; set; }
        public string BuyerCountry { get; set; }
        public string OrderNote { get; set; }
        public string ClientEmail { get; set; }
        public string PartnerOrderNo { get; set; }
    }
}
