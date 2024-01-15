using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class BookingFillReqModel
    {
        public string guid { get; set; }
        public Int64 prod_no { get; set; }
        public Int64 pkg_no { get; set; }
        public Int64 item_no { get; set; }
        public string s_date { get; set; }
        public string e_date { get; set; }
        public string currency { get; set; } 
        public string event_time { get; set; }
        public List<BookingSkuModel> skus { get; set; } 
        public double total_price { get; set; }

        public BookingExtraDataModel extra { get; set; }
    }

    public class BookingSkuModel
    {
        public string sku_id { get; set; }
        public int qty { get; set; }
        public double price { get; set; }

        public List<string> specs_ref { get; set; } // Mapping to BookingExtraDataModel.specs[].spec_item_oid
    }
     
    public class BookingExtraDataModel
    {
        public string pkg_name { get; set; }
        public string prod_name { get; set; }
        public string unit { get; set; }
        public string unit_code { get; set; }
        public List<Spec> specs { get; set; }
    }
}
