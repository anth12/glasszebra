using System;
using System.Collections.Generic;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities
{
	public class Question
	{
		public int Id { get; set; }

		public string Text { get; set; }

		public string Hint { get; set; }

		public QuestionType Type { get; set; }

		public Difficulty Difficulty { get; set; }

		public IList<QuestionCategory> Categories { get; set; } = new List<QuestionCategory>();

		public IList<Answer> Answers { get; set; } = new List<Answer>();
	}
}
