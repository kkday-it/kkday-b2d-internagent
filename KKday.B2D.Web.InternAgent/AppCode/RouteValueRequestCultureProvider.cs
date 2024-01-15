using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using System.Globalization;

namespace InternAgent.AppCode
{
    public class RouteValueRequestCultureProvider : RequestCultureProvider
    {

        private readonly object _locker = new object();

        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            // TODO: Implement GetCulture() to get a culture for the current request
            var culture = GetDefaultCultureCode();

            lock (_locker)
            {
                var parts = httpContext.Request.Path.Value.Split('/');
                var cultureCode = parts[1]?.ToLower();
                // 檢查是否為已支持的語系?
                var matched = CheckCultureCode(cultureCode);
                // cultureCode 轉小寫
                cultureCode = cultureCode.ToLower();

                if(matched)
                {
                    culture = cultureCode;
                }
                else
                {
                    // 把真正的 culture 存到 cookie
                    if (cultureCode.StartsWith("en"))
                    {
                        culture = "en-US";
                    }

                    // 空白的 culture 預設 "zh-tw"
                    if (string.IsNullOrEmpty(cultureCode))
                        cultureCode = culture.ToLower();
                }

                var cookieOptions = new CookieOptions
                {
                    Secure = true,
                    HttpOnly = true,
                    SameSite = SameSiteMode.None
                };

                httpContext.Response.Cookies.Append("cultureInfo", cultureCode, cookieOptions);
            }
            
            return Task.FromResult(new ProviderCultureResult(culture));
        }

        private string GetDefaultCultureCode()
        {
            return this.Options.DefaultRequestCulture.Culture.ToString();
        }

        private bool CheckCultureCode(string cultureCode)
        {
            return this.Options.SupportedCultures.Select(c => c.ToString().ToLower()).Contains(cultureCode);
        }
    }
}

