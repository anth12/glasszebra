using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Events.Public
{
	public interface IPublicEvent : INotification
	{
		public int GameId { get; }
	}

}
