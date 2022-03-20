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

        public async void CancelBooking(int bookingId)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == bookingId);
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            booking.Cancelled = true;
            await SaveChangesAsync();
        }

        public async void CreateBooking(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            await _context.Bookings.AddAsync(booking);
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync(DateTime date)
        {
            var bookings = await _context.Bookings
                                .Where(x => x.Date.Equals(date) && !x.Cancelled)
                                .ToListAsync();

            return bookings;
        }

        public async Task<Booking> GetBookingById(int bookingId)
        {
            var bookingItem = await _context.Bookings
                                .FirstOrDefaultAsync(x => x.Id == bookingId);

            return bookingItem;
        }
    }
}