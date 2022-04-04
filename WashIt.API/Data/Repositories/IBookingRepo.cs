using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public interface IBookingRepo : IBaseRepo
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync(DateTime date);

        void CreateBooking(Booking booking);
        void CancelBooking(int bookingId);
        Task<Booking> GetBookingById(int bookingId);
        Task<IEnumerable<Booking>> GetBookingByUserId(int userId);
    }
}