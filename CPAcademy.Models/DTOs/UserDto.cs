using CPAcademy.Models.Enums;

namespace CPAcademy.Models.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public Gender Gender { get; set; }
        public string ImgURL { get; set; }
        public string Token { get; set; }
    }
}
