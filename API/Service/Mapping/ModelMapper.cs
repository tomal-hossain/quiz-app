using AutoMapper;
using Domain.Entity;
using Service.Dto;

namespace Service.Mapping
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<Option, OptionDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Quiz, QuizDto>().ReverseMap();
            CreateMap<Quiz, QuizVM>();
        }
    }
}
