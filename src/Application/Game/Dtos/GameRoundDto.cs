using System;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Game.Dtos
{
	public class GameRoundDto : IMapFrom<GameRound>
	{
		public int Id { get; set; }

		public GameType Type { get; set; }

		public QuestionDto CurrentQuestion { get; set; }

		public DateTime CurrentQuestionTimeUtc { get; set; }

		public int CurrentQuestionIndex { get; set; }
	}
}
