﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class ResetPasswordDto
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}