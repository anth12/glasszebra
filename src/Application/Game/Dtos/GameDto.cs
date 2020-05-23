using System.Collections.Generic;
using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Application.Game.Dtos
{
	public class GameDto : IMapFrom<Domain.Entities.Game>
	{
		public int Id { get; set; }

		public string JoinCode { get; set; }
		public string Name { get; set; }

		public GameStatus Status { get; set; }

		public GamePlayerDto Owner { get; set; }

		public IList<GamePlayerDto> Players { get; set; }

		public GameRoundDto CurrentRound { get; set; }

		public int QuestionsPerRound { get; set; }
		public int NumberOfRounds { get; set; }
		public Difficulty Difficulty { get; set; }
		public IList<QuestionCategoryDto> Categories { get; set; }
	}
}
