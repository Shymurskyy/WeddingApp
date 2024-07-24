using System.ComponentModel.DataAnnotations;

namespace weddingApp.Model.DTO_s
{
    public record UserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]  
        public string Password { get; set; }
    }
}
