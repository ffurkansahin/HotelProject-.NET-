using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5035/api/DashboardWidgets/StaffCount");
            var value = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.staffCount = value;

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5035/api/DashboardWidgets/BookingCount");
            var value2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.bookingCount = value2;

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5035/api/DashboardWidgets/AppUserCount");
            var value3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.appUserCount = value3;

            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:5035/api/DashboardWidgets/RoomCount");
            var value4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.roomCount = value4;

            return View();
        }
    }
}
