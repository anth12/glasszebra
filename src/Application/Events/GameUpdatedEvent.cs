using MediatR;

namespace CleanArchitecture.Application.Events
{
	public class GameUpdatedEvent : INotification
	{
		public int GameId { get; set; }
	}
}
