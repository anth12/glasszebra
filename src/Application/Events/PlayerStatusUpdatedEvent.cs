using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Events
{
	public class PlayerStatusUpdatedEvent : INotification
	{
		public PlayerStatusUpdatedEvent(PlayerStatus newStatus, int gameId, int playerId)
		{
			NewStatus = newStatus;
			GameId = gameId;
			PlayerId = playerId;
		}
		public PlayerStatus NewStatus { get; }
		public int GameId { get; }
		public int PlayerId { get; }
	}
}
