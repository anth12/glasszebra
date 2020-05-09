using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Game.GetGame
{
	public class GameParticipantDto : IMapFrom<GameParticipant>
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public string Image { get; set; }
	}
}
