using System;
using System.Collections;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class ProductRespModel
    {
        public string result { get; set; }
        public string result_msg { get; set; }
        public Dictionary<string, ProductdMarketing> prod_marketing { get; set; }
        public ProductModel prod { get; set; }
        public List<PackageModel> pkg { get; set; }
    }

    public class ProductdMarketing
    {
        public string purchase_type { get; set; } // PT01: Content Amend,PT02: Short Term Suspension, PT03: Seaon Product, null: Available
        public string purchase_date {get; set; } //  "2021-09-30 15:00:00",
        public bool is_search { get; set; }
        public bool is_sale { get; set; }
        public bool is_show { get; set; }
    }
}
