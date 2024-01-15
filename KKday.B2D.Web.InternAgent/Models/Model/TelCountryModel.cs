using System;
using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Models.Model
{
    public class TelCountryModel
    {
        [JsonProperty("dial-code")]
        public string DialCode { get; set; }

        [JsonProperty("country-code")]
        public string CountryCode { get; set; }

        [JsonProperty("country-name")]
        public string CountryName { get; set; }

        [JsonProperty("prefer-seq")]
        public int PreferSeq { get; set; }
    }
}
