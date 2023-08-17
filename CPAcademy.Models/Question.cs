

namespace CPAcademy.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public ICollection<Choice> Choices { get; set; }
        public Quiz Quiz { get; set; }
        public int QuizId {get;set;}
    }
}
