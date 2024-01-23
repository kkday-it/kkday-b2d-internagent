using System;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class QuerytOrdersReqModel
    {
        public int page_size { get; set; }
        public int current_page { get; set; }
        public string time_zone { get; set; } // "Asia/Taipei"
        public string prod_Sdat { get; set; } // Format => yyyymmdd
        public string prod_Edate { get; set; } // Format => yyyymmdd 
        public string order_Sdate { get; set; } // Format => yyyymmdd 
        public string order_Edate { get; set; } // Format => yyyymmdd
        public string partner_order_no { get; set; }
        public List<string> orders { get; set; }  
        public List<string> kkday_orders { get; set; }
    }
 
}
