
namespace CPAcademy.Models
{
    public class Review
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public string Comment { get; set; }
        public DateTime CDate { get; set; }
        public User Learner { get; set; }
        public Course Course { get; set; }
    }
}
