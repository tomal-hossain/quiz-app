using AutoMapper;
using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Service.Dto;

namespace Service.Services
{
    public interface IAdminService
    {
        Task<bool> CreateQuiz(QuizDto quiz);
        Task<IEnumerable<QuizVM>> GetQuizes();
    }

    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<AdminService> _logger;
        public AdminService(ApplicationDbContext dbContext, ILogger<AdminService> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> CreateQuiz(QuizDto quiz)
        {
            try
            {
                var newQuiz = _mapper.Map<Quiz>(quiz);
                _dbContext.Quizzes.Add(newQuiz);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while creating quiz", ex);
                return false;
            }
        }

        public async Task<IEnumerable<QuizVM>> GetQuizes()
        {
            var quizes = await _dbContext.Quizzes.ToListAsync();
            return _mapper.Map<IEnumerable<QuizVM>>(quizes);
        }
    }
}
