using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Entities.Doodle;
using CleanArchitecture.Domain.Entities.Quiz;

namespace CleanArchitecture.Domain.Entities
{
	public class SeenQuestion
	{
		public int Id { get; set; }

		public Game Game { get; set; }
		public int GameId { get; set; }

		public int? QuizQuestionId { get; set; }
		public QuizQuestion QuizQuestion { get; set; }

		public int? DoodleQuestionId { get; set; }
		public DoodleQuestion DoodleQuestion { get; set; }
	}
}
