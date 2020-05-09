using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Services.Game;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Enums;
using MediatR;

namespace CleanArchitecture.Application.Game.CreateGame
{
	public class GetGameCommand : IRequest<GetGameResponse>
	{
		public string Name { get; set; }
	}

	public class CreateGameCommandHandler : IRequestHandler<GetGameCommand, GetGameResponse>
	{
		private readonly IApplicationDbContext _context;
		private readonly IGameCodeService _gameCodeService;

		public CreateGameCommandHandler(IApplicationDbContext context, IGameCodeService gameCodeService)
		{
			_context = context;
			_gameCodeService = gameCodeService;
		}

		public async Task<GetGameResponse> Handle(GetGameCommand request, CancellationToken cancellationToken)
		{
			var participant = new GameParticipant();

			var joinCode = await _gameCodeService.CreateUniqueCodeAsync();

			var game = new Domain.Entities.Game
			{
				Name = request.Name ?? joinCode,
				Owner = participant,
				JoinCode = joinCode,
				Status = GameStatus.Setup
			};

			game.Participants.Add(participant);
			
			_context.Games.Add(game);
			await _context.SaveChangesAsync(cancellationToken);

			return new GetGameResponse
			{
				GameClientId = game.ClientId,
				ParticipantClientId = participant.ClientId,
				JoinCode = game.JoinCode
			};
		}
	}
}
