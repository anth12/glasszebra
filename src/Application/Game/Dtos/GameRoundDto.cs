using System;
using System.ComponentModel.DataAnnotations;
using GlassZebra.Application.Common.Mappings;
using GlassZebra.Domain.Entities;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Application.Game.Dtos
{
	public class GameRoundDto : IMapFrom<GameRound>
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public GameType Type { get; set; }

		public QuestionDto CurrentQuestion { get; set; }

		public DateTime CurrentQuestionTimeUtc { get; set; }

		public int CurrentQuestionIndex { get; set; }
	}
}
