using System;
using System.Collections.Generic;
using InternAgent.AppCode;
using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class PackageModel
    {
        public Int64? pkg_no { get; set; }
        public string pkg_name { get; set; }
        public string exchange_type { get; set; }
        public int? confirm_time { get; set; }
        public string confirm_time_unit { get; set; }
        public int? deliver_time { get; set; }
        public string deliver_time_unit { get; set; }
        public int? deliver_timing { get; set; }
        public string policy_type { get; set; }
        public string refund_type { get; set; }
        public List<PackagePartialRrefund> partial_refund { get; set; } 
        public RefundPolicyV2Model refund_policy_v2 { get; set; }
        public double? b2c_min_price { get; set; }
        public double? b2b_min_price { get; set; }
        public List<Int64> item_no { get; set; }
        public string sale_s_date { get; set; }
        public string sale_s_date_event { get; set; }
        public string sale_e_date { get; set; }
        public string sale_e_date_event { get; set; }
        public PmdlModel description_module { get; set; }
        public GoDateSettingModel go_date_setting { get; set; }
    }

    public partial class PackagePartialRrefund
    { 
        public double? value { get; set; } 
        public long? day_min { get; set; } 
        public long? day_max { get; set; }
    }
}
