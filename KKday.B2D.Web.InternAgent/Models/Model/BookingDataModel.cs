using System;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public partial class BookingDataModel
    {
        public string? guid { get; set; }
        public string? partner_order_no { get; set; }
        public Int64 prod_no { get; set; }
        public Int64 pkg_no { get; set; }
        public Int64 item_no { get; set; }
        public string? s_date { get; set; } // yyyy-mm-dd
        public string? e_date { get; set; } // yyyy-mm-dd
        public string? event_time { get; set; } // "hh:mm"
        public List<BookingDataSkuModel>? skus { get; set; }
        public string? buyer_first_name { get; set; }
        public string? buyer_last_name { get; set; }
        public string? buyer_email { get; set; }
        public string? buyer_tel_country_code { get; set; }
        public string? buyer_tel_number { get; set; }
        public string? buyer_country { get; set; }
        public string? guide_lang { get; set; }
        public string? order_note { get; set; }
        public double total_price { get; set; }
        public List<BookingDataCustomModel>? custom { get; set; }
        public List<BookingDataTrafficModel>? traffic { get; set; }
        public BookingDataMobileDeviceModel? mobile_device { get; set; }
        public string? event_backup_data { get; set; } // (ex: 1/20191124/1300, 2/20191125/1400)
        public BookingDataPaymentModel? pay { get; set; }
    }

    public partial class BookingDataSkuModel
    {
        public string? sku_id { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
    }

    public partial class BookingDataCustomModel
    {
        public string? cus_type { get; set; }
        public string? english_last_name { get; set; }
        public string? english_first_name { get; set; }
        public string? native_last_name { get; set; }
        public string? native_first_name { get; set; }
        public string? tel_country_code { get; set; }
        public string? tel_number { get; set; }
        public string? gender { get; set; }
        public string? contact_app { get; set; }
        public string? contact_app_account { get; set; }
        public string? country_cities { get; set; }
        public string? zipcode { get; set; }
        public string? address { get; set; }
        public string? nationality { get; set; }
        public string? MTP_no { get; set; }
        public string? id_no { get; set; }
        public string? passport_no { get; set; }
        public string? passport_expdate { get; set; }
        public string? birth { get; set; }
        public string? height { get; set; }
        public string? height_unit { get; set; }
        public string? weight { get; set; }
        public string? weight_unit { get; set; }
        public string? shoe { get; set; }
        public string? shoe_unit { get; set; }
        public string? shoe_type { get; set; }
        public float? glass_degree { get; set; }
        public string? meal { get; set; }
        public string? allergy_food { get; set; }
        public string? have_app { get; set; }
        public string? guide_lang { get; set; }
    }

    public partial class BookingDataTrafficModel
    {
        public BookingDataTrafficCarModel car { get; set; }
        public BookingDataTrafficFlightModel flight { get; set; }
        public BookingDataTrafficQtyModel qty { get; set; } // 各旅客身分的行李, 安全座椅, 等
    }

    public partial class BookingDataTrafficCarModel
    {
        public string? traffic_type { get; set; }
        public string? area_code { get; set; }
        public string? s_location { get; set; }
        public string? e_location { get; set; }
        public string? s_address { get; set; }
        public string? e_address { get; set; }
        public string? s_date { get; set; } // yyyy-mm-dd
        public string? e_date { get; set; } // yyyy-mm-dd
        public string? s_time { get; set; } // hh:mm
        public string? e_time { get; set; } // hh:mm
        public bool? provide_wifi { get; set; }
        public bool? provide_gps { get; set; }
        public bool? is_rent_customize { get; set; }
    }

    public partial class BookingDataTrafficFlightModel
    {
        public string? traffic_type { get; set; }
        public string? arrival_airport { get; set; }
        public string? arrival_flightType { get; set; }
        public string? arrival_airlineName { get; set; }
        public string? arrival_flightNo { get; set; }
        public string? arrival_terminalNo { get; set; }
        public bool arrival_visa { get; set; }
        public string? arrival_date { get; set; } // yyyy-mm-dd
        public string? arrival_time { get; set; } // hh:mm
        public string? departure_airport { get; set; }
        public string? departure_flightType { get; set; }
        public string? departure_airlineName { get; set; }
        public string? departure_flightNo { get; set; }
        public string? departure_terminalNo { get; set; }
        public bool departure_haveBeenInCountry { get; set; }
        public string? departure_date { get; set; } // yyyy-mm-dd
        public string? departure_time { get; set; } // hh:mm
    }

    public partial class BookingDataTrafficQtyModel
    {
        public string? traffic_type { get; set; }
        public int CarPsg_adult { get; set; }
        public int CarPsg_child { get; set; }
        public int CarPsg_infant { get; set; }
        public int SafetySeat_sup_child { get; set; }
        public int SafetySeat_sup_infant { get; set; }
        public int SafetySeat_self_child { get; set; }
        public int SafetySeat_self_infant { get; set; }
        public int Luggage_carry { get; set; }
        public int Luggage_check { get; set; }
    }

    public partial class BookingDataMobileDeviceModel
    {
        public string? mobile_model_no { get; set; }
        public string? IMEI { get; set; }
        public string? active_date { get; set; }
    }

    public partial class BookingDataPaymentModel
    {
        public string? type { get; set; }
    }
}
