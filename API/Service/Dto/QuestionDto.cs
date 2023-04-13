using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Service.Dto
{
    public class QuestionDto
    {
        public int? Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public QuestionType QuestionType { get; set; }

        public ICollection<OptionDto> Options { get; set; }
    }
}
