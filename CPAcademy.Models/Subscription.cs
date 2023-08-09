namespace CPAcademy.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public DateTime CDate { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }
    }
}
