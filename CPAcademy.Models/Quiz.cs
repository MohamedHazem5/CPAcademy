
namespace CPAcademy.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public Lecture Lecture { get; set; }

    }
}
