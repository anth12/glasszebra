
namespace GlassZebra.Domain.Entities
{
	public class SeenQuestion
	{
		public int Id { get; set; }

		public Game Game { get; set; }
		public int GameId { get; set; }

		public int QuestionId { get; set; }
		public Question Question { get; set; }
	}
}
