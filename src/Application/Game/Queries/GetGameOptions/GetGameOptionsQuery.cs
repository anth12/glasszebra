using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GlassZebra.Application.Common.Interfaces;
using GlassZebra.Application.Game.Dtos;
using GlassZebra.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Game.Queries.GetGameOptions
{
	public class GetGameOptionsQuery : IRequest<GetGameOptionsResponse>
	{
	}

	public class GetGameOptionsQueryHandler : IRequestHandler<GetGameOptionsQuery, GetGameOptionsResponse>
	{
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public GetGameOptionsQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GetGameOptionsResponse> Handle(GetGameOptionsQuery request, CancellationToken cancellationToken)
		{
			var categories = await _context.Categories
				.ProjectTo<QuestionCategoryDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new GetGameOptionsResponse
			{
				Difficulty = Enum.GetValues(typeof(Difficulty)).Cast<Difficulty>().ToArray(),
				MaxNumberOfRounds = 100,
				MaxQuestionsPerRound = 100,
				Categories = categories
			};
		}
	}
}
