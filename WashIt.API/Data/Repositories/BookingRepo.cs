using Microsoft.EntityFrameworkCore;
using WashIt.API.Models;

namespace WashIt.API.Data.Repositories
{
    public class BookingRepo : BaseRepo, IBookingRepo
    {
        private readonly AppDbContext _context;
        public BookingRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async void CreateBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            await _context.Bookings.AddAsync(booking);
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync(DateOnly date)
        {
            var bookings = await _context.Bookings
                                .Where(x => x.Date.Equals(date) && !x.Cancelled)
                                .ToListAsync();

            return bookings;
        }
    }
}