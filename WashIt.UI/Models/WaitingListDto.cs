namespace WashIt.UI.Models
{
    public class WaitingListDto
    {
        public int WashingModeId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Notified { get; set; }
    }
}