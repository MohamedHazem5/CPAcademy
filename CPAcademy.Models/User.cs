using CPAcademy.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CPAcademy.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int EXP { get; set; }
        public string Bio { get; set; }
        public string  City { get; set; } // change on UI
        public string ImgURL { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public Photo Photo { get; set; } 
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Enroll> Enrolls { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Discussion> Discussions { get; set; }
        public ICollection<Progress> Progresses { get; set; }
    }
}
