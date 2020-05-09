
namespace CleanArchitecture.Application.Game.UpdateParticipant
{
	public class ParticipantUpdatedEvent
	{
		public ParticipantUpdatedEvent(bool newParticipant, int gameId, int participantId)
		{
			NewParticipant = newParticipant;
			GameId = gameId;
			ParticipantId = participantId;
		}

		public bool NewParticipant { get; }
		public int GameId { get; }
		public int ParticipantId { get; }

	}
}
