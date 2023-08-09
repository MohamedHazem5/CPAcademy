
namespace CPAcademy.Models
{
    public class Articles
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }

    }
}
