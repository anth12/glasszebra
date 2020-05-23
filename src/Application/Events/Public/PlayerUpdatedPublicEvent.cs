using GlassZebra.Application.Game.Dtos;

namespace GlassZebra.Application.Events.Public
{
	public class PlayerUpdatedPublicEvent : IPublicEvent
	{
		public PlayerUpdatedPublicEvent(int gameId, int playerId, GamePlayerDto player)
		{
			GameId = gameId;
			PlayerId = playerId;
			Player = player;
		}

		public int GameId { get; }
		public int PlayerId { get; }

		public GamePlayerDto Player { get; }
	}
}
