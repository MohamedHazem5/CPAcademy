namespace CPAcademy.Models.DTOs
{
    public class BlogDto
    {
        public int AdminId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CDate { get; set; }
        public string ImageUrl { get; set; }
    }
}
