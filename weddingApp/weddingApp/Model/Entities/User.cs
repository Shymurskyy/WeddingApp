using System.ComponentModel.DataAnnotations;

namespace weddingApp.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]  
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
