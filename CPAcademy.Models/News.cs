

namespace CPAcademy.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Template { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
    }
}
