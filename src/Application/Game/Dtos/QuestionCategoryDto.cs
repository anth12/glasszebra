using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Game.Dtos
{
	public class QuestionCategoryDto : IMapFrom<QuestionCategory>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
