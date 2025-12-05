using System;
using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class SearchFormReqModel
    {
        public string key { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public double? price_from { get; set; }
        public double? price_to { get; set; }
        public int? schedule_minute_from { get; set; }
        public int? schedule_minute_to { get; set; }
        public string sort { get; set; }
        public int? page { get; set; }
        public int? size { get; set; }
        public List<string> destination { get; set; }
        public List<string> product_categories { get; set; }
    }
}
