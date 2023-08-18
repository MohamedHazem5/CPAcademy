namespace CPAcademy.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string VideoUrl { get; set; }
        [Range(0, 5)]
        public int SkillLevel { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        public double ListPrice { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public DateTime LastUpdated { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public int InstructorId { get; set; }
        public User Instructor { get; set; }

        public ICollection<Enroll> Enrolls { get; set; }
        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<SkillCourse> Skills { get; set; }



    }
}
