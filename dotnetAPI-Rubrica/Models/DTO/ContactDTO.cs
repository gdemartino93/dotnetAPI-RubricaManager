using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnetAPI_Rubrica.Models.DTO
{
    public class ContactDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string TelephoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
