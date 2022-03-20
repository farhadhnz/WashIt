namespace WashIt.API.DTOs
{
    public class BookingAvailableDuration
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int DeviceId { get; set; }
    }
}