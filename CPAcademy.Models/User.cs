using System.ComponentModel.DataAnnotations;

namespace CPAcademy.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public int EXP { get; set; }
        public string Bio { get; set; }
        public string  City { get; set; }
        public string ImgURL { get; set; }
        public DateTime CDate { get; set; }
    }
}
