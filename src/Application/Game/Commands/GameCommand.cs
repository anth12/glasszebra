using System;

namespace CleanArchitecture.Application.Game.Commands
{
	public class PlayerGameCommand
	{
		public Guid GameClientId { get; set; }
		public Guid PlayerClientId { get; set; }
	}
}
