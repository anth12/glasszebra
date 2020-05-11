using System;

namespace CleanArchitecture.Application.Common.Exceptions
{
	public class UnauthorizedUpdateException : Exception
	{
		public int GameId { get; set; }
		public Guid ParticipantClientId { get; set; }

		public UnauthorizedUpdateException(int gameId, Guid participantClientId)
		{
			GameId = gameId;
			ParticipantClientId = participantClientId;
		}
	}
}
