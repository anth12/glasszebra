﻿//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using GlassZebra.Application.Common.Interfaces;
//using GlassZebra.Application.Events.Public;
//using GlassZebra.Application.Game.Dtos;
//using GlassZebra.Domain.Enums;
//using MediatR;

//namespace GlassZebra.Application.Events
//{
//	public class PlayerStatusUpdatedEvent : INotification, IPublicEvent
//	{
//		public PlayerStatusUpdatedEvent(PlayerStatus newStatus, int gameId, int playerId)
//		{
//			NewStatus = newStatus;
//			GameId = gameId;
//			PlayerId = playerId;
//		}

//		public PlayerStatus NewStatus { get; }
//		public int GameId { get; }
//		public int PlayerId { get; }
//	}

//	public class PlayerStatusUpdatedEventHandler : INotificationHandler<PlayerStatusUpdatedEvent>
//	{
//		private readonly IApplicationDbContext _context;
//		private readonly IMapper _mapper;
//		private readonly IMediator _mediator;

//		public PlayerStatusUpdatedEventHandler(IApplicationDbContext context, IMapper mapper, IMediator mediator)
//		{
//			_context = context;
//			_mapper = mapper;
//			_mediator = mediator;
//		}

//		public Task Handle(PlayerStatusUpdatedEvent notification, CancellationToken cancellationToken)
//		{
//			var game = _context.Players.Find(notification.PlayerId);
//			var gameDto = _mapper.Map<GameDto>(game);

//			var @event = new PlayerStatusUpdatedPublicEvent(game.Id, gameDto);
//			return _mediator.Publish(@event, cancellationToken);
//		}
//	}
//}
