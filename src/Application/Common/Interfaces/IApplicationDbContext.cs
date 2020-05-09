using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Quiz;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Domain.Entities.Game> Games { get; set; }
        DbSet<Domain.Entities.GameParticipant> Participants { get; set; }
        DbSet<Domain.Entities.GameRound> GameRounds { get; set; }

        DbSet<Domain.Entities.Quiz.QuizRound> QuizRounds { get; set; }
        DbSet<Domain.Entities.Quiz.QuizQuestion> QuizQuestions { get; set; }
        DbSet<Domain.Entities.Quiz.QuizAnswer> QuizAnswers { get; set; }

        DbSet<Domain.Entities.Doodle.DoodleRound> DoodleRounds { get; set; }
        DbSet<Domain.Entities.Doodle.DoodleQuestion> DoodleQuestions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
