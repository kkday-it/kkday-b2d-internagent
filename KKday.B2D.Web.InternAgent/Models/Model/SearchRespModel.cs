using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class SearchRespModel
    {
        public Metadata metadata { get; set; } 
        public SearchFacet facets { get; set; } 
        public SearchStats stats { get; set; }
        public List<SearchProductModel> prods {get; set;}
    }

    public class Metadata
    {
        public string result { get; set; }
        public string result_msg { get; set; }
        public int? total_count { get; set; }
        public int? count { get; set; }

        public int? current_page { get; set; }
        public int? page_size { get; set; }
    }

    ////////////

    public class SearchFacet
    {
        public List<ProductCategory> cat_main { get; set; } // 主分類
        public List<ProductCategory> cat { get; set; } // 次分類 (由id區分)
        public List<Tag> tag { get; set; }  // 新版大小分類
    }
      
    ////////////

    public class SearchStats
    {
        public SearchStatsPrice price { get; set; }
    }

    public class SearchStatsPrice
    {
        public decimal? min { get; set; }
        public decimal? max { get; set; }
        public int count { get; set; }
        public string currency { get; set; }
    }

    ////////////
    
    public class SearchProductModel
    {
        public Int64 prod_no { get; set; }
        public Int64 prod_url_no { get; set; }
        public string prod_name { get; set; }
        public string prod_type { get; set; }
        public List<string> tag { get; set; }
        public int rating_count { get; set; }
        public bool instant_booking { get; set; }
        public int days { get; set; }
        public int hours { get; set; }
        public int duration { get; set; }
        public string introduction { get; set; }
        public string prod_img_url { get; set; }
        public float b2c_price { get; set; }
        public float b2b_price { get; set; }
        public string prod_currency { get; set; }

        public class CountryCitiesModel
        {
            public string id { get; set; }
            public string name { get; set; }
            public List<CityModel> cities { get; set; }
        }
        public List<CountryCitiesModel> countries { get; set; }
    }    
}
