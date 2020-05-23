using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Entities;

namespace GlassZebra.Application.Game.Dtos
{
	public class QuestionCategoryDto : IMapFrom<QuestionCategory>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
