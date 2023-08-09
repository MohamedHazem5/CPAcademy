

namespace CPAcademy.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }

        public User Learner { get; set; }
        public int LearnerId { get; set; }
    }
}
