using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WashIt.API.DTOs;
using WashIt.API.Models;
using WashIt.API.Service;

namespace WashIt.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;
        private readonly IMapper mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            this.bookingService = bookingService;
            this.mapper = mapper;
        }

        [Route("date/{date}/duration/{duration}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingAvailableDuration>>> GetAvailableBookingDurations(string date, int duration)
        {
            var dateConverted = DateTime.Parse(date);
            var bookingDurations = await bookingService.GetAvailableBookingDurations(dateConverted, duration);

            return Ok(bookingDurations);
        }

        [HttpPost]
        public ActionResult CreateBooking(BookingCreateDto bookingCreateDto)
        {
            var bookingItem = mapper.Map<Booking>(bookingCreateDto);

            bookingService.CreateBooking(bookingItem);

            return Ok();
        }

        [Route("id/{bookingId}/")]
        [HttpPut]
        public ActionResult CancelBooking(int bookingId)
        {
            bookingService.CancelBooking(bookingId);

            return Ok();
        }
    }
}