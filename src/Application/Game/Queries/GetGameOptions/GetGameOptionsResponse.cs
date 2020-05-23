using System.Collections.Generic;
using GlassZebra.Application.Game.Dtos;

namespace GlassZebra.Application.Game.Queries.GetGameOptions
{
	public class GetGameOptionsResponse
	{
		public int MaxQuestionsPerRound { get; set; }
		public int MaxNumberOfRounds { get; set; }
		public IDictionary<string, int> Difficulty { get; set; }
		public IEnumerable<QuestionCategoryDto> Categories { get; set; } = new List<QuestionCategoryDto>();
	}
}
