using System;

namespace GlassZebra.Domain.Enums
{
	[Flags]
	public enum Difficulty
	{
		Easy = 1,
		Average = 1<<1,
		Hard = 1<<2,
		VeryHard = 1<<3
	}
}
