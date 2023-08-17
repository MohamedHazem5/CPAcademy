namespace CPAcademy.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }

    }
}
