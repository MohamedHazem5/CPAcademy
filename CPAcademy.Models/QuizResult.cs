using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPAcademy.Models
{
    public class QuizResult
    {
        public int Id { get; set; }
        public int LearnerId { get; set; }
        public User Learner { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
