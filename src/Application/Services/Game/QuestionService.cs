using System;
using System.Linq;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Services.Game
{
	internal class QuestionService : IQuestionService
	{
		private readonly IApplicationDbContext _context;

		public QuestionService(IApplicationDbContext context)
		{
			_context = context;
		}

		public Task<Question> GetQuestionAsync(Domain.Entities.Game game)
		{
			var seenQuestions = _context.SeenQuestions.Where(s => s.GameId == game.Id);

			var categoryIds = game.Categories.Select(c => c.Id);

			var unseenQuestions = _context.Questions
				.Where(q=> (q.Type & game.QuestionTypes) == q.Type)
				.Where(q=> q.Categories.Any(c=> categoryIds.Contains(c.Id) && (q.Difficulty & game.Difficulty) == q.Difficulty))
				.Where(q => !seenQuestions.Any(s => s.QuestionId == q.Id))
				.OrderBy(q=> Guid.NewGuid());

			return unseenQuestions.FirstOrDefaultAsync();
		}
	}
}
