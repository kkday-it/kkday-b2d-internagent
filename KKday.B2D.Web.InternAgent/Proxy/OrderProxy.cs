using System.Text;
using System.Text.Json;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;
 
namespace KKday.B2D.Web.InternAgent.Proxy
{
    public class OrderProxy
    {
        private readonly IConfiguration _config;

        public OrderProxy(IConfiguration config)
        {
            _config = config;
        }

        public string QueryOrders(QuerytOrdersReqModel req)
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
                        string reqUrl = $"{kkdayUrl}/Order/QueryOrders";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");
                            // Add body content
                            request.Content = new StringContent(
                                content: JsonSerializer.Serialize(req),
                                Encoding.UTF8,
                                "application/json"
                            );

                            for (var retry = 0; retry < 5; retry++)
                            {
                                var response = client.SendAsync(request).Result;
                                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    jsonResult = response.Content.ReadAsStringAsync().Result;
                                    break;
                                }
                                else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                                {
                                    Thread.Sleep(1000); continue;
                                }
                                else
                                {
                                    throw new Exception($"{response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                                }
                            }
                        }
                    }
                }

                return jsonResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"QueryOrders Exception => Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                throw ex;
            }
        }

        public string GetOrderDetail(string order_no)
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
                        string reqUrl = $"{kkdayUrl}/Order/QueryOrderDtl/" + order_no;
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");

                            for (var retry = 0; retry < 5; retry++)
                            {
                                var response = client.SendAsync(request).Result;
                                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    jsonResult = response.Content.ReadAsStringAsync().Result;
                                    break;
                                }
                                else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                                {
                                    Thread.Sleep(1000); continue;
                                }
                                else
                                {
                                    throw new Exception($"{response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                                }
                            }
                        }
                    }
                }

                return jsonResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetOrderDetail Exception => Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                throw ex;
            }
        }

        // Order product/packages + meeting/pickup point (meeting_point)
        public string GetOrderDetailInfo(string order_no)
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
                        string reqUrl = $"{kkdayUrl}/Order/QueryOrderDtlInfo/" + order_no;
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");

                            var response = client.SendAsync(request).Result;
                            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                jsonResult = response.Content.ReadAsStringAsync().Result;
                            }
                            else
                            {
                                throw new Exception($"{response.StatusCode} => {response.Content.ReadAsStringAsync().Result} ");
                            }
                        }
                    }
                }

                return jsonResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetOrderDetailInfo Exception => Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                throw ex;
            }
        }

        public CancelRespModel CancelOrder(CancelReqModel req)
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
                        string reqUrl = $"{kkdayUrl}/Order/Cancel";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");
                            // Add body content
                            request.Content = new StringContent(
                                content: JsonSerializer.Serialize(req),
                                Encoding.UTF8,
                                "application/json"
                            );

                            for (var retry = 0; retry < 5; retry++)
                            {
                                var response = client.SendAsync(request).Result;
                                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    jsonResult = response.Content.ReadAsStringAsync().Result;
                                    break;
                                }
                                else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                                {
                                    Thread.Sleep(1000); continue;
                                }
                                else
                                {
                                    throw new Exception($"{response.StatusCode} => {JsonSerializer.Serialize(jsonResult)} ");
                                }
                            }
                        }
                    }
                }

                return JsonSerializer.Deserialize<CancelRespModel>(jsonResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"QueryOrders Exception => Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                throw ex;
            }
        }

    }
}
