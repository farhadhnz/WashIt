using WashIt.API.DTOs;

namespace WashIt.API.Service
{
    public interface IBookingService : IBaseService
    {
        Task<IEnumerable<BookingAvailableDuration>> GetAvailableBookingDurations(DateOnly date, int duration);
    }
}