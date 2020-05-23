using System;
using System.Collections.Generic;
using GlassZebra.Domain.Common;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Domain.Entities
{
	public class Game : IHaveClientId
	{
		public Game()
		{
			ClientId = Guid.NewGuid();
		}

		public int Id { get; set; }

		public Guid ClientId { get; set; }

		public string JoinCode { get; set; }
		public string Name { get; set; }

		public GameStatus Status { get; set; }
		
		public IList<GamePlayer> Players { get; set; } = new List<GamePlayer>();

		public GameRound CurrentRound { get; set; }

		public int QuestionsPerRound { get; set; }
		public int NumberOfRounds { get; set; }
		public Difficulty Difficulty { get; set; }
		public IList<QuestionCategory> Categories { get; set; } = new List<QuestionCategory>();
	}
}
