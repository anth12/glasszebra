using System;

namespace GlassZebra.Domain.Common
{
	public interface IHaveClientId
	{
		Guid ClientId { get; }
	}
}
