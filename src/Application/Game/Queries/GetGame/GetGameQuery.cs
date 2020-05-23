using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GlassZebra.Application.Common.Extensions;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Game.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Game.Queries.GetGame
{
	public class GetGameQuery : IRequest<GameDto>
	{
		public Guid ClientId { get; set; }
	}

	public class GetGameQueryHandler : IRequestHandler<GetGameQuery, GameDto>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetGameQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GameDto> Handle(GetGameQuery request, CancellationToken cancellationToken)
		{
			var game = await _context.Games
				.Include(g=> g.Players)
				.Include(g=> g.Categories)
				.Include(g=> g.CurrentRound)
				.Include(g=> g.CurrentRound.CurrentQuestion)
				.Include(g=> g.CurrentRound.CurrentQuestion.Answers)
				.FindByClientIdAsync(request.ClientId);

			var gameDto = _mapper.Map<GameDto>(game);

			return gameDto;
		}
	}
}
