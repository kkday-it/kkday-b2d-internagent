using System.Text;
using System.Text.Json;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;


namespace KKday.B2D.Web.InternAgent.Proxy
{
    public class VoucherProxy
    {
        private readonly IConfiguration _config;

        public VoucherProxy(IConfiguration config)
        {
            _config = config;
        }

        public VoucherListRespModel? QueryVoucherList(VoucherListReqModel req)
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
                        string reqUrl = $"{kkdayUrl}/Voucher/QueryVoucherList";
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

                return JsonSerializer.Deserialize<VoucherListRespModel>(jsonResult);
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"QueryVoucherList Exception: Message={ex.Message}, StackTrace={ex.StackTrace}");
                throw ex;
            }
        }
        public VoucherDownloadRespModel? Download(VoucherDownloadReqModel req)
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
                        string reqUrl = $"{kkdayUrl}/Voucher/Download";
                        using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, reqUrl))
                        {
                            request.Headers.Add("Authorization", $"Bearer {authorToken}");
                            request.Headers.Add("Accept", "application/json");
                            // Add body content
                            request.Content = new StringContent(
                                content: JsonSerializer.Serialize(req), // JSON Payload
                                Encoding.UTF8,
                                mediaType: "application/json"
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

                return JsonSerializer.Deserialize< VoucherDownloadRespModel>(jsonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
