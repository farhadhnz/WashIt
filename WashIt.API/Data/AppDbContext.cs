using Microsoft.EntityFrameworkCore;
using WashIt.API.Models;

namespace WashIt.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WashingMode> WashingModes { get; set; }
        public DbSet<WaitingListItem> WaitingListItems { get; set; }

    }
}