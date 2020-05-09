using System;
using CleanArchitecture.Application.Game.GetGame;

namespace CleanArchitecture.Application.Game.JoinGame
{
	public class JoinGameResponse
	{
		public Guid GameClientId { get; set; }
		public GameDto Game { get; set; }

		public Guid ParticipantClientId { get; set; }
		public GameParticipantDto Participant { get; set; }
	}
}
