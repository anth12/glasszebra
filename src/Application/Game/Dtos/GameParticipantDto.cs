using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Game.Dtos
{
	public class GameParticipantDto : IMapFrom<GameParticipant>
	{
		public int Id { get; set; }

		public string Name { get; set; }
		
		public ParticipantStatus Status { get; set; }

		public bool IsOwner { get; set; }

		public string Image { get; set; }

		public int TotalScore { get; set; }

		public int RoundScore { get; set; }
	}
}
