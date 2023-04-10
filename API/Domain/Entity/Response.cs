namespace Domain.Entity
{
    public class Response : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public DateTime ResponseTime { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
