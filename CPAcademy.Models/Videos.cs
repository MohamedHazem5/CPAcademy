namespace CPAcademy.Models
{
    public class Videos
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public Lecture Lecture { get; set; }
        public int LectureId { get; set; }
    }
}
