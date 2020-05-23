using System;

namespace GlassZebra.Application.Game.Commands.CreateGame
{
	public class CreateGameResponse
	{
		public Guid GameClientId { get; set; }
		public Guid PlayerClientId { get; set; }
	}
}
