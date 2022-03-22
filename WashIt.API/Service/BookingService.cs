using WashIt.API.Data.Repositories;
using WashIt.API.DTOs;

namespace WashIt.API.Service
{
    public class BookingService : BaseService, IBookingService
    {
        private readonly IBaseRepo baseRepo;
        private readonly IBookingRepo bookingRepo;
        private readonly IDeviceRepo deviceRepo;
        private readonly IWaitListRepo waitListRepo;
        private readonly INotificationSender notificationSender;
        private readonly IUserRepo userRepo;
        private readonly IWashingModeRepo washingModeRepo;

        public BookingService(IBaseRepo baseRepo, IBookingRepo bookingRepo,
                              IDeviceRepo deviceRepo, IWaitListRepo waitListRepo,
                              INotificationSender notificationSender, IUserRepo userRepo,
                              IWashingModeRepo washingModeRepo) : base(baseRepo)
        {
            this.waitListRepo = waitListRepo;
            this.notificationSender = notificationSender;
            this.userRepo = userRepo;
            this.washingModeRepo = washingModeRepo;
            this.deviceRepo = deviceRepo;
            this.baseRepo = baseRepo;
            this.bookingRepo = bookingRepo;
        }

        public async void CancelBooking(int bookingId)
        {
            bookingRepo.CancelBooking(bookingId);

            // Fire Waiting List Notification

            // Get the booking item
            var bookingItem = await bookingRepo.GetBookingById(bookingId);

            // Get all the items in the waiting list for that date
            var waitingListItems = (await waitListRepo.GetWaitingListItems(bookingItem.Date))
                                    .OrderBy(x => x.DateAdded).ToList();


            foreach (var item in waitingListItems)
            {
                // Get User
                var user = await userRepo.GetUserById(item.UserId);

                // Get WashingMode
                var washingMode = await washingModeRepo.GetWashingModeById(item.WashingModeId);

                var availableTimes = await GetAvailableBookingDurations(bookingItem.Date, washingMode.DurationMinutes);
                if (availableTimes.Any(x => x.EndTime - x.StartTime >= TimeSpan.FromMinutes(washingMode.DurationMinutes)))
                {
                    notificationSender.Send(user);

                    // set user as notified
                    waitListRepo.SetUserAsNotified(item);
                }
            }
        }

        public void CreateBooking(Models.Booking bookingItem)
        {
            bookingRepo.CreateBooking(bookingItem);
        }

        public async Task<IEnumerable<BookingAvailableDuration>> GetAvailableBookingDurations(DateTime date, int duration)
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

                var endTime = DateTime.Parse("00:00");

                foreach (var item in busyDurations)
                {
                    if (item.StartTime.TimeOfDay - endTime.TimeOfDay >= TimeSpan.FromMinutes(duration))
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