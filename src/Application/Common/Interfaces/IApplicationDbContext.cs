using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Game> Games { get; set; }
        DbSet<GameParticipant> Participants { get; set; }
        DbSet<GameRound> GameRounds { get; set; }

        DbSet<QuestionCategory> Categories { get; set; }
        DbSet<SeenQuestion> SeenQuestions { get; set; }

        DbSet<Question> Questions { get; set; }
        DbSet<Answer> Answers { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
