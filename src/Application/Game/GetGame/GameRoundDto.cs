using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Game.GetGame
{
	public class GameRoundDto : IMapFrom<GameRound>
	{
		public int Id { get; set; }

		public GameType Type { get; set; }
		public int Order { get; set; }

		public QuizRoundDto QuizRound { get; set; }

		public DoodleRoundDto DoodleRound { get; set; }
	}
}
