using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetAPI_Rubrica.Models.DTO
{
    public class ContactEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string TelephoneNumber { get; set; }
        public string? Email { get; set; }

    }
}
