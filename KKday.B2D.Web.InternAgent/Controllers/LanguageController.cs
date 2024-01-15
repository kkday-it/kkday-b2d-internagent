using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKday.B2D.Web.InternAgent.AppCode;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KKday.B2D.Web.InternAgent.Controllers
{
    public class LanguageController : Controller
    {
        // GET: /<controller>/
        [Route("{culture}/Language/{id?}")]
        public IActionResult Index(string id)
        {
            try
            {
                // 設定 Culture
                if (HttpContext.Response.Cookies != null)
                {
                    HttpContext.Response.Cookies.Append(
                          CookieRequestCultureProvider.DefaultCookieName,
                          CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(id))
                       );
                }

                var header = HttpContext.Request.GetTypedHeaders();
                Uri referer = header.Referer;

                return Redirect(referer.AbsoluteUri);
            }
            catch (Exception ex)
            { 
                return Redirect("~/");
            }
        }
    }
}

