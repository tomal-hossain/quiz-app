using System.ComponentModel.DataAnnotations;

namespace Service.Dto
{
    public class OptionDto
    {
        public int? Id { get; set; }

        [Required]
        public string Text { get; set; }
        public bool? IsCorrect { get; set; }
    }
}
