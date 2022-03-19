using System.ComponentModel.DataAnnotations;

namespace WashIt.API.Models
{
    public class Device : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
    }
}