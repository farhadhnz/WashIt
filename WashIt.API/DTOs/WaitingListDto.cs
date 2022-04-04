using System.ComponentModel.DataAnnotations;

namespace WashIt.API.DTOs
{
    public class WaitingListDto
    {
        [Required]
        public int WashingModeId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public bool Notified { get; set; }
    }
}