using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class SubscribeDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
