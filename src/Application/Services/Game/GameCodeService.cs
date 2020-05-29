using System;
using System.Text;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Services.Game
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

		private static readonly Random Random = new Random();

		/// <summary>
		/// Skip I & O
		/// </summary>
		private static readonly char[] ValidAlphabeticalCharacters = "ABCDEFGHJKLMNPQRSTUVWXYZ".ToCharArray();
		private static readonly char[] ValidNumericCharacters = "012346789".ToCharArray();

		public string CreateCode(int length)
		{
			var result = new StringBuilder(length);
			for (var i = 0; i < length; i++)
			{
				result.Append(i % 2 == 0
					? ValidAlphabeticalCharacters[Random.Next(0, ValidAlphabeticalCharacters.Length - 1)]
					: ValidNumericCharacters[Random.Next(0, ValidNumericCharacters.Length - 1)]
				);
			}

			return result.ToString();
		}
	}
}
