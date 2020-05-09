using System;

namespace CleanArchitecture.Domain.Common
{
	public interface IHaveClientId
	{
		Guid ClientId { get; }
	}
}
