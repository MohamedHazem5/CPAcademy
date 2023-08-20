using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPAcademy.Models.DTOs
{
    public class QuestionPutDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public int QuizId { get; set; }
    }
}