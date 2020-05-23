using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Application.Game.Dtos
{
	public class GameDto : IMapFrom<Domain.Entities.Game>
	{
		public int Id { get; set; }

		public string JoinCode { get; set; }
		public string Name { get; set; }

		public GameStatus Status { get; set; }
		
		public IList<GamePlayerDto> Players { get; set; }

		public GameRoundDto CurrentRound { get; set; }

		public int QuestionsPerRound { get; set; }
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
