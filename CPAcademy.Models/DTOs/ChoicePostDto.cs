using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class ChoicePostDto
    {
        public int QuestionId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        

    }
}