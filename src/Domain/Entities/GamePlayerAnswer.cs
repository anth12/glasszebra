using System;

namespace GlassZebra.Domain.Entities
{
	public class GamePlayerAnswer
	{
		public int Id { get; set; }

		public DateTime AnswerDateUtc { get; set; }

		public int? AnswerId { get; set; }
		public Answer Answer { get; set; }

		public string AnswerValue { get; set; }

		public int GamePlayerId { get; set; }
		public GamePlayer GamePlayer { get; set; }


		public int GameRoundId { get; set; }
		public GameRound GameRound { get; set; }

	}
}
