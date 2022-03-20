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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingAvailableDuration>>> GetAvailableBookingDurations(DateOnly date, int duration)
        {
            var bookingDurations = await bookingService.GetAvailableBookingDurations(date, duration);

            return Ok(bookingDurations);
        }

        [HttpPost]
        public ActionResult CreateBooking(BookingCreateDto bookingCreateDto)
        {
            var bookingItem = mapper.Map<Booking>(bookingCreateDto);

            bookingService.CreateBooking(bookingItem);

            return Ok();
        }

        [HttpPut]
        public ActionResult CancelBooking(int bookingId)
        {
            bookingService.CancelBooking(bookingId);

            return Ok();
        }
    }
}