namespace CPAcademy.Models
{
    public class LearnerInterest
    {
        public int Id { get; set; }
        public User Learner { get; set; }
        public int LearnerId { get; set; }
        public int InterstId { get; set; }
        public Interest Interst { get; set; }

    }
}
