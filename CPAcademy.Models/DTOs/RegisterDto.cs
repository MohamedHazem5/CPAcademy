using CPAcademy.Models.Enums;
using System.ComponentModel;

namespace CPAcademy.Models.DTOs
{
    public class RegisterDto
    {
        [Required] public string Email { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}