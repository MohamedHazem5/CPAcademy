using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Gender { get; set; }
        public string ImgURL { get; set; }
        public string Token { get; set; }
    }
}
