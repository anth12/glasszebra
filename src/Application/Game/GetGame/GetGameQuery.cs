using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Extensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Game.GetGame
{
	public class GetGameQuery : IRequest<GetGameResponse>
	{
		public Guid ClientId { get; set; }
	}

	public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GetGameResponse>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetGameQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GetGameResponse> Handle(GetGameQuery request, CancellationToken cancellationToken)
		{
			var game = await _context.Games.FindByClientIdAsync(request.ClientId);

			var gameDto = _mapper.Map<GameDto>(game);

			return new GetGameResponse
			{
				Game = gameDto
			};
		}
	}
}
