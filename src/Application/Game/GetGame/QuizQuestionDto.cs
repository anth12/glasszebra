using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities.Quiz;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Game.GetGame
{
	public class QuizQuestionDto : IMapFrom<QuizQuestion>
	{
		public int Id { get; set; }

		public string Question { get; set; }

		public QuizQuestionType Type { get; set; }

		public IList<string> Answers { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<QuizQuestion, QuizQuestionDto>()
				.ForMember(d => d.Answers, opt => opt.MapFrom(s => s.Answers.Select(a=> a.Answer)));
		}
	}
}
