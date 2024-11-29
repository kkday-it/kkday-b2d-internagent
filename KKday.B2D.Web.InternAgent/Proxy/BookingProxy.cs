using System.Text;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;
using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Proxy
{
    public class BookingProxy
    {
        private readonly IConfiguration _config;

        public BookingProxy(IConfiguration config)
        {
            _config = config;
        }

        //public string Booking(BookingDataModel req)
        public BookingRespModel Booking(B2DBookingModel req)
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

                        var content = JsonConvert.SerializeObject(req, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                        Console.WriteLine($"Booking Req Payload => {content}");

                        #endregion JSON Payload

                        string reqUrl = $"{kkdayUrl}/Booking";
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
                                throw new Exception($"{response.StatusCode} => {JsonConvert.SerializeObject(jsonResult)} ");
                            }
                        }
                    }
                }

                return JsonConvert.DeserializeObject<BookingRespModel>(jsonResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
