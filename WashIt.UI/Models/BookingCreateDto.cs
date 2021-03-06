namespace WashIt.UI.Models
{
    public class BookingCreateDto
    {
        public int UserId { get; set; }
        public int DeviceId { get; set; }
        public int WashingModeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}