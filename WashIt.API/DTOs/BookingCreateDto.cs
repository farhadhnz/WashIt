using System.ComponentModel.DataAnnotations;

namespace WashIt.API.DTOs
{
    public class BookingCreateDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DeviceId { get; set; }
        [Required]
        public int WashingModeId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }

    }
}