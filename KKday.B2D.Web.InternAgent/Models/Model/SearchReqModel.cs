using System;
using System.Collections.Generic; 

namespace KKday.B2D.Web.InternAgent.Models.Model
{ 
    public class SearchReqModel
    {
        // Mandatory fields
        public string locale { get; set; } // display language
        public string state { get; set; }  // marketing country
        public bool? instant_booking { get; set; } // true, false
        public string date_from { get; set; }
        public string date_to { get; set; }
        public double? price_from { get; set; }
        public double? price_to { get; set; }
        public int? schedule_minute_from { get; set; }
        public int? schedule_minute_to { get; set; }
        public string keywords { get; set; }
        public List<string> guid_lags { get; set; }
        public string sort { get; set; } // Sort condition, PDESC(Price with high to low), PASC(Price with low to hight),HDESC（Popular with high to low）
        public string start { get; set; } // Rows, Default "0"
        public string page_size { get; set; }
        public List<string> stats { get; set; }
        public List<string> facets { get; set; }
        public bool? has_pk { get; set; }
        public string tourism { get; set; } // 00:GIFT, 01:TOUR
        public bool? have_translate { get; set; }
        public List<string> destination { get; set; }
        public List<string> product_categories { get; set; }
    }
}
