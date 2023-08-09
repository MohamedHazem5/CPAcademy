

namespace CPAcademy.Models
{
    public class Mail
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public User Account { get; set; }
        public int AccountId { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
    }
}
