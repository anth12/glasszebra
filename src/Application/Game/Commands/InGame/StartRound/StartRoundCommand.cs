using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Exceptions;
using GlassZebra.Application.Common.Extensions;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Events;
using GlassZebra.Application.Services.Game;
using GlassZebra.Domain.Entities;
using GlassZebra.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Game.Commands.InGame.StartRound
{
	public class StartRoundCommand : PlayerGameCommand, IRequest
	{

	}

	public class StartRoundCommandHandler : IRequestHandler<StartRoundCommand>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMediator _mediator;
		private readonly IQuestionService _questionService;

		public StartRoundCommandHandler(IApplicationDbContext context, IMediator mediator, IQuestionService questionService)
		{
			_context = context;
			_mediator = mediator;
			_questionService = questionService;
		}

		public async Task<Unit> Handle(StartRoundCommand request, CancellationToken cancellationToken)
		{
			var (game, _) = await _context.Games
				.Include(g => g.Players)
				.Include(g => g.Categories)
				.FindByClientIdAsync(request.GameClientId, request.PlayerClientId, mustBeOwner: true);

			if (game.Status == GameStatus.Lobby)
			{
				// First round
				game.Status = GameStatus.InProgress;

				game.CurrentRound = new GameRound
				{
					CurrentRoundIndex = 0
				};
			}
			else
			{
				// Clean previous round (for in-mem it doesn't matter)
				game.CurrentRound.PlayerAnswers.Clear();

				game.CurrentRound.CurrentRoundIndex += 1;
			}

			if(game.CurrentRound.CurrentRoundIndex >= game.NumberOfRounds)
				throw new Exception("Number of rounds reached");

			game.CurrentRound.CurrentRoundStartTimeUtc = DateTime.UtcNow.AddSeconds(5);

			game.CurrentRound.CurrentQuestion = await _questionService.GetQuestionAsync(game); // TODO handle no question found
			game.CurrentRound.CurrentQuestionStartTimeUtc = DateTime.UtcNow.AddSeconds(5);
			game.CurrentRound.CurrentQuestionStartTimeUtc = DateTime.UtcNow.AddSeconds(35); // TODO

			await _context.SaveChangesAsync(cancellationToken);

			var @event = new RoundUpdatedEvent(true, game.Id);
			await _mediator.Publish(@event, cancellationToken);
			
			return Unit.Value;
		}
	}
}
