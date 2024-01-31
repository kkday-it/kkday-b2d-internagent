using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    /// <summary>
    /// 維揚給的要BOOKING的model
    /// </summary>
    public class B2DBookingModel
    {
        /// <summary>
        /// guid(From the QueryPackage API)
        /// </summary>
        /// <example>a1a11111e93df876685ad15973c3484</example>
        public string guid { get; set; }
        /// <summary>
        /// Partner Order No
        /// </summary>
        /// <example>orderno</example>
        public string partner_order_no { get; set; }
        /// <summary>
        /// Product No
        /// </summary>
        /// <example>1111</example>
        public string prod_no { get; set; }
        /// <summary>
        /// Package No
        /// </summary>
        /// <example>11111</example>
        public string pkg_no { get; set; }
        /// <summary>
        /// Item No
        /// </summary>
        /// <example>111111</example>
        public string item_no { get; set; }//Item欄位
        /// <summary>
        /// locale (zh-tw,en...)
        /// </summary>
        /// <example>zh-tw</example>
        public string locale { get; set; }
        /// <summary>
        /// state(It needs to be the same as the query for the package.)
        /// </summary>
        /// <example>TW</example>
        public string state { get; set; }//銷售市場
        /// <summary>
        /// buyer first name
        /// </summary>
        /// <example>First Name</example>
        public string buyer_first_name { get; set; }
        /// <summary>
        /// buyer last name
        /// </summary>
        /// <example>Last Name</example>
        public string buyer_last_name { get; set; }
        /// <summary>
        /// buyer email(If you do not want customers to receive emails from KKday and prefer to have them contact customer service instead, you can enter the customer service email address in the email field after placing an order.)
        /// </summary>
        /// <example>gdsupport@kkday.com</example>
        public string buyer_Email { get; set; }
        /// <summary>
        /// buyer telephone country code
        /// </summary>
        /// <example>886</example>
        public string buyer_tel_country_code { get; set; }
        /// <summary>
        /// buyer telephone number
        /// </summary>
        /// <example>1111111</example>
        public string buyer_tel_number { get; set; }
        /// <summary>
        /// buyer country
        /// </summary>
        /// <example>TW</example>
        public string buyer_country { get; set; }//TW
        /// <summary>
        /// Using the date of use or departure date.
        /// </summary>
        /// <example>"2023-08-01"</example>
        public string s_date { get; set; }
        /// <summary>
        /// Using the date of use or departure date.(If only one day can be selected, then the e_date will be equal s_date)
        /// </summary>
        /// <example>"2023-08-01"</example>
        public string e_date { get; set; }
        /// <summary>
        /// Event time (if there are no event,then would be empty)
        /// </summary>
        /// <example>"09:10"</example>
        public string event_time { get; set; }//場次時間 hh:mm
        /// <summary>
        /// Booking skus(The individual price for each SKU, and if it spans multiple days, the price will be the sum of the individual daily prices.)
        /// </summary>
        /// <example>[{"sku_id": "f66c7c9429fa0d80cb1575513f78546f","qty":1,"price":"100"}]</example>
        public List<Sku> skus { get; set; }//skuList
        /// <summary>
        /// Travel booking information will be filled based on the custom data in the BookingField.(cus_01:Traveler Representative,cus_02:All Travelers Must Fill Out,contact:Contact Information,send:Send Information)
        /// </summary>
        /// <example>[{"cus_type":"cus_01","english_last_name":"test","english_first_name":"test","native_last_name":"test","native_first_name":"test","gender":"F","nationality":"TW","mtp_no":"A1111111","id_no":"A1111111","passport_no":"111111","passport_expdate":"2023-05-01","birth":"1900-01-01","height":"160","height_unit":"01","weight":"60","weight_unit":"01","shoe":"20","shoe_unit":"01","shoe_type":"M","glass_degree":100,"meal":"0001"},{"cus_type":"cus_02","english_last_name":"test","english_first_name":"test","native_last_name":"test","native_first_name":"test","gender":"F","nationality":"TW","mtp_no":"A1111111","id_no":"A1111111","passport_no":"111111","passport_expdate":"2023-05-01","birth":"1900-01-01","height":"160","height_unit":"01","weight":"60","weight_unit":"01","shoe":"20","shoe_unit":"01","shoe_type":"M","glass_degree":100,"meal":"0001"},{"cus_type":"send","native_last_name":"test","native_first_name":"test","country_cities":"A01-001_A01-001-00001","zipcode":"300","address":"test location","hotel_name":"sample hotel Name","hotel_tel_number":"01-12312312","booking_order_no":"1X123X23","booking_website":"https://www....","check_in_date":"2023-07-01","check_out_date":"2023-07-10"},{ "cus_type":"contact","contact_app":"0001","contact_app_account":"testaccount","tel_country_code":"886","tel_number":"111111","have_app":true}]</example>
        public List<CustomBooking> custom { get; set; }
        /// <summary>
        /// Travel booking information will be filled based on the traffic data in the BookingField.(rentcar_01: Indicates that the customer will rent and return the vehicle at the same location.,rentcar_02:Indicates that the customer will rent the vehicle from one location and return it to a different location,rentcar_03: Indicates that the rental includes a driver.,pickup_03:Indicates that the customer will be picked up at a location specified by the supplier.pickup_04: Indicates that the customer will be picked up at a location specified by the customer.voucher: Indicates the location where the voucher can be collected.flight: Provides information about the airport.psgqty:Provides information about the number of passengers.)
        /// </summary>
        ///<example>[{"traffic_type":"rentcar_01","s_location":"test","e_location":"test","s_date":"2023-09-11","provide_wifi":true,"provide_gps":true},{"traffic_type":"rentcar_02","s_location":"test","e_location":"test2","s_date":"2023-09-11","is_rent_customize":true},{"traffic_type":"pickup_03","s_location":"test","e_location":"test2","s_date":"2023-09-11","s_time":"09:00"},{"traffic_type":"pickup_04","s_location":"test","e_location":"test2","s_date":"2023-09-11","s_time":"09:00"},{"traffic_type":"voucher","s_location":"test"},{"traffic_type":"psg_qty","carpsg_adult":"1","carpsg_child":"1","carpsg_infant":"1","safetyseat_sup_child":"1","safetyseat_sup_infant":"1","safetyseat_self_child":"1","safetyseat_self_infant":"1","luggage_carry":"2","luggage_check":"2"},{ "traffic_type":"flight","arrival_airport":"BR111","arrival_flightType":"01","arrival_airlineName":"eva airline","arrival_flightNo":"BR111","arrival_terminalNo":"T2","arrival_visa":"2023-09-10","arrival_date":"2023-09-10","arrival_time":"09:00","departure_airport":"BR111","departure_flightType":"01","departure_airlineName":"eva airline","departure_flightNo":"BR111","departure_terminalNo":"T2","departure_haveBeenInCountry":"2023-09-10","departure_date":"2023-09-10","departure_time":"09:00"}]</example>
        public List<TrafficBooking> traffic { get; set; }
        /// <summary>
        /// Travel booking information will be filled based on the mobile data in the BookingField.
        /// </summary>
        ///<example>{"mobile_model_no":"","IMEI":"111111111111111","active_date":"2023-07-01"}</example>
        public MobileDeviceBooking mobile_device { get; set; }//sim wifi


        /// <summary>
        /// guide_lang
        /// </summary>
        public string guide_lang { get; set; }
        /// <summary>
        /// Order notes
        /// </summary>
        /// <example>""</example>
        public string order_note { get; set; }//note資訊
        /// <summary>
        /// This order total price(The total sum of quantities and prices for all filled SKU)
        /// </summary>
        /// <example>1000</example>
        public double total_price { get; set; }
        /// <summary>
        /// Payment method (currently fixed value is 01).
        /// </summary>
        /// <example>"01"</example>
        public string pay_type { get; set; }

    }

    //SkuModel
    public class Sku
    {
        public string sku_id { get; set; }
        public int qty { get; set; }
        public double? price { get; set; }//精準度以currency的小數點為主
    }



    //CustomModel
    #region --旅客--
    public class CustomBooking
    {
        /// <summary>
        /// Traveler types:[cus_01: Representative traveler,cus_02: Each individual traveler,contact: Traveler contact information,send: Traveler shipping information]
        /// </summary>

        public string cus_type { get; set; }
        /// <summary>
        /// Customer English Name
        /// </summary>

        public string english_last_name { get; set; }
        /// <summary>
        /// Customer English Name
        /// </summary>

        public string english_first_name { get; set; }
        /// <summary>
        /// Customer Native Name
        /// </summary>

        public string native_last_name { get; set; }
        /// <summary>
        /// Customer Native Name
        /// </summary>

        public string native_first_name { get; set; }
        /// <summary>
        /// Customer Phone Country Code
        /// </summary>

        public string tel_country_code { get; set; }
        /// <summary>
        /// Customer Phone Number
        /// </summary>

        public string tel_number { get; set; }
        /// <summary>
        /// Customer Gender
        /// </summary>

        public string gender { get; set; }
        /// <summary>
        /// Customer Contact app Code
        /// </summary>

        public string contact_app { get; set; }
        /// <summary>
        /// Customer Contact app account
        /// </summary>

        public string contact_app_account { get; set; }
        /// <summary>
        /// Customer country_citiy for receiving the goods.(countryCode_cityCode)(A01-001_A01-001-00001)
        /// </summary>

        public string country_cities { get; set; }
        /// <summary>
        /// Customer postal code for the receiving address
        /// </summary>

        public string zipcode { get; set; }
        /// <summary>
        /// Customer receving the goods address
        /// </summary>

        public string address { get; set; }

        #region 寄送飯店
        /// <summary>
        /// Hotel name for the customer to receive the goods
        /// </summary>

        public string hotel_name { get; set; }//飯店名稱
        /// <summary>
        /// Hotel telnumber for the customer to receive the goods
        /// </summary>

        public string hotel_tel_number { get; set; }//飯店電話
        /// <summary>
        /// Hotel reservation number
        /// </summary>

        public string booking_order_no { get; set; }//訂房編號
        /// <summary>
        /// Hotel website
        /// </summary>

        public string booking_website { get; set; }//飯店網站
        /// <summary>
        /// Check-in hotel date
        /// </summary>

        public string check_in_date { get; set; }//入房日期
        /// <summary>
        /// Check-out hotel date
        /// </summary>

        public string check_out_date { get; set; }//退房日期
        #endregion
        /// <summary>
        /// Customer Nationality(TW,JP...)
        /// </summary>

        public string nationality { get; set; }
        /// <summary>
        /// Customer MTP number
        /// </summary>

        public string mtp_no { get; set; }
        /// <summary>
        /// Customer ID number
        /// </summary>

        public string id_no { get; set; }
        /// <summary>
        /// Customer passport number
        /// </summary>

        public string passport_no { get; set; }
        /// <summary>
        /// Customer passport expired date
        /// </summary>

        public string passport_expdate { get; set; }
        /// <summary>
        /// Customer birth day
        /// </summary>

        public string birth { get; set; }
        /// <summary>
        /// Customer height(number)
        /// </summary>

        public string height { get; set; }
        /// <summary>
        /// Customer height unit
        /// </summary>

        public string height_unit { get; set; }
        /// <summary>
        /// Customer weight(number)
        /// </summary>

        public string weight { get; set; }
        /// <summary>
        /// Customer weight unit
        /// </summary>

        public string weight_unit { get; set; }
        /// <summary>
        /// Customer shoe(number)
        /// </summary>

        public string shoe { get; set; }
        /// <summary>
        /// Customer shoe unit
        /// </summary>

        public string shoe_unit { get; set; }
        /// <summary>
        /// Customer shoe type
        /// </summary>

        public string shoe_type { get; set; }
        /// <summary>
        /// Eyeglass prescription
        /// </summary>

        public double? glass_degree { get; set; }
        /// <summary>
        /// Meal type
        /// </summary>

        public string meal { get; set; }//素 葷
        /// <summary>
        /// Hated food types
        /// </summary>

        public string allergy_food { get; set; }


        /// <summary>
        /// Whether there is an app (when false, contact_app and contact_app_account can be null or empty)
        /// </summary>

        public string have_app { get; set; }

    }
    #endregion









































    //TrafficModel
    //交通
    public class TrafficBooking
    {

        //
        //public string traffic_type { get; set; }

        //
        //public Car car { get; set; }//包含接送與租車

        //
        //public Qty qty { get; set; }

        //
        //public Flight flight { get; set; }
        #region car
        /// <summary>
        /// Transportation types: [flight(flight), psg_qty(number of passengers or package), voucher(voucher redemption location), rentcar_01(same pick-up and drop-off location), rentcar_02(different pick-up and drop-off location),rentcar_03 (car rental with driver), pickup_03 (supplier-designated pick-up and drop-off location), pickup_04 (customer-designated pick-up and drop-off location)]
        /// </summary>

        public string traffic_type { get; set; }

        public string area_code { get; set; }


        public string location_list { get; set; }//供應商提供的接送地點列表

        /// <summary>
        /// Pick-up location or rental location
        /// </summary>

        public string s_location { get; set; }
        /// <summary>
        /// Drop-off location or Return location
        /// </summary>

        public string e_location { get; set; }
        /// <summary>
        /// Pick-up address
        /// </summary>

        public string s_address { get; set; }
        /// <summary>
        /// Drop-off address
        /// </summary>

        public string e_address { get; set; }
        /// <summary>
        /// Pick-up date or rental date
        /// </summary>

        public string s_date { get; set; }
        /// <summary>
        /// Drop-off date or Return date
        /// </summary>

        public string e_date { get; set; }
        /// <summary>
        /// Pick-up time or rental time
        /// </summary>

        public string s_time { get; set; }
        /// <summary>
        /// Drop-off time or Return time
        /// </summary>

        public string e_time { get; set; }


        public string time_list { get; set; }

        /// <summary>
        /// Whether the rental requires a WiFi devic
        /// </summary>

        public bool? provide_wifi { get; set; }
        /// <summary>
        /// Whether the rental requires a GPS devic
        /// </summary>

        public bool? provide_gps { get; set; }
        /// <summary>
        /// Whether custom service rental is required
        /// </summary>

        public bool? is_rent_customize { get; set; }
        #endregion
        #region Qty
        /// <summary>
        /// Number of passengers - Adults
        /// </summary>

        public string carpsg_adult { get; set; }
        /// <summary>
        /// Number of passengers - Child
        /// </summary>

        public string carpsg_child { get; set; }
        /// <summary>
        /// Number of passengers - Infant
        /// </summary>

        public string carpsg_infant { get; set; }

        //安全座椅數量
        /// <summary>
        /// Number of safety seats- Child
        /// </summary>

        public string safetyseat_sup_child { get; set; }//店家提供
        /// <summary>
        /// Number of safety seats- Infant
        /// </summary>

        public string safetyseat_sup_infant { get; set; }
        /// <summary>
        /// Number of safety seats brought by the customer- Child
        /// </summary>

        public string safetyseat_self_child { get; set; }//(客人自備)
        /// <summary>
        /// Number of safety seats brought by the customer- Infant
        /// </summary>

        public string safetyseat_self_infant { get; set; }
        /// <summary>
        /// Number of carry-on luggage
        /// </summary>

        //行李數量

        public string luggage_carry { get; set; }
        /// <summary>
        /// Number of checked luggage
        /// </summary>

        public string luggage_check { get; set; }
        #endregion
        #region flight
        /// <summary>
        /// Arrival airport
        /// </summary>

        public string arrival_airport { get; set; }
        /// <summary>
        /// Arrival airport category, domestic or international
        /// </summary>

        public string arrival_flightType { get; set; }
        /// <summary>
        /// Arriving airline
        /// </summary>

        public string arrival_airlineName { get; set; }
        /// <summary>
        /// Arriving flight number
        /// </summary>

        public string arrival_flightNo { get; set; }
        /// <summary>
        /// Arriving terminal number
        /// </summary>

        public string arrival_terminalNo { get; set; }
        /// <summary>
        /// Arriving VISA
        /// </summary>

        public bool? arrival_visa { get; set; }
        /// <summary>
        /// Arriving date
        /// </summary>

        public string arrival_date { get; set; }
        /// <summary>
        /// Arriving time
        /// </summary>

        public string arrival_time { get; set; }
        /// <summary>
        /// Departure airport
        /// </summary>

        public string departure_airport { get; set; }
        /// <summary>
        /// Departure airport category, domestic or international
        /// </summary>

        public string departure_flightType { get; set; }
        /// <summary>
        /// Departure airline
        /// </summary>

        public string departure_airlineName { get; set; }
        /// <summary>
        /// Departure flight number
        /// </summary>

        public string departure_flightNo { get; set; }
        /// <summary>
        /// Departure terminal number
        /// </summary>

        public string departure_terminalNo { get; set; }
        /// <summary>
        /// Departure airline
        /// </summary>

        public string departure_haveBeenInCountry { get; set; }
        /// <summary>
        /// Departure date
        /// </summary>

        public string departure_date { get; set; }
        /// <summary>
        /// Departure time
        /// </summary>

        public string departure_time { get; set; }
        #endregion

    }


    //MobileModel
    public class MobileDeviceBooking
    {
        /// <summary>
        /// Mobile phone model
        /// </summary>
        //[BookingRequired]
        public string mobile_model_no { get; set; }
        /// <summary>
        /// IMEI
        /// </summary>
        //[BookingRequired]
        public string IMEI { get; set; }
        /// <summary>
        /// Activation date
        /// </summary>
        //[BookingRequired]
        public string active_date { get; set; }
    }

}

