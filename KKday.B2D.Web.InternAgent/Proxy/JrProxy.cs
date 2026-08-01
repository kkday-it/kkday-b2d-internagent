using System.Net;
using System.Text;
using KKday.B2D.Web.InternAgent.AppCode;
using KKday.B2D.Web.InternAgent.Models.Model;
using Newtonsoft.Json;

namespace KKday.B2D.Web.InternAgent.Proxy
{
    public class JrProxy
    {
        public async Task<JrApiResponse<JrSearchMetadata, JrSearchLocationData>> SearchAsync(
            string locale, string state, int start, int count, string query,
            string departureLocationCode, string arrivalLocationCode)
        {
            var qs = new List<string>
            {
                $"locale={Uri.EscapeDataString(locale)}",
                $"state={Uri.EscapeDataString(state)}",
                $"start={start}",
                $"count={count}"
            };
            if (!string.IsNullOrEmpty(query)) qs.Add($"query={Uri.EscapeDataString(query)}");
            if (!string.IsNullOrEmpty(departureLocationCode)) qs.Add($"departure_location_codes={Uri.EscapeDataString(departureLocationCode)}");
            if (!string.IsNullOrEmpty(arrivalLocationCode)) qs.Add($"arrival_location_codes={Uri.EscapeDataString(arrivalLocationCode)}");

            var json = await GetAsync($"/Search?{string.Join("&", qs)}");
            return JsonConvert.DeserializeObject<JrApiResponse<JrSearchMetadata, JrSearchLocationData>>(json);
        }

        public async Task<JrApiResponse<JrMetadata, JrSellableDateData>> GetSellableDateAsync(string locale)
        {
            var json = await GetAsync($"/Search/sellableDate?locale={Uri.EscapeDataString(locale)}");
            return JsonConvert.DeserializeObject<JrApiResponse<JrMetadata, JrSellableDateData>>(json);
        }

        public async Task<JrApiResponse<JrMetadata, JrFactorListData>> GetFactorListAsync(string locale, IEnumerable<string> serviceNames)
        {
            var qs = new List<string> { $"locale={Uri.EscapeDataString(locale)}" };
            foreach (var s in serviceNames ?? Enumerable.Empty<string>())
                qs.Add($"service_name_list={Uri.EscapeDataString(s)}");

            var json = await GetAsync($"/Search/factorList?{string.Join("&", qs)}");
            return JsonConvert.DeserializeObject<JrApiResponse<JrMetadata, JrFactorListData>>(json);
        }

        public async Task<JrApiResponse<JrRouteMetadata, JrRouteResultData>> GetRouteAsync(
            string locale, string state, string depType, string depCode, string depDate,
            string arrType, string arrCode, int page, int perPage, IEnumerable<string> filterParams)
        {
            var qs = new List<string>
            {
                $"locale={Uri.EscapeDataString(locale)}",
                $"state={Uri.EscapeDataString(state)}",
                $"dep_type={Uri.EscapeDataString(depType)}",
                $"dep_code={Uri.EscapeDataString(depCode)}",
                $"dep_date={Uri.EscapeDataString(depDate)}",
                $"arr_type={Uri.EscapeDataString(arrType)}",
                $"arr_code={Uri.EscapeDataString(arrCode)}",
                $"page={page}",
                $"per_page={perPage}"
            };
            foreach (var f in filterParams ?? Enumerable.Empty<string>())
                qs.Add($"FilterParam={Uri.EscapeDataString(f)}");

            var json = await GetAsync($"/Route?{string.Join("&", qs)}");
            return JsonConvert.DeserializeObject<JrApiResponse<JrRouteMetadata, JrRouteResultData>>(json);
        }

        public async Task<JrApiResponse<JrMetadata, JrRouteDetailData>> GetRouteDetailAsync(string serviceName, string locale, string routeKey)
        {
            var body = new JrRouteDetailRequest { service_name = serviceName, locale = locale, route_key = routeKey };
            var json = await PostAsync("/Route/detail", JsonConvert.SerializeObject(body));
            return JsonConvert.DeserializeObject<JrApiResponse<JrMetadata, JrRouteDetailData>>(json);
        }

        public async Task<JrApiResponse<JrMetadata, JrFareDataDto>> GetFareAsync(
            string serviceName, string stepKey, string locale, string goDate, string depSchdCode, string arrSchdCode)
        {
            var body = new JrQueryFareDto
            {
                service_name = serviceName,
                step_key = stepKey,
                locale = locale,
                go_date = goDate,
                dep_schd_code = depSchdCode,
                arr_schd_code = arrSchdCode
            };
            var json = await PostAsync("/Route/fare", JsonConvert.SerializeObject(body));
            return JsonConvert.DeserializeObject<JrApiResponse<JrMetadata, JrFareDataDto>>(json);
        }

        public async Task<JrApiResponse<JrMetadata, JrBookingCheckData>> CheckBookingAsync(JrBookingRequestDto dto)
        {
            var json = await PostAsync("/Booking/check", JsonConvert.SerializeObject(dto));
            return JsonConvert.DeserializeObject<JrApiResponse<JrMetadata, JrBookingCheckData>>(json);
        }

        public async Task<JrApiResponse<JrBookingMetadata, JrBookingResultData>> CreateBookingAsync(JrBookingRequestDto dto)
        {
            var json = await PostAsync("/Booking", JsonConvert.SerializeObject(dto));
            return JsonConvert.DeserializeObject<JrApiResponse<JrBookingMetadata, JrBookingResultData>>(json);
        }

        private static async Task<string> GetAsync(string path)
        {
            using var handler = new HttpClientHandler
            {
                // Ignore Certificate Error!!
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            using var client = new HttpClient(handler);

            for (var retry = 0; retry < 5; retry++)
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, $"{Website.Instance.VertJrApiUrl}{path}");
                request.Headers.Add("Authorization", $"Bearer {Website.Instance.VertJrApiAuthorizeToken}");
                request.Headers.Add("Accept", "application/json");

                var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    await Task.Delay(1000);
                    continue;
                }

                throw new Exception($"{path}: {response.StatusCode} => {await response.Content.ReadAsStringAsync()}");
            }

            throw new Exception($"{path}: exceeded retry attempts");
        }

        private static async Task<string> PostAsync(string path, string content)
        {
            using var handler = new HttpClientHandler
            {
                // Ignore Certificate Error!!
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            using var client = new HttpClient(handler);

            for (var retry = 0; retry < 5; retry++)
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, $"{Website.Instance.VertJrApiUrl}{path}")
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                };
                request.Headers.Add("Authorization", $"Bearer {Website.Instance.VertJrApiAuthorizeToken}");
                request.Headers.Add("Accept", "application/json");

                var response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                    return await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.TooManyRequests)
                {
                    await Task.Delay(1000);
                    continue;
                }

                throw new Exception($"{path}: {response.StatusCode} => {await response.Content.ReadAsStringAsync()}");
            }

            throw new Exception($"{path}: exceeded retry attempts");
        }
    }
}
