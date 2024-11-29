using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Repository;
using KKday.B2D.Web.InternAgent.Proxy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region Localization --- start

var services = builder.Services;
services.AddJsonLocalization(options => options.ResourcesPath = "Resources");

services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] {
                    new CultureInfo("zh-TW"),
                    new CultureInfo("en-US")
                };

    options.DefaultRequestCulture = new RequestCulture(culture: "zh-TW", uiCulture: "zh-TW");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    // 依序進行判斷文化特性，以上都沒有才會以 DefaultRequestCulture 決定語系。
                    new CookieRequestCultureProvider(), // (1) 透過 cookie 的值判斷要求的文化特性資訊。
                    new QueryStringRequestCultureProvider(), // (2) 透過查詢字串中的值，決定要求的文化特性資訊。
                    new AcceptLanguageHeaderRequestCultureProvider(), // (3) 透過 Accept-Language 標頭的值，判斷要求的文化特性資訊。

                    // new CookieRequestCultureProvider() { CookieName = "UserCulture" }
                };

    // Culture Routing
    options.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider());

});


#endregion Localization --- end

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).
    AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowReadingFromString;
    });


#region Dependent Injection --- start

builder.Services.AddSingleton<SearchProxy>();
builder.Services.AddSingleton<ProductProxy>();
builder.Services.AddSingleton<CommonRepository>();
builder.Services.AddSingleton<BookingProxy>();
builder.Services.AddSingleton<OrderProxy>();
builder.Services.AddSingleton<CommonProxy>();

#endregion Dependent Injection --- end


var app = builder.Build();

Website.Instance.Init(config: builder.Configuration);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region 多語系挖字初始設定 --- start

// Get all options of localization 
app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

#endregion 多語系挖字初始設定 --- end

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{culture=zh-TW}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "product",
    pattern: "{culture=zh-TW}/Product/{prod_no?}",
    defaults: new { controller ="Product", action = "Index" });

app.Run();

