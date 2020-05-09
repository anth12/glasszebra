using System.Collections.Generic;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Game.GetGame
{
	public class GameDto : IMapFrom<Domain.Entities.Game>
	{
		public int Id { get; set; }

		public string JoinCode { get; set; }
		public string Name { get; set; }

		public GameStatus Status { get; set; }

		public GameParticipantDto Owner { get; set; }

		public IList<GameParticipantDto> Participants { get; set; }
		//public IList<GameRound> GameRounds { get; set; }
	}
}
