using CPAcademy.Models.Enums;

namespace CPAcademy.Models.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string ImgURL { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public DateTime DataofBirth { get; set; }
    }
}