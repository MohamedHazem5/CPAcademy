﻿namespace CPAcademy.Models
{
    public class Certificate
    {
        [Key]
        public int SerialNumber { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Url { get; set; }
        public Course Course { get; set; }
        public User Learner { get; set; }
    }
}
