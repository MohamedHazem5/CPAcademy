using System.ComponentModel.DataAnnotations;

namespace CPAcademy.Models
{
    public class Certificate
    {
        [Key]
        public int SerialNumber { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int LearnerId { get; set; }
        public User Learner { get; set; }
    }
}
