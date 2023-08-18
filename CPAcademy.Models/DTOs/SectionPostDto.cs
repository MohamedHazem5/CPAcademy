namespace CPAcademy.Models.DTOs
{
    public class SectionPostDto
    {
        public string Title { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public int CourseId { get; set; }


    }
}