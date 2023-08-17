

namespace CPAcademy.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public TimeSpan Time { get; set; }
        public int Points { get; set; }
        public int Order { get; set; } // Just for Ordering
        public int SectionId { get; set; }
        public Section Section { get; set; }
        public ICollection<Discussion> Discussions { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Progress> Progresses { get; set; }
    }
}
