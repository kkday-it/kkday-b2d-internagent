using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model; 

namespace KKday.B2D.Web.InternAgent.Proxy
{
    public class ProductProxy
    {
        private readonly IConfiguration _config;

        public ProductProxy(IConfiguration config)
        {
            _config = config;
        }

        public string GetProduct(ProductReqModel req)
        {
            try
            {
                var jsonResult = "";
                var kkdayUrl = Website.Instance.KKdayApiUrl;
                var authorToken = Website.Instance.KKdayApiAuthorizeToken;

                using (var handler = new HttpClientHandler())
                {
                    // Ignore Certificate Error!!
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    using (var client = new HttpClient(handler))
                    {

                        #region JSON Payload

                        var options = new JsonSerializerOptions()
                        {
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                        }; 
                        var content = JsonSerializer.Serialize(req, options);
                        // Console.WriteLine($"Product Req Payload => {content}");

                        #endregion JSON Payload

                        string reqUrl = $"{kkdayUrl}/Product/QueryProduct";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");
                            // Add body content
                            request.Content = new StringContent(
                                content,
                                Encoding.UTF8,
                                "application/json"
                            );

                            var response = client.SendAsync(request).Result;
                            jsonResult = response.Content.ReadAsStringAsync().Result;

                            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                            {
                                Console.WriteLine($"QueryProduct: {response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                                throw new Exception($"QueryProduct: {response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                            }
                        }
                    }
                }

                return jsonResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GetPackage(PackageReqModel req)
        {
            try
            {
                var jsonResult = "";
                var kkdayUrl = Website.Instance.KKdayApiUrl;
                var authorToken = Website.Instance.KKdayApiAuthorizeToken;

                using (var handler = new HttpClientHandler())
                {
                    // Ignore Certificate Error!!
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    using (var client = new HttpClient(handler))
                    {

                        #region JSON Payload

                        // Filter unnecessary parameters
                        req = JsonSerializer.Deserialize<PackageReqModel>(JsonSerializer.Serialize(req));

                        var options = new JsonSerializerOptions()
                        {
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                        };
                        var content = JsonSerializer.Serialize(req, options);
                        // Console.WriteLine($"Package Req Payload => {content}");

                        #endregion JSON Payload

                        string reqUrl = $"{kkdayUrl}/Product/QueryPackage";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");
                            // Add body content
                            request.Content = new StringContent(
                                content,
                                Encoding.UTF8,
                                "application/json"
                            );

                            var response = client.SendAsync(request).Result;
                            jsonResult = response.Content.ReadAsStringAsync().Result;

                            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                            {
                                Console.WriteLine($"QueryPackage: {response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                                throw new Exception($"QueryPackage: {response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                            }
                        }
                    }
                }

                return jsonResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public AllotmentRespModel GetAllotment(AllotmentReqModel req)
        {
            try
            {
                var jsonResult = "";
                var kkdayUrl = Website.Instance.KKdayApiUrl;
                var authorToken = Website.Instance.KKdayApiAuthorizeToken;

                using (var handler = new HttpClientHandler())
                {
                    // Ignore Certificate Error!!
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    using (var client = new HttpClient(handler))
                    {

                        #region JSON Payload

                        var options = new JsonSerializerOptions()
                        {
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                        };
                        var content = JsonSerializer.Serialize(req, options);
                        // Console.WriteLine($"QueryAllotment Req Payload => {content}");

                        #endregion JSON Payload

                        string reqUrl = $"{kkdayUrl}/Product/QueryAllotment";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");
                            // Add body content
                            request.Content = new StringContent(
                                content,
                                Encoding.UTF8,
                                "application/json"
                            );

                            var response = client.SendAsync(request).Result;
                            jsonResult = response.Content.ReadAsStringAsync().Result;

                            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                            {
                                throw new Exception($"{response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                            }
                        }
                    }
                }

                return JsonSerializer.Deserialize<AllotmentRespModel>(jsonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EventBackupRespModel GetEventBackup(EventBackupReqModel req)
        {
            try
            {
                var jsonResult = "";
                var kkdayUrl = Website.Instance.KKdayApiUrl;
                var authorToken = Website.Instance.KKdayApiAuthorizeToken;

                using (var handler = new HttpClientHandler())
                {
                    // Ignore Certificate Error!!
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    using (var client = new HttpClient(handler))
                    {
                        #region JSON Payload

                        var options = new JsonSerializerOptions()
                        {
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                        };
                        var content = JsonSerializer.Serialize(req, options);
                        // Console.WriteLine($"QueryBackupEvent Req Payload => {content}");

                        #endregion JSON Payload

                        string reqUrl = $"{kkdayUrl}/Product/QueryBackupEvent";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");
                            // Add body content
                            request.Content = new StringContent(
                                content,
                                Encoding.UTF8,
                                "application/json"
                            );

                            var response = client.SendAsync(request).Result;
                            jsonResult = response.Content.ReadAsStringAsync().Result;

                            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                            {
                                throw new Exception($"{response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                            }
                        }
                    }
                }

                return JsonSerializer.Deserialize<EventBackupRespModel>(jsonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetBookingField(BookingFieldReqModel req)
        {
            try
            {
                var jsonResult = "";
                var kkdayUrl = Website.Instance.KKdayApiUrl;
                var authorToken = Website.Instance.KKdayApiAuthorizeToken;

                using (var handler = new HttpClientHandler())
                {
                    // Ignore Certificate Error!!
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                    using (var client = new HttpClient(handler))
                    {

                        #region JSON Payload

                        // 過濾不必要的參數
                        req = Newtonsoft.Json.JsonConvert.DeserializeObject<BookingFieldReqModel>(Newtonsoft.Json.JsonConvert.SerializeObject(req));

                        var content = Newtonsoft.Json.JsonConvert.SerializeObject(req, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
                        // Console.WriteLine($"Package Req Payload => {content}");

                        #endregion JSON Payload

                        string reqUrl = $"{kkdayUrl}/Product/QueryBookingField";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");
                            // Add body content
                            request.Content = new StringContent(
                                content,
                                Encoding.UTF8,
                                "application/json"
                            );

                            var response = client.SendAsync(request).Result;
                            jsonResult = response.Content.ReadAsStringAsync().Result;

                            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                            {
                                throw new Exception($"{response.StatusCode} => {Newtonsoft.Json.JsonConvert.SerializeObject(jsonResult)} ");
                            }
                        }
                    }
                }

                return jsonResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
