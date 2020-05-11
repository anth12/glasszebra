using System;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities
{
	public class GameRound
	{
		public int Id { get; set; }
		
		public GameType Type { get; set; }

		public int CurrentQuestionId { get; set; }
		public Question CurrentQuestion { get; set; }
		
		public DateTime CurrentQuestionTimeUtc { get; set; }

		public int CurrentQuestionIndex { get; set; }
	}
}
