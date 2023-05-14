using System.ComponentModel.DataAnnotations;

namespace dotnetAPI_Rubrica.Models.DTO
{
    public class ContactEditDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string TelephoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
