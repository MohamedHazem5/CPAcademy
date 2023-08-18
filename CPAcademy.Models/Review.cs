namespace CPAcademy.Models
{
    public class Review
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public string Comment { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public int LearnerId { get; set; }
        public User Learner { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
