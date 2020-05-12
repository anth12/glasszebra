using System;
using CleanArchitecture.Application.Game.Dtos;

namespace CleanArchitecture.Application.Game.Commands.JoinGame
{
	public class JoinGameResponse
	{
		public Guid GameClientId { get; set; }
		public GameDto Game { get; set; }

		public Guid PlayerClientId { get; set; }
		public GamePlayerDto Player { get; set; }
	}
}
