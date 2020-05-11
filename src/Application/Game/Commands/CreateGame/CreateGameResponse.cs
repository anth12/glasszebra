using System;

namespace CleanArchitecture.Application.Game.Commands.CreateGame
{
	public class CreateGameResponse
	{
		public Guid GameClientId { get; set; }
		public Guid ParticipantClientId { get; set; }
	}
}
