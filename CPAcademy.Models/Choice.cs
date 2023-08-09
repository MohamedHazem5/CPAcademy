
namespace CPAcademy.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
