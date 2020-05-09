using System;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
	public class GameParticipant : IHaveClientId
	{
		public GameParticipant()
		{
			ClientId = Guid.NewGuid();
		}

		public int Id { get; set; }
		
		public Guid ClientId { get; set; }

		public string Name { get; set; }

		public string Image { get; set; }

		public int GameId { get; set; }

		public Game Game { get; set; }

		public int Score { get; set; }
	}
}
