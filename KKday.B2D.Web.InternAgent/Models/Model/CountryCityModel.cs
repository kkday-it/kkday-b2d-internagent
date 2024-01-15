using System;
using System.Collections.Generic; 

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class CountryCityRespModel
    { 
        public string result { get; set; } 
        public string result_msg { get; set; } 
        public List<CountryCitiesCodeModel> countries { get; set; }
    }

    public class CountryCitiesCodeModel
    { 
        public string country_name { get; set; } 
        public string country_code { get; set; } 
        public List<CityCodeModel> cities { get; set; }
    }

    public partial class CityCodeModel
    {
        public string city_name { get; set; }
        public string city_code { get; set; }
    }

    ///////////

    public class CountryCityMapModel
    {
        public string city_code { get; set; }
        public string country_code { get; set; }
        public string name { get; set; }
    }
}
