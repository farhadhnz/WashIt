using WashIt.API.DTOs;
using WashIt.API.Models;

namespace WashIt.API.Service
{
    public interface IBookingService : IBaseService
    {
        Task<IEnumerable<BookingAvailableDuration>> GetAvailableBookingDurations(DateTime date, int duration);
        void CreateBooking(Booking bookingItem);
        void CancelBooking(int bookingId);
        Task<IEnumerable<Booking>> GetBookings(int userId);
    }
}