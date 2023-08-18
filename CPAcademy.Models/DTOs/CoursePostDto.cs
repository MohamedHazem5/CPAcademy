namespace CPAcademy.Models.DTOs
{
    public class CoursePostDto
    {
        public string Title { get; set; }
        public string About { get; set; }
        public string VideoUrl { get; set; }
        public int SkillLevel { get; set; }
        public int Duration { get; set; }
        public double Price { get; set; }
        public double ListPrice { get; set; }
        public DateTime LastUpdated { get; set; }
        public int CategoryId { get; set; }
        public int TopicId { get; set; }
        public int InstructorId { get; set; }
    }
}