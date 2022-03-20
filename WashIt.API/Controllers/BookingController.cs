using Microsoft.AspNetCore.Mvc;
using WashIt.API.DTOs;
using WashIt.API.Service;

namespace WashIt.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingAvailableDuration>>> GetAvailableBookingDurations(DateOnly date, int duration)
        {
            var bookingDurations = await bookingService.GetAvailableBookingDurations(date, duration);

            return Ok(bookingDurations);
        }
    }
}