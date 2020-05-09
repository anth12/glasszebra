using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities
{
	public class Game : IHaveClientId
	{
		public Game()
		{
			ClientId = Guid.NewGuid();
			Participants = new List<GameParticipant>();
			//GameRounds = new List<GameRound>();
		}

		public int Id { get; set; }

		public Guid ClientId { get; set; }

		public string JoinCode { get; set; }
		public string Name { get; set; }

		public GameStatus Status { get; set; }

		public GameParticipant Owner { get; set; }

		public IList<GameParticipant> Participants { get; set; }
		//public IList<GameRound> GameRounds { get; set; }
	}
}
