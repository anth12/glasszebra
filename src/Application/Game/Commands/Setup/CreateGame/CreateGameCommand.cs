using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Services.Game;
using GlassZebra.Domain.Entities;
using GlassZebra.Domain.Enums;
using MediatR;

namespace GlassZebra.Application.Game.Commands.Setup.CreateGame
{
	public class CreateGameCommand : IRequest<CreateGameResponse>
	{
		public string Name { get; set; }
	}

	public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, CreateGameResponse>
	{
		private readonly IApplicationDbContext _context;
		private readonly IGameCodeService _gameCodeService;

		public CreateGameCommandHandler(IApplicationDbContext context, IGameCodeService gameCodeService)
		{
			_context = context;
			_gameCodeService = gameCodeService;
		}

		public async Task<CreateGameResponse> Handle(CreateGameCommand request, CancellationToken cancellationToken)
		{
			var owner = new GamePlayer
			{
				Name = "Quiz Master",
				IsOwner = true
			};

			var joinCode = await _gameCodeService.CreateUniqueCodeAsync();

			var game = new Domain.Entities.Game
			{
				Name = request.Name ?? joinCode,
				JoinCode = joinCode,
				Status = GameStatus.Lobby,
				QuestionsPerRound = 20,
				NumberOfRounds = 5,
				QuestionTypes = QuestionType.All,
				Difficulty = Difficulty.Easy | Difficulty.Average | Difficulty.Hard,
				Categories = _context.Categories.Where(c=> c.IsDefault).ToList()
			};

			game.Players.Add(owner);
			
			_context.Games.Add(game);
			await _context.SaveChangesAsync(cancellationToken);
			
			return new CreateGameResponse
			{
				GameClientId = game.ClientId,
				PlayerClientId = owner.ClientId,
				PlayerId = owner.Id
			};
		}
	}
}
