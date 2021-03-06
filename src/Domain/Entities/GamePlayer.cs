﻿using System;
using GlassZebra.Domain.Common;
using GlassZebra.Domain.Enums;

namespace GlassZebra.Domain.Entities
{
	public class GamePlayer : IHaveClientId
	{
		public GamePlayer()
		{
			ClientId = Guid.NewGuid();
		}

		public int Id { get; set; }
		
		public Guid ClientId { get; set; }

		public PlayerStatus Status { get; set; } = PlayerStatus.Disconnected;

		public bool IsOwner { get; set; }

		public string Name { get; set; }

		public string Image { get; set; }

		public int GameId { get; set; }

		public Game Game { get; set; }

		public int TotalScore { get; set; }

		public int RoundScore { get; set; }

		public GamePlayerAnswer CurrentAnswer { get; set; }
	}
}
