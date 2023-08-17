

namespace CPAcademy.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public User Account { get; set; }
        public int AccountId { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
    }
}
