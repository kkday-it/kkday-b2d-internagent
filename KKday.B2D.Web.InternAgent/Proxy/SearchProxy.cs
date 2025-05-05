using System.Text;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;
using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Proxy
{
    public class SearchProxy
    {
        public string Search(SearchReqModel req)
        {
            //連接WMS-API
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

                        req.stats = new List<string>() { "price" };
                        req.facets = new List<string>() { "cat_main", "cat" }; 
   
                        var content = JsonConvert.SerializeObject(req, new JsonSerializerSettings{ NullValueHandling = NullValueHandling.Ignore });
                        Console.WriteLine($"Search Req Payload => {content}");

                        #endregion JSON Payload

                        string reqUrl = $"{kkdayUrl}/Search";
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
                                    throw new Exception($"{response.StatusCode} => {JsonConvert.SerializeObject(jsonResult)} ");
                                }
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
