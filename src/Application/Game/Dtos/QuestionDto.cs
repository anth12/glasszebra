using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Game.Dtos
{
	public class QuestionDto : IMapFrom<Question>
	{
		public int Id { get; set; }

		public string Question { get; set; }

		public QuestionType Type { get; set; }

		public Difficulty Difficulty { get; set; }

		public IList<QuestionCategoryDto> Categories { get; set; }

		public IList<string> Answers { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Question, QuestionDto>()
				.ForMember(d => d.Answers, 
				opt => opt.MapFrom(s => s.Answers.Select(a=> a.Text)));
		}
	}
}
