using GlassZebra.Application.Game.Dtos;

namespace GlassZebra.Application.Events.Public
{
	public class RoundUpdatedPublicEvent : IPublicEvent
	{
		public RoundUpdatedPublicEvent(bool newRound, int gameId, GameRoundDto round)
		{
			GameId = gameId;
			Round = round;
		}

		public int GameId { get; }

		public bool NewRound { get; set; }

		public GameRoundDto Round { get; }
	}
}
