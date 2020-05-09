using System.Collections.Generic;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Quiz
{
	public class QuizRound
	{
		public QuizRound()
		{
			Questions = new List<QuizQuestion>();
		}

		public int Id { get; set; }

		public Difficulty Difficulty { get; set; }

		public string Name { get; set; }

		public IList<QuizQuestion> Questions { get; set; }
	}
}
