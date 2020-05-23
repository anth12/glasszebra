using GlassZebra.Application.Game.Dtos;

namespace GlassZebra.Application.Events.Public
{
	public class GameUpdatedPublicEvent : IPublicEvent
	{
		public GameUpdatedPublicEvent(int gameId, GameDto game)
		{
			GameId = gameId;
			Game = game;
		}

		public int GameId { get; }

		public GameDto Game { get; }
	}
}
