using System.ComponentModel.DataAnnotations;

namespace CPAcademy.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public int EXP { get; set; }
        public string Bio { get; set; }
        public string  City { get; set; } // change on UI
        public string ImgURL { get; set; }
        public DateTime CDate { get; set; }
    }
}
