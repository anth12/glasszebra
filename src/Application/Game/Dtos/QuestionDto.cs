using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Entities;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Application.Game.Dtos
{
	public class QuestionDto : IMapFrom<Question>
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Question { get; set; }

		[Required]
		public QuestionType Type { get; set; }

		[Required]
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
