using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public interface IBookingRepo : IBaseRepo
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync(DateOnly date);

        void CreateBooking(Booking booking);
    }
}