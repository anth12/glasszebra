using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Events.Public;
using GlassZebra.Application.Game.Dtos;
using MediatR;

namespace GlassZebra.Application.Events
{
	public class PlayerUpdatedEvent : INotification, IPublicEvent
	{
		public PlayerUpdatedEvent(bool newPlayer, int gameId, int playerId)
		{
			NewPlayer = newPlayer;
			GameId = gameId;
			PlayerId = playerId;
		}

		public bool NewPlayer { get; }
		public int GameId { get; }
		public int PlayerId { get; }

	}

	public class PlayerUpdatedEventHandler : INotificationHandler<PlayerUpdatedEvent>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public PlayerUpdatedEventHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
		{
			_context = context;
			_mapper = mapper;
			_mediator = mediator;
		}

		public Task Handle(PlayerUpdatedEvent notification, CancellationToken cancellationToken)
		{
			var player = _context.Players.Find(notification.PlayerId);
			var playerDto = player == null ? null : _mapper.Map<GamePlayerDto>(player);

			var @event = new PlayerUpdatedPublicEvent(notification.GameId, notification.PlayerId, playerDto);
			return _mediator.Publish(@event, cancellationToken);
		}
	}
}
