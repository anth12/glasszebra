using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Services.Game
{
	internal class GameCodeService : IGameCodeService
	{
		private readonly IApplicationDbContext _context;

		public GameCodeService(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<string> CreateUniqueCodeAsync()
		{
			var length = 4;
			while (true)
			{
				var code = CreateCode(length);

				var codeExists = await _context.Games.AnyAsync(g => g.JoinCode == code && g.Status != GameStatus.Over);

				if (!codeExists)
					return code;

				length++;
			}
		}

		public string CreateCode(int length)
		{
			return Guid.NewGuid().ToString("N").Substring(0, length);
		}
	}
}
