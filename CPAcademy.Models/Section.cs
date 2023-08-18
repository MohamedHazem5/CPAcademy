namespace CPAcademy.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public int CourseId { get; set; }
        public ICollection<Lecture> Lectures { get; set; }
        public Course Course { get; set;}

    }
}
