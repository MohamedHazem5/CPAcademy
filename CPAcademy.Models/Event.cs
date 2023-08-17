

namespace CPAcademy.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public string Content { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public User Admin { get; set; }
        public int AdminId { get; set; }
    }
}
