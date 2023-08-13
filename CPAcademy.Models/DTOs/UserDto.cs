using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public string ImgURL { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
