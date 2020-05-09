using CleanArchitecture.Domain.Entities.Doodle;
using CleanArchitecture.Domain.Entities.Quiz;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities
{
	public class GameRound
	{
		public int Id { get; set; }
		
		public GameType Type { get; set; }
		public int Order { get; set; }

		public int? QuizRoundId { get; set; }
		public QuizRound QuizRound { get; set; }

		public int? DoodleRoundId { get; set; }
		public DoodleRound DoodleRound { get; set; }
	}
}
