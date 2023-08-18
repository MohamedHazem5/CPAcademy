namespace CPAcademy.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public Lecture Lecture { get; set; }

        public User Learner { get; set; }
    }
}
