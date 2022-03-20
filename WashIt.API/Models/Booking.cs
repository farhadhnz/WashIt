using System.ComponentModel.DataAnnotations;

namespace WashIt.API.Models
{
    public class Booking : BaseEntity
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DeviceId { get; set; }
        [Required]
        public int WashingModeId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public bool Cancelled { get; set; }
        [Required]
        public bool CheckedIn { get; set; }
    }
}