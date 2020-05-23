using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Interfaces;
using MediatR;

namespace GlassZebra.Application.Events.Public
{
	public interface IPublicEvent : INotification
	{
		public int GameId { get; }
	}

}
