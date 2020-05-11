using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Events
{
	public class ParticipantStatusUpdatedEvent : INotification
	{
		public ParticipantStatusUpdatedEvent(ParticipantStatus newStatus, int gameId, int participantId)
		{
			NewStatus = newStatus;
			GameId = gameId;
			ParticipantId = participantId;
		}
		public ParticipantStatus NewStatus { get; }
		public int GameId { get; }
		public int ParticipantId { get; }
	}
}
