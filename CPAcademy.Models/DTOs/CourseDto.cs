namespace CPAcademy.Models.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string VideoUrl { get; set; }
        public int SkillLevel { get; set; }
        public double AvgRate { get; set; }
        public TimeSpan Duration { get; set; }
        public int NumberOfLecture { get; set; }
        public double Price { get; set; }
        public double ListPrice { get; set; }
        public DateTime CDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public Category Category { get; set; }
        public Topic Topic { get; set; }
        public User Instructor { get; set; }
    }
}