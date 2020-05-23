using System;

namespace GlassZebra.Application.Game.Commands
{
	public class PlayerGameCommand
	{
		public Guid GameClientId { get; set; }
		public Guid PlayerClientId { get; set; }
	}
}
