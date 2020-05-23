using System.Collections.Generic;
using CleanArchitecture.Application.Game.Dtos;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Game.Queries.GetGameOptions
{
	public class GetGameOptionsResponse
	{
		public int MaxQuestionsPerRound { get; set; }
		public int MaxNumberOfRounds { get; set; }
		public Difficulty[] Difficulty { get; set; }
		public IEnumerable<QuestionCategoryDto> Categories { get; set; } = new List<QuestionCategoryDto>();
	}
}
