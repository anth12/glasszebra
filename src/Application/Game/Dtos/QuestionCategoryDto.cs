using System.ComponentModel.DataAnnotations;
using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Entities;

namespace GlassZebra.Application.Game.Dtos
{
	public class QuestionCategoryDto : IMapFrom<QuestionCategory>
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
