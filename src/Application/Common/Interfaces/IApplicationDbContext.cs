using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Domain.Entities.Game> Games { get; set; }
        DbSet<Domain.Entities.GameParticipant> Participants { get; set; }
        DbSet<Domain.Entities.GameRound> GameRounds { get; set; }

        DbSet<QuestionCategory> Categories { get; set; }
        DbSet<SeenQuestion> SeenQuestions { get; set; }

        DbSet<Domain.Entities.Question> Questions { get; set; }
        DbSet<Domain.Entities.Answer> Answers { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
