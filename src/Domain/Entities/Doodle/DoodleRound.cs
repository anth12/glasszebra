using System.Collections.Generic;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Doodle
{
	public class DoodleRound
	{
		public DoodleRound()
		{
			Questions = new List<DoodleQuestion>();
		}

		public int Id { get; set; }

		public string Name { get; set; }

		public Difficulty Difficulty { get; set; }

		public IList<DoodleQuestion> Questions { get; set; }
	}
}
