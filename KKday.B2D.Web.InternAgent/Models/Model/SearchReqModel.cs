using System;
using System.Collections.Generic; 

namespace KKday.B2D.Web.InternAgent.Models.Model
{ 
    public class SearchReqModel
    {
        // Mandatory fields
        public string locale { get; set; }
        public string state { get; set; } 
        // Optional fields
        public bool? instant_booking { get; set; }
        public List<string> country_keys { get; set; }  // deprecated!
        public List<string> city_keys { get; set; }  // deprecated!
        public List<string> cat_main_keys { get; set; }  // deprecated!
        public List<string> cat_keys { get; set; }  // deprecated!
        public string date_from { get; set; }
        public string date_to { get; set; }
        public double? price_from { get; set; }
        public double? price_to { get; set; }
        public string keywords { get; set; }
        public List<string> guid_lags { get; set; }
        public string purchase_type { get; set; } // Types => PT01:Content Modified, PT02:Discontinued, PT03:Seasonal Product
        public string purchase_date { get; set; } // Start time to purchase "2021-01-21 15: 00 :00"
        public string earliest_sale_date { get; set; } // Earliest date available "2021-01-25" 
        public string sort { get; set; } // Sort condition, PDESC(Price with high to low), PASC(Price with low to hight),HDESC（Popular with high to low）
        public string start { get; set; } // Rows, Default "0"
        public string page_size { get; set; }
        public List<string> durations { get; set; } // Hours, Integer string or "*"(more than 3 days)
        public List<string> stats { get; set; }
        public List<string> facets { get; set; }
        public bool? has_pk { get; set; }
        public string tourism { get; set; } // 00:GIFT, 01:TOUR
        public bool? have_translate { get; set; }
        public List<string> destination { get; set; }
        public List<string> product_categories { get; set; }
    }
}
