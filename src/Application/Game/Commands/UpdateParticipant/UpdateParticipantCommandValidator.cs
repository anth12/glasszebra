using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Game.Commands.UpdateParticipant
{
	public class UpdateParticipantCommandValidator : AbstractValidator<UpdateParticipantCommand>
	{
		private readonly IApplicationDbContext _context;

		public UpdateParticipantCommandValidator(IApplicationDbContext context)
		{
			_context = context;

			RuleFor(v => v.Name)
				.NotEmpty().WithMessage("Name is missing")
				.MinimumLength(2).WithMessage("Name must be at least 2 characters.")
				.MaximumLength(20).WithMessage("Name must not exceed 20 characters.")
				.MustAsync(BeUniqueName).WithMessage("The specified Name already exists.");
		}

		public async Task<bool> BeUniqueName(UpdateParticipantCommand model, string name, CancellationToken cancellationToken)
		{
			return await _context.Participants
				.Where(p=> p.Game.ClientId == model.ClientId)
				.AllAsync(l => l.Name != name, cancellationToken);
		}
    }
}
