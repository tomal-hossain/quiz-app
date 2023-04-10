namespace Domain.Entity
{
    public class Option : BaseEntity
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public bool IsCorrect { get; set; }
    }
}
