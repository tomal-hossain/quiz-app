using System.ComponentModel.DataAnnotations;

namespace Service.Dto
{
    public class QuizDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<QuestionDto> Questions { get; set; }
    }
}
