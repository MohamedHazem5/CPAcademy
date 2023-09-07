using CPAcademy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class UserEditDto
    {
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string ImgURL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public DateTime DataofBirth { get; set; }
    }
}