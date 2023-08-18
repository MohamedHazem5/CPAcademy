namespace CPAcademy.Models.DTOs
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CDate { get; set; } 
        public ICollection<Lecture> Lectures { get; set; }

    }
}