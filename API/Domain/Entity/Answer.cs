namespace Domain.Entity
{
    public class Answer : BaseEntity
    {
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int ResponseId { get; set; }
        public Response Response { get; set; }
    }
}
