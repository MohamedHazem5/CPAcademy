namespace CPAcademy.Models
{
    public class Article 
    {
        public int Id { get; set; }
        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }
        public string Content { get; set; }
    }
}
