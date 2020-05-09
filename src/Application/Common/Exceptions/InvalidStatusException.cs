using System;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Common.Exceptions
{
	public class InvalidStatusException : Exception
	{
		public InvalidStatusException(GameStatus gameStatus)
		 : base($"Cannot join game in status {gameStatus}")
		{
			GameStatus = gameStatus;
		}

		public GameStatus GameStatus { get; }
	}
}
