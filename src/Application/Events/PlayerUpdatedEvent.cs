using MediatR;

namespace CleanArchitecture.Application.Events
{
	public class PlayerUpdatedEvent : INotification
	{
		public PlayerUpdatedEvent(bool newPlayer, int gameId, int playerId)
		{
			NewPlayer = newPlayer;
			GameId = gameId;
			PlayerId = playerId;
		}

		public bool NewPlayer { get; }
		public int GameId { get; }
		public int PlayerId { get; }

	}
}
