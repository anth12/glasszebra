using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GlassZebra.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace GlassZebra.Application.Game.Commands.Setup.UpdatePlayer
{
	public class UpdatePlayerCommandValidator : AbstractValidator<UpdatePlayerCommand>
	{
		private readonly IApplicationDbContext _context;

		public UpdatePlayerCommandValidator(IApplicationDbContext context)
		{
			_context = context;

			RuleFor(v => v.Name)
				.NotEmpty().WithMessage("Name is missing")
				.MinimumLength(2).WithMessage("Name must be at least 2 characters.")
				.MaximumLength(20).WithMessage("Name must not exceed 20 characters.")
				.MustAsync(BeUniqueName).WithMessage("The specified Name already exists.");
		}

		public async Task<bool> BeUniqueName(UpdatePlayerCommand model, string name, CancellationToken cancellationToken)
		{
			return await _context.Players
				.Where(p=> p.Game.ClientId == model.ClientId)
				.AllAsync(l => l.Name != name, cancellationToken);
		}
    }
}
