using System.Collections.Generic;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Quiz
{
	public class QuizQuestion
	{
		public QuizQuestion()
		{
			Answers = new List<QuizAnswer>();
		}

		public int Id { get; set; }

		public string Question { get; set; }

		public QuizQuestionType Type { get; set; }

		public IList<QuizAnswer> Answers { get; set; }
	}
}
