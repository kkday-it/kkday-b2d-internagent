using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using KKday.B2D.Web.InternAgent.Models.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KKday.B2D.Web.InternAgent.Controllers
{
    public class BookingController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadData([FromBody] BookingFillReqModel req) // object req)
        {
            var jsonData = new Dictionary<string, object>();

            // Convert to BookingModel
            var bookingModel = JsonSerializer.Deserialize<BookingDataModel>(JsonSerializer.Serialize(req));

            // Get BookingField by prod_no
            var bookingField = new BookingFieldModel()
            {
                 Custom = new Custom(),
                 Traffic = new Traffic()
            };

            jsonData.Add("bookingmodel", bookingModel ?? new BookingDataModel());
            jsonData.Add("bookingfield", bookingField);

            return Json(jsonData);
        }
    }
}

