using CleanArchitecture.Application.Game.Dtos;

namespace CleanArchitecture.Application.Events.Public
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
