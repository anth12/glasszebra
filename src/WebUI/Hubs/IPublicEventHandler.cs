using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Events.Public;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace GlassZebra.WebUI.Hubs
{
	public class IPublicEventHandler : INotificationHandler<IPublicEvent>, 
		INotificationHandler<GameUpdatedPublicEvent>,
		INotificationHandler<PlayerUpdatedPublicEvent>
	{
		private readonly IHubContext<GameHub> _gameHubState;

		public IPublicEventHandler(IHubContext<GameHub> gameHubState)
		{
			_gameHubState = gameHubState;
		}

		public Task Handle(GameUpdatedPublicEvent notification, CancellationToken cancellationToken)
			=> Handle((IPublicEvent) notification, cancellationToken);

		public Task Handle(PlayerUpdatedPublicEvent notification, CancellationToken cancellationToken)
			=> Handle((IPublicEvent) notification, cancellationToken);

		public Task Handle(IPublicEvent notification, CancellationToken cancellationToken)
		{
			var notificationName = notification.GetType().Name;

			return _gameHubState.Clients.Group(notification.GameId.ToString())
				.SendCoreAsync(notificationName, new[]
				{
					notification
				}, cancellationToken);
		}
	}
}
