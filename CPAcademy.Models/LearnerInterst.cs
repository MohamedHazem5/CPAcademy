﻿

namespace CPAcademy.Models
{
    public class LearnerInterst
    {
        public int Id { get; set; }
        public User Learner { get; set; }
        public int LearnerId { get; set; }
        public int InterstId { get; set; }
        public Interst Interst { get; set; }

    }
}
