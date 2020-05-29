using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Exceptions;
using GlassZebra.Application.Common.Extensions;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Events;
using GlassZebra.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Game.Commands.Setup.UpdateGame
{
	public class UpdateGameCommand : PlayerGameCommand, IRequest
	{
		public string Name { get; set; }

		public int QuestionsPerRound { get; set; }
		public int NumberOfRounds { get; set; }
		public Difficulty[] Difficulty { get; set; }

		public IList<int> Categories { get; set; } = new List<int>();
	}

	public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMediator _mediator;

		public UpdateGameCommandHandler(IApplicationDbContext context, IMediator mediator)
		{
			_context = context;
			_mediator = mediator;
		}

		public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
		{
			var (game, _) = await _context.Games
				.Include(g=> g.Players)
				.Include(g=> g.Categories)
				.FindByClientIdAsync(request.GameClientId, request.PlayerClientId, mustBeOwner: true);
			
			game.Name = request.Name;
			game.QuestionsPerRound = request.QuestionsPerRound;
			game.NumberOfRounds = request.NumberOfRounds;
			game.QuestionsPerRound = request.QuestionsPerRound;
			game.Difficulty = request.Difficulty.Aggregate((c, d)=> c |= d);
			game.Categories = _context.Categories.Where(c=> request.Categories.Contains(c.Id)).ToList();
			
			await _context.SaveChangesAsync(cancellationToken);

			var @event = new GameUpdatedEvent(game.Id);
			await _mediator.Publish(@event, cancellationToken);

			return Unit.Value;
		}
	}
}
