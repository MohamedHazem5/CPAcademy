namespace CPAcademy.Models
{
    public class Discussion
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public Lecture Lecture { get; set; }
        public User Learner { get; set; }
    }
}
