using WashIt.API.Models;

namespace WashIt.API.Data
{
    public static class DbPrep
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Devices.Any())
            {
                Console.WriteLine(" --> Populating Database...");

                context.Devices.AddRange(
                    new Machine() { Name = "Mahchine 01" },
                    new Machine() { Name = "Mahchine 02" }
                    // new Machine() { Name = "Mahchine 03" },
                    // new Machine() { Name = "Mahchine 04" },
                    // new Machine() { Name = "Mahchine 05" },
                    // new Machine() { Name = "Mahchine 06" },
                    // new Machine() { Name = "Mahchine 07" },
                    // new Machine() { Name = "Mahchine 08" },
                    // new Machine() { Name = "Mahchine 09" },
                    // new Machine() { Name = "Mahchine 10" },
                    // new Machine() { Name = "Mahchine 11" },
                    // new Machine() { Name = "Mahchine 12" }
                );

                context.Users.Add(new User() { Username = "farhadh" });

                context.WashingModes.AddRange(new WashingMode() { Temperature = "60 degrees", Name = "Kitchen wash", DurationMinutes = 90 },
                new WashingMode() { Temperature = "40 degrees", Name = "Laundry", DurationMinutes = 60 },
                new WashingMode() { Temperature = "30 degrees", Name = "Hand wash", DurationMinutes = 20 });

                context.Bookings.AddRange(
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("00:30"),
                        EndTime = DateTime.Parse("01:30"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                     new Booking()
                     {
                         Date = DateTime.Now,
                         StartTime = DateTime.Parse("02:30"),
                         EndTime = DateTime.Parse("02:50"),
                         UserId = 1,
                         WashingModeId = 3,
                         DeviceId = 1,
                         Cancelled = false,
                         CheckedIn = false
                     },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("03:30"),
                        EndTime = DateTime.Parse("05:00"),
                        UserId = 1,
                        WashingModeId = 1,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("05:20"),
                        EndTime = DateTime.Parse("05:40"),
                        UserId = 1,
                        WashingModeId = 3,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("07:30"),
                        EndTime = DateTime.Parse("08:30"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("08:40"),
                        EndTime = DateTime.Parse("10:10"),
                        UserId = 1,
                        WashingModeId = 1,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("10:30"),
                        EndTime = DateTime.Parse("12:00"),
                        UserId = 1,
                        WashingModeId = 1,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                   new Booking()
                   {
                       Date = DateTime.Now,
                       StartTime = DateTime.Parse("14:20"),
                       EndTime = DateTime.Parse("14:40"),
                       UserId = 1,
                       WashingModeId = 3,
                       DeviceId = 1,
                       Cancelled = false,
                       CheckedIn = false
                   },

                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("15:30"),
                        EndTime = DateTime.Parse("15:50"),
                        UserId = 1,
                        WashingModeId = 3,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("18:00"),
                        EndTime = DateTime.Parse("19:30"),
                        UserId = 1,
                        WashingModeId = 1,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("20:30"),
                        EndTime = DateTime.Parse("21:30"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("21:30"),
                        EndTime = DateTime.Parse("22:30"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 1,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    // Device 2
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("00:30"),
                        EndTime = DateTime.Parse("02:00"),
                        UserId = 1,
                        WashingModeId = 1,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("02:30"),
                        EndTime = DateTime.Parse("02:50"),
                        UserId = 1,
                        WashingModeId = 3,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("03:30"),
                        EndTime = DateTime.Parse("04:30"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("05:30"),
                        EndTime = DateTime.Parse("07:00"),
                        UserId = 1,
                        WashingModeId = 1,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("07:30"),
                        EndTime = DateTime.Parse("07:50"),
                        UserId = 1,
                        WashingModeId = 3,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("08:40"),
                        EndTime = DateTime.Parse("09:40"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("10:30"),
                        EndTime = DateTime.Parse("12:00"),
                        UserId = 1,
                        WashingModeId = 1,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("14:30"),
                        EndTime = DateTime.Parse("15:30"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },
                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("16:30"),
                        EndTime = DateTime.Parse("16:50"),
                        UserId = 1,
                        WashingModeId = 3,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },

                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("18:30"),
                        EndTime = DateTime.Parse("19:30"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },

                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("19:30"),
                        EndTime = DateTime.Parse("21:00"),
                        UserId = 1,
                        WashingModeId = 1,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    },

                    new Booking()
                    {
                        Date = DateTime.Now,
                        StartTime = DateTime.Parse("22:30"),
                        EndTime = DateTime.Parse("23:30"),
                        UserId = 1,
                        WashingModeId = 2,
                        DeviceId = 2,
                        Cancelled = false,
                        CheckedIn = false
                    }
                );

                context.SaveChanges();
            }
            else
                Console.WriteLine(" --> We already have data");
        }
    }
}