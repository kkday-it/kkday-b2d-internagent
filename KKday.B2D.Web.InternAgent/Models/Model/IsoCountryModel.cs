using System.Collections.Generic;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class IsoCountryRespModel
    {
        public string result { get; set; }
        public string result_msg { get; set; }
        public List<IsoCountryModel> countries { get; set; }
    }

    public class IsoCountryModel
    {
        public string iso_country_code { get; set; }
        public string tel_area { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int level { get; set; }
    }
}
