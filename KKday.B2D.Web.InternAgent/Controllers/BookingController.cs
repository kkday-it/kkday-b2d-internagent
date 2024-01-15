using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult LoadData([FromBody] BookingFieldModel req)
        {
            var result = new Dictionary<string, object>();
            return Json(result);
        }
    }
}

