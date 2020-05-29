using System;

namespace GlassZebra.Application.Game.Commands.Setup.CreateGame
{
	public class CreateGameResponse
	{
		public Guid GameClientId { get; set; }
		public Guid PlayerClientId { get; set; }
		public int PlayerId { get; set; }
	}
}
