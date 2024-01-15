using System;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class SearchFormReqModel
    {
        public string key { get; set; }
        public List<string> country_keys { get; set; }
        public List<string> city_keys { get; set; }
        public List<string> cat_main_keys { get; set; }
        public List<string> cat_keys { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public double? price_from { get; set; }
        public double? price_to { get; set; }
        public List<string> durations { get; set; } // Hours, Integer string or "*"(more than 3 days)
        public string sort { get; set; }
        public int? page { get; set; }
        public int? size { get; set; }
    }
}
