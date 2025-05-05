using System;
using KKday.B2D.Web.InternAgent.AppCode;
using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Proxy
{
	public class CommonProxy
	{
        // Country and City List
        public string GetCountryInfot(string locale)
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
                        string reqUrl = $"{kkdayUrl}/Common/QueryCountryInfo?locale={locale}";
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

        // Marketing State
        public string GetState(string locale)
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
                        string reqUrl = $"{kkdayUrl}/Common/QueryCountryInfo?locale={locale}";
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

