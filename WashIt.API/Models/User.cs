using System.ComponentModel.DataAnnotations;

namespace WashIt.API.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }
    }
}