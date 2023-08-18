namespace CPAcademy.Models
{
    public class Enroll
    {
        public int Id { get; set; }
        public int Points { get; set; }
        [Range(0, 3)]
        public int Status { get; set; }
        public Course Course { get; set; }
        public User Learner { get; set; }
    }
}
