using System;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class QuerytOrdersRespModel
    {
        public string result { get; set; }
        public string result_msg { get; set; } 
        public int order_qty { get; set; }
        public int current_page { get; set; }
        public string companyName { get; set; }
        public List<OrderQueryModel> order { get; set; }
    }

    public class OrderQueryModel
    {
        public string order_no { get; set; }
        public string order_date { get; set; } // 2024-01-23 09:44  (GMT+8)",
        public string order_status { get; set; }
        public string prod_no { get; set; }
        public string prod_name { get; set; }
        public string pkg_no { get; set; }
        public int qty_total { get; set; }
        public string prod_s_date { get; set; } // 2024-02-29 (Taipei)",
        public string prod_e_date { get; set; }
        public decimal cancel_fee { get; set; }
        public decimal refund_price { get; set; }
    }
     
}
