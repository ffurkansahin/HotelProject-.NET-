using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        public readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            return Ok(values);
        }
        [HttpPut("UpdateBookingStatus")]
        public IActionResult UpdateBookingStatus(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok();
        }
        [HttpGet("ChangeBookingStatusToApproved")]
        public IActionResult ChangeBookingStatusToApproved(int id)
        {
            _bookingService.TChangeBookingStatusToApproved(id);
            return Ok();
        }
        [HttpGet("ChangeBookingStatusToCanceled")]
        public IActionResult ChangeBookingStatusToCanceled(int id)
        {
            _bookingService.TChangeBookingStatusToCanceled(id);
            return Ok();
        }
        [HttpGet("ChangeBookingStatusToCall")]
        public IActionResult ChangeBookingStatusToCall(int id)
        {
            _bookingService.TChangeBookingStatusToCall(id);
            return Ok();
        }
    }
}
