using System.ComponentModel.DataAnnotations;

namespace WashIt.API.Models
{
    public class WashingMode : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int DurationMinutes { get; set; }
        [Required]
        public string Temperature { get; set; }

    }
}