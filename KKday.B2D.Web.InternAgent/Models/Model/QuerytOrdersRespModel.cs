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
        public List<Order> order { get; set; }
    }

    public class Order
    {
        public string order_no { get; set; }
        public string order_date { get; set; }
        public string order_status { get; set; }
        public string prod_no { get; set; }
        public string prod_name { get; set; }
        public string pkg_no { get; set; }
        public string pkg_name { get; set; }
        public int qty_total { get; set; }
        public string prod_s_date { get; set; }
        public string prod_e_date { get; set; }
        public double? cancel_fee { get; set; }
        public double? refund_price { get; set; }
    }
}
