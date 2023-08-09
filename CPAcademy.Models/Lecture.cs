

namespace CPAcademy.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CDate { get; set; }
        public DateTime Time { get; set; }
        public int Points { get; set; }
        public int Order { get; set; } // Just for Ordering
        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
