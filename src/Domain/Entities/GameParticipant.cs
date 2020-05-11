using System;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enums;

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

		public ParticipantStatus Status { get; set; }

		public bool IsOwner { get; set; }

		public string Name { get; set; }

		public string Image { get; set; }

		public int GameId { get; set; }

		public Game Game { get; set; }

		public int TotalScore { get; set; }

		public int RoundScore { get; set; }
	}
}
