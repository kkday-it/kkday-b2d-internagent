using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using KKday.B2D.Web.InternAgent.Models.Model;
using KKday.B2D.Web.InternAgent.Proxy;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KKday.B2D.Web.InternAgent.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Query([FromBody] SearchFormReqModel req)
        {
            var jsonData = new Dictionary<string, object>();
            var result = "";

            try
            {
                var searchProxy = HttpContext.RequestServices.GetService<SearchProxy>();
                // Check current cultureinfo
                var locale = CultureInfo.CurrentCulture.ToString().Equals("en-US") ? "en" : "zh-tw";

                var searchReq = new SearchReqModel()
                {
                    locale = locale,
                    state = "tw",
                    keywords = req.key,
                    start = ((req.page - 1) * req.size).ToString(),
                    cat_main_keys = req.cat_main_keys,
                    cat_keys = req.cat_keys,
                    date_from = req.date_from,
                    date_to = req.date_to,
                    durations = req.durations?.Select(s => s.Replace("8h", "0,8").Replace("1d", "8,24").Replace("2d", "24,48").Replace("*", "48,*")).ToList(),
                    price_from = req.price_from,
                    price_to = req.price_to,
                    sort = req.sort ?? "PASC",
                    page_size = req.size.ToString()
                };

                result = searchProxy.Search(searchReq);
                Console.WriteLine($"Search Result => {result}");
                var resp = JsonConvert.DeserializeObject<SearchRespModel>(result);
                resp.metadata.current_page = req.page ?? 1;
                resp.metadata.page_size = Convert.ToInt32(searchReq.page_size);

                // If there is nothing in the small category, the large category will not be displayed.
                resp.facets.tag.ForEach(x =>
                {
                    x.count = 0;
                    x.sub_tags.ForEach(s =>
                    {
                        if (Convert.ToInt16(s.count) > 0)
                        {
                            x.count++;
                        }
                    });
                });

                jsonData.Add("data", resp);
            }
            catch (Exception ex)
            {
                jsonData.Clear();
                Console.WriteLine($"Search Result => {result}");
            }

            return Json(jsonData);
        }
    }
}

