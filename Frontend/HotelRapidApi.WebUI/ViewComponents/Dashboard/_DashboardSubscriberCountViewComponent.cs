using HotelRapidApi.WebUI.DTOs.FollowerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelRapidApi.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscriberCountViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/h_emirhan"),
                Headers =
    {
        { "x-rapidapi-key", "047a17087bmsh5d1af7361331700p13e5fdjsne8c480915cd5" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowerDto resultInstagramFollowerDto = JsonConvert.DeserializeObject<ResultInstagramFollowerDto>(body);

                return View(resultInstagramFollowerDto);
            }

        }
    }
}
