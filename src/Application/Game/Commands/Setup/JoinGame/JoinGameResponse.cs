using System;

namespace GlassZebra.Application.Game.Commands.Setup.JoinGame
{
	public class JoinGameResponse
	{
		public Guid GameClientId { get; set; }

		public Guid PlayerClientId { get; set; }
		public int PlayerId { get; set; }
	}
}
