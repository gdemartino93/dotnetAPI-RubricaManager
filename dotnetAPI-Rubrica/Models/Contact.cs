using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI_Rubrica.Models
{
    public class Contact
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
        public ApplicationUser ApplicationUser { get; set; }
        public string FullName()
        {
            return $"{Name} {Lastname}";
        }
        public override string ToString()
        {
            return $"{Name} {Lastname} {TelephoneNumber} {Email}";
        }


    }
}
