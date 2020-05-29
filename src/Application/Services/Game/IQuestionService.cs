using System.Threading.Tasks;
using GlassZebra.Domain.Entities;

namespace GlassZebra.Application.Services.Game
{
	public interface IQuestionService
	{
		Task<Question> GetQuestionAsync(Domain.Entities.Game game);
	}
}
