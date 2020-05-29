using System;
using System.Collections.Generic;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Domain.Entities
{
	public class GameRound
	{
		public int Id { get; set; }
		
		//public GameType Type { get; set; }

		public int CurrentQuestionId { get; set; }
		public Question CurrentQuestion { get; set; }
		
		public DateTime CurrentRoundStartTimeUtc { get; set; }

		public DateTime CurrentQuestionStartTimeUtc { get; set; }
		public DateTime CurrentQuestionEndTimeUtc { get; set; }

		public int CurrentRoundIndex { get; set; }
		public int CurrentQuestionIndex { get; set; }

		public ICollection<GamePlayerAnswer> PlayerAnswers { get; set; } = new List<GamePlayerAnswer>();
	}
}
