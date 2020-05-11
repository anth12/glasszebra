using System;

namespace CleanArchitecture.Application.Game.Commands
{
	public class ParticipantGameCommand
	{
		public Guid GameClientId { get; set; }
		public Guid ParticipantClientId { get; set; }
	}
}
