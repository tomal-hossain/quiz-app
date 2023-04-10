using Domain.Enums;

namespace Domain.Entity
{
    public class Question : BaseEntity
    {
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
