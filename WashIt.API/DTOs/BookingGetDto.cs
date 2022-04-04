namespace WashIt.API.DTOs
{
    public class BookingGetDto
    {
        public int UserId { get; set; }
        public int DeviceId { get; set; }
        public int WashingModeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Cancelled { get; set; }
        public bool CheckedIn { get; set; }
    }
}