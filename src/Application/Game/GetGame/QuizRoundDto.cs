using System.Collections.Generic;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities.Quiz;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Game.GetGame
{
	public class QuizRoundDto : IMapFrom<QuizRound>
	{
		public QuizRoundDto()
		{
			Questions = new List<QuizQuestionDto>();
		}

		public int Id { get; set; }

		public Difficulty Difficulty { get; set; }

		public string Name { get; set; }

		public IList<QuizQuestionDto> Questions { get; set; }
	}
}
