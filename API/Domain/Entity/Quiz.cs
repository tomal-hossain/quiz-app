namespace Domain.Entity
{
    public class Quiz : BaseEntity
    {
        public Quiz()
        {
            AccessIdentifier = Guid.NewGuid().ToString();
            IsActive = true;
        }

        public string AccessIdentifier { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Response> Responses { get; set; }
    }
}
