using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Application.Game.Dtos
{
	public class GameDto : IMapFrom<Domain.Entities.Game>
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string JoinCode { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public GameStatus Status { get; set; }

		[Required]
		public IList<GamePlayerDto> Players { get; set; } = new List<GamePlayerDto>();

		public GameRoundDto CurrentRound { get; set; }

		[Required]
		public int QuestionsPerRound { get; set; }

		[Required]
		public int NumberOfRounds { get; set; }

		public Difficulty[] Difficulty { get; set; }
		public IList<QuestionCategoryDto> Categories { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Domain.Entities.Game, GameDto>()
				.ForMember(d => d.Difficulty,
					opt => opt.MapFrom(s => Enum.GetValues(typeof(Difficulty))
						.Cast<Difficulty>()
						.Where(e=> s.Difficulty.HasFlag(e))
						.ToArray()));
		}
	}
}
