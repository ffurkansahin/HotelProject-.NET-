using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5035/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> ApproveReservation(ApproveReservationDto approveReservationDto)
        {
            var client =_httpClientFactory.CreateClient();
            approveReservationDto.Status = "Onaylandı";
            var jsonData = JsonConvert.SerializeObject(approveReservationDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await client.PutAsync($"http://localhost:5035/api/Booking/UpdateBookingStatus2?id={approveReservationDto.BookingID}", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
