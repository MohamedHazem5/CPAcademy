namespace CPAcademy.Models
{
    public class Quiz 
    {
        public int Id { get; set; }
        public ICollection<Question> Questions { get; set; }
        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }

    }
}
