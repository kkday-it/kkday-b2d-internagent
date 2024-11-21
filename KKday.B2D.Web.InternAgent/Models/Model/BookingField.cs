using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using KKday.B2D.Web.InternAgent.AppCode;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class BookingField
    {
        public string result { get; set; }
        public string? result_msg { get; set; }

        public Int64 prod_no { get; set; }

        // cus_01 (Leader), cus_02 (Travelers), send (Receiver), contact (During travel)
        public Custom? custom { get; set; }

        // flight, rentcar_01 (A to A), rentcar_02 (A to B), pickup_03 (Pickup/Dropoff),
        // rentcar_03 (Charter) + pickup_04 (Pickup/Dropoff), passenger_qty, voucher
        public List<Traffic>? traffics { get; set; }

        // sim & wifi
        public MobileDevice? mobile_device { get; set; }

        public GuideLang? guide_lang { get; set; }

        //public EventBackup event_backup { get; set; }
        //public Dictionary<string, RequireType> ref_pkg { get; set; }
    }

    //////////////

    #region Custom --- start

    public partial class CustomAttribute
    {
        public string is_require { get; set; } 
        public string is_visible { get; set; } 
        public string is_send_used { get; set; } 
        public string is_perParticipant { get; set; } 
        public string is_lead_used { get; set; } 
        public string is_contact_used { get; set; } 
        public string type { get; set; } 
        public List<string> use { get; set; }
    }

    public partial class Custom
    { 
        public CusType cus_type { get; set; } 
        public CustomAttribute english_last_name { get; set; } 
        public CustomAttribute english_first_name { get; set; } 
        public CustomAttribute native_last_name { get; set; } 
        public CustomAttribute native_first_name { get; set; } 
        public TelCountryCode tel_country_code { get; set; } 
        public CustomAttribute tel_number { get; set; } 
        public Gender gender { get; set; } 
        public ContactApp contact_app { get; set; } 
        public CustomAttribute contact_app_account { get; set; }  
        public CountryCities country_cities { get; set; } 
        public CustomAttribute zipcode { get; set; } 
        public CustomAttribute address { get; set; } 
        public CustomAttribute hotel_name { get; set; } 
        public CustomAttribute hotel_tel_number { get; set; } 
        public CustomAttribute booking_order_no { get; set; } 
        public CustomAttribute booking_website { get; set; } 
        public CustomAttribute check_in_date { get; set; }  
        public CustomAttribute check_out_date { get; set; } 
        public Nationality nationality { get; set; } 
        public CustomAttribute mtp_no { get; set; } 
        public CustomAttribute id_no { get; set; } 
        public CustomAttribute passport_no { get; set; } 
        public CustomAttribute passport_expdate { get; set; } 
        public CustomAttribute birth { get; set; } 
        public CustomAttribute height { get; set; } 
        public HeightUnit height_unit { get; set; }
        public CustomAttribute weight { get; set; }
        public WeightUnit weight_unit { get; set; } 
        public Shoe shoe { get; set; } 
        public ShoeUnit shoe_unit { get; set; } 
        public ShoeType shoe_type { get; set; } 
        public GlassDegree glass_degree { get; set; } 
        public Meal meal { get; set; } 
        public CustomAttribute allergy_food { get; set; }
    }

    public partial class CusType : CustomAttribute
    { 
        public string[] list_option { get; set; }
    }

    public partial class TelCountryCode : CustomAttribute
    { 
        public List<CodeInfo> list_option { get; set; }
    }

    public partial class CodeInfo
    {
        public string code { get; set; } 
        public string info { get; set; }
    }

    public partial class Gender : CustomAttribute
    {
        public List<IdName> list_option { get; set; }
    }

    public partial class ContactApp : CustomAttribute
    { 
        public List<ContactAppSupport> list_option { get; set; }
    }

    public partial class HeightUnit : CustomAttribute
    { 
        public List<IdName> list_option { get; set; }
    }

    public partial class Nationality : CustomAttribute
    {
        public List<CodeNameModel> list_option { get; set; }
    }

    public partial class CountryCities : CustomAttribute
    { 
        public List<CountryCity> list_option { get; set; }
    }

    public partial class WeightUnit : CustomAttribute
    {
        public List<IdName> list_option { get; set; }
    }

    public partial class Shoe : CustomAttribute
    {
        public List<Dictionary<string, List<ShoeUnitInfo>>> list_option { get; set; }
    }
    public partial class ShoeUnit : CustomAttribute
    {
        public List<IdName> list_option { get; set; }
    }

    public partial class ShoeType : CustomAttribute
    {
        public List<IdName> list_option { get; set; }
    }

    public partial class GlassDegree : CustomAttribute
    { 
        public List<Dictionary<string, string>> list_option { get; set; }
    }

    public partial class Meal : CustomAttribute
    { 
        public List<MealTypeInfo> list_option { get; set; }
    }

    public partial class GuideLang : CustomAttribute
    { 
        public List<string> list_option { get; set; }
    }

    public partial class IdName
    { 
        public string id { get; set; }
        public string name { get; set; }
    }

    public partial class ContactAppSupport
    { 
        public bool? supported { get; set; } 
        public string app_type { get; set; } 
        public string app_name { get; set; }
    }

    public partial class CountryCity : IdName
    { 
        public List<CityCodeName> cities { get; set; }
    }

    public partial class CityCodeName
    {
        public string city_code { get; set; }
        public string name { get; set; }
    }

    public partial class ShoeUnitInfo
    {
        public string unit_code { get; set; }
        public string unit_name { get; set; } 
        public decimal? size_range_start { get; set; } 
        public decimal? size_range_end { get; set; } 
        public decimal? interval { get; set; }
    }

    public partial class MealTypeInfo
    {
        public bool? is_provided { get; set; }
        public string meal_type { get; set; }
        public string meal_type_name { get; set; }
    }

    #endregion Custom --- end

    //////////////

    #region Traffic --- start

    public partial class TrafficAttribute
    { 
        public string is_require { get; set; }
        public string is_visible { get; set; }
        public string ref_source { get; set; }
        public string type { get; set; }
    }

    public partial class Traffic
    { 
        public TrafficType traffic_type { get; set; }

        // flight
        public ArrivalFlightType arrival_flightType { get; set; }
        public ArrivalAirport arrival_airport { get; set; }
        public TrafficAttribute arrival_airlineName { get; set; }
        public TrafficAttribute arrival_flightNo { get; set; }
        public TrafficAttribute arrival_terminal_no { get; set; }
        public TrafficAttribute arrival_visa { get; set; }
        public TrafficAttribute arrival_date { get; set; }
        public TrafficAttribute arrival_time { get; set; }
        public DepartureFlightType departure_flightType { get; set; }
        public DepartureAirport departure_airport { get; set; }
        public TrafficAttribute departure_airlineName { get; set; }
        public TrafficAttribute departure_flightNo { get; set; }
        public TrafficAttribute departure_terminalNo { get; set; }
        public TrafficAttribute departure_haveBeenInCountry { get; set; }
        public TrafficAttribute departure_date { get; set; }
        public TrafficAttribute departure_time { get; set; }
        
        // psg_qty
        public TrafficAttribute carpsg_adult { get; set; }
        public TrafficAttribute carpsg_child { get; set; }
        public TrafficAttribute carpsg_infant { get; set; }
        public TrafficAttribute safetyseat_sup_child { get; set; }
        public TrafficAttribute safetyseat_self_child { get; set; }
        public TrafficAttribute safetyseat_sup_infant { get; set; }
        public TrafficAttribute safetyseat_self_infant { get; set; }
        public TrafficAttribute luggage_carry { get; set; }
        public TrafficAttribute luggage_check { get; set; }

        ///////////////
        
        public Slocation s_location { get; set; }
        public Slocation e_location { get; set; }
        public TrafficAttribute s_date { get; set; }
        public TrafficTime s_time { get; set; }
        public TrafficAttribute e_date { get; set; }
        public TrafficAttribute e_time { get; set; }
        public TrafficAttribute provide_wifi { get; set; }
        public TrafficAttribute provide_gps { get; set; } 

    }

    public partial class TrafficType : TrafficAttribute
    { 
        public string traffic_type_value { get; set; }
    }

    public partial class ArrivalFlightType : TrafficAttribute
    { 
        public List<IdName> list_option { get; set; }
    }

    public partial class ArrivalAirport : TrafficAttribute
    { 
        public List<AirIdName> list_option { get; set; }
    }

    public partial class DepartureFlightType : TrafficAttribute
    { 
        public List<IdName> list_option { get; set; }
    }

    public partial class DepartureAirport : TrafficAttribute
    { 
        public List<AirIdName> list_option { get; set; }
    }

    public partial class Slocation : TrafficAttribute
    { 
        public List<SlocaitonInfo> list_option { get; set; } 
    }

    public partial class TrafficTime : TrafficAttribute
    {
        public List<TimeInfo> list_option { get; set; }
    }

    public partial class AirIdName
    { 
        public string code { get; set; }
        public string name { get; set; }
        public string area { get; set; }
    }

    public partial class SlocaitonInfo
    { 
        public string traffic_type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string note { get; set; }
         
        public List<BusinessHours> businessHours { get; set; }
        public List<LocationTimes> time_list { get; set; }
         
        public long? sort { get; set; }
        public string code { get; set; }
        public long? interval { get; set; }
        public string s_time { get; set; }
        public string e_time { get; set; }
        public string route_local { get; set; }
        public string route_eng { get; set; }

    }

    public partial class TimeInfo
    { 
        public string id { get; set; }
        public string hour { get; set; }
        public string min { get; set; }
        public string time_range { get; set; }
    }

    public partial class BusinessHours
    {
        public string to { get; set; }
        public string from { get; set; }
        public string weekDays { get; set; }
    }

    public partial class LocationTimes
    {
        public LocationTimeInfo to { get; set; }
        public LocationTimeInfo from { get; set; }
        public string weekDays { get; set; }
    }

    public partial class LocationTimeInfo
    {
        public int hour { get; set; }
        public int minute { get; set; }
    }

    #endregion Traffic --- end

    //////////////

    #region Mobile --- start

    public partial class MobileAttribute
    {
        public string is_require { get; set; }
        public string is_visible { get; set; }
        public string is_mobile_used { get; set; }
        public string type { get; set; }
    }

    public partial class MobileDevice
    { 
        public MobileAttribute mobile_model_no { get; set; }
        public MobileAttribute IMEI { get; set; }
        public MobileAttribute active_date { get; set; }
    }

    #endregion Mobile --- end

    //////////////

    #region Reference Package --- start

    public partial class RefPkgAttribute
    {
        public RefPkgCustomer customer { get; set; }
        public RefPkgTraffic traffic { get; set; }
    }

    public partial class RefPkgCustomer
    {
        public List<string> cus_type { get; set; }
        public string address { get; set; }
        public string country_cities { get; set; }
    }

    public partial class RefPkgTraffic
    {
        public List<string> traffic_type { get; set; }
        public string s_date { get; set; }
        public string s_time { get; set; }
        public string s_location { get; set; }
        public string e_date { get; set; }
        public string e_time { get; set; }
        public string e_location { get; set; }
        public string departure_flight { get; set; }
        public string arrival_flight { get; set; }
    }

    #endregion  Reference Package  --- end

    //////////////
      
    public class RequireType
    {
        //public List<string> custom { get; set; }
        //public List<string> traffic { get; set; }
        public Customer custom { get; set; }
        public Traffics traffic { get; set; }
        //public string country_cities { get; set; }
        //public string zip_code { get; set; }
        //public string address { get; set; }

        #region hotel資訊 sendType=01

        public string hotel_name { get; set; }
        public string hotel_address { get; set; }
        public string hotel_tel { get; set; }
        public string hotel_booking_order_no { get; set; }
        public string hotel_booking_website { get; set; }
        public string hotel_checkin_date { get; set; }
        public string hotel_checkout_date { get; set; }

        #endregion

    }

    public class Customer : Custom
    {
        new public List<string> cus_type { get; set; }
    }

    public class Traffics //: Traffic
    {
        public List<string> traffic_type { get; set; }

        #region flight_type=02

        public string s_date { get; set; }
        public string s_time { get; set; }
        public string s_location { get; set; }
        public string e_location { get; set; }

        #endregion

        public string e_date { get; set; }
        public string e_time { get; set; }

        #region flight

        public string arrival_flight { get; set; }
        public string departure_flight { get; set; }

        #endregion
    } 
     
}
