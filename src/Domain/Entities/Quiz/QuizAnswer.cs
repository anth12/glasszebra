namespace CleanArchitecture.Domain.Entities.Quiz
{
	public class QuizAnswer
	{
		public int Id { get; set; }

		public int QuizQuestionId { get; set; }

		public bool IsCorrect { get; set; }

		public string Answer { get; set; }
	}
}
