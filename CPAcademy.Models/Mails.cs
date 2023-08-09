

namespace CPAcademy.Models
{
    public class Mails
    {
        public int Id { get; set; }
        public string Template { get; set; }
        public DateTime Date { get; set; }
        public Subscription Subscription { get; set; }
        public int SubscriptionId { get; set; }
        public News News { get; set; }
        public int NewsId { get; set; }
    }
}
