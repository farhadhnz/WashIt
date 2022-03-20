namespace WashIt.API.DTOs
{
    public class BookingAvailableDuration
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public int DeviceId { get; set; }
    }
}