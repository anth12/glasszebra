using System;

namespace CleanArchitecture.Application.Common.Exceptions
{
	public class UnauthorizedUpdateException : Exception
	{
		public int GameId { get; set; }
		public Guid PlayerClientId { get; set; }

		public UnauthorizedUpdateException(int gameId, Guid playerClientId)
		{
			GameId = gameId;
			PlayerClientId = playerClientId;
		}
	}
}
