using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Events.Public;
using GlassZebra.Application.Game.Dtos;
using MediatR;

namespace GlassZebra.Application.Events
{
	public class GameUpdatedEvent : INotification
	{
		public GameUpdatedEvent(int gameId)
		{
			GameId = gameId;
		}

		public int GameId { get; }
	}

	public class GameUpdatedEventHandler : INotificationHandler<GameUpdatedEvent>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public GameUpdatedEventHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
		{
			_context = context;
			_mapper = mapper;
			_mediator = mediator;
		}

		public Task Handle(GameUpdatedEvent notification, CancellationToken cancellationToken)
		{
			var game = _context.Games.Find(notification.GameId);
			var gameDto = _mapper.Map<GameDto>(game);

			var @event = new GameUpdatedPublicEvent(game.Id, gameDto);
			return _mediator.Publish(@event, cancellationToken);
		}
	}
}
