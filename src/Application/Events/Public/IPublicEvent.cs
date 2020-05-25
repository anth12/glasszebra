using MediatR;

namespace GlassZebra.Application.Events.Public
{
	public interface IPublicEvent : INotification
	{
		public int GameId { get; }
	}

}
