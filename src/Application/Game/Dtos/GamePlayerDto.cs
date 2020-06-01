using System.ComponentModel.DataAnnotations;
using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Entities;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Application.Game.Dtos
{
	public class GamePlayerDto : IMapFrom<GamePlayer>
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public PlayerStatus Status { get; set; }

		public bool IsOwner { get; set; }

		public string Image { get; set; }

		public int TotalScore { get; set; }

		public int RoundScore { get; set; }
	}
}
