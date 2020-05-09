using System;

namespace CleanArchitecture.Application.Game.CreateGame
{
	public class GetGameResponse
	{
		public Guid GameClientId { get; set; }
		public Guid ParticipantClientId { get; set; }
		public string JoinCode { get; set; }
	}
}
