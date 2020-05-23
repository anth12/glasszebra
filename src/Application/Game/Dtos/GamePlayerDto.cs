using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Entities;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Application.Game.Dtos
{
	public class GamePlayerDto : IMapFrom<GamePlayer>
	{
		public int Id { get; set; }

		public string Name { get; set; }
		
		public PlayerStatus Status { get; set; }

		public bool IsOwner { get; set; }

		public string Image { get; set; }

		public int TotalScore { get; set; }

		public int RoundScore { get; set; }
	}
}
