using System.ComponentModel.DataAnnotations;

namespace WashIt.API.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}