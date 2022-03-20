using WashIt.API.Data.Repositories;
using WashIt.API.DTOs;

namespace WashIt.API.Service
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IBookingRepo bookingRepo;
        private readonly IDeviceRepo deviceRepo;

        public BookingService(IBaseRepo baseRepo, IBookingRepo bookingRepo, IDeviceRepo deviceRepo) : base(baseRepo)
        {
            this.deviceRepo = deviceRepo;
            this.bookingRepo = bookingRepo;
        }

        public void CancelBooking(int bookingId)
        {
            bookingRepo.CancelBooking(bookingId);
        }

        public void CreateBooking(Models.Booking bookingItem)
        {
            bookingRepo.CreateBooking(bookingItem);
        }

        public async Task<IEnumerable<BookingAvailableDuration>> GetAvailableBookingDurations(DateOnly date, int duration)
        {
            // Get All bookings of the date
            var allBookings = await bookingRepo.GetAllBookingsAsync(date);

            // We assume that the machines work 24 hours 

            // Get All the machines
            var machines = await deviceRepo.GetAllDevicesAsync();

            var listOfAvailable = new List<BookingAvailableDuration>();

            // Loop throught the machines and find available times for each of the machines
            foreach (var machine in machines)
            {
                // Get the busy durations of the machine
                var busyDurations = allBookings
                                   .Where(x => x.DeviceId == machine.Id)
                                   .Select(x => new BookingAvailableDuration()
                                   {
                                       StartTime = x.StartTime,
                                       EndTime = x.EndTime,
                                       DeviceId = machine.Id
                                   })
                                   .OrderBy(x => x.StartTime);

                var endTime = TimeOnly.Parse("00:00");

                foreach (var item in busyDurations)
                {
                    if (endTime - item.StartTime >= TimeSpan.FromMinutes(duration))
                    {
                        listOfAvailable.Add(new BookingAvailableDuration
                        {
                            StartTime = endTime,
                            EndTime = item.StartTime,
                            DeviceId = machine.Id
                        });
                    }
                    endTime = item.EndTime;
                }
            }

            return listOfAvailable;
        }
    }
}