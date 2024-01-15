using System;
using System.Collections.Generic;
using System.Linq;
using KKday.B2D.Web.InternAgent.Models.Model;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;

namespace KKday.B2D.Web.InternAgent.Models.Repository
{
    public class CommonRepository
    {
        private readonly IWebHostEnvironment _env;

        public CommonRepository(IWebHostEnvironment env)
        {
            _env = env;
        }

        public List<CodeNameModel> GetCountries()
        {
            var result = new List<CodeNameModel>();

            try
            {
                string contentRootPath = _env.ContentRootPath;
                var jsonData = System.IO.File.ReadAllText(contentRootPath + "/AppData/Countries.json");
                result = JObject.Parse(jsonData)["countries"].ToObject<List<CodeNameModel>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CommonRepository.GetCountries Exception: {ex.Message},{ex.StackTrace}");
            }

            return result;
        }

        public List<TelCountryModel> GetTelCountries()
        {
            var result = new List<TelCountryModel>();

            try
            {
                string contentRootPath = _env.ContentRootPath;
                var jsonData = System.IO.File.ReadAllText(contentRootPath + "/AppData/TelCountries.json");
                result = JObject.Parse(jsonData)["tel-countries"].ToObject<List<TelCountryModel>>();
                result = result.OrderBy(t => t.PreferSeq).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CommonRepository.GetTelCountries Exception: {ex.Message},{ex.StackTrace}");
            }

            return result;
        }
         
    }
}
