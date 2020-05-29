namespace GlassZebra.Domain.Enums
{
	public enum QuestionType
	{
		All = SingleChoiceQuestion | MultipleChoiceQuestion | FreeTextQuestion | SingleChoiceBuzzInQuestion | FreeTextDoodle,
		
		/// <summary>
		/// Standard single correct answer, players answer independently
		/// </summary>
		SingleChoiceQuestion = 1,

		/// <summary>
		/// Standard multiple choice, players answer independently
		/// </summary>
		MultipleChoiceQuestion = 1<<1,

		/// <summary>
		/// Question with no options, players must type answer
		/// </summary>
		FreeTextQuestion = 1<<2,

		/// <summary>
		/// Single correct answer, First player to buzz answers
		/// </summary>
		SingleChoiceBuzzInQuestion = 1<<3,

		/// <summary>
		/// Doodle (drawing) with no options, players must type answer
		/// </summary>
		FreeTextDoodle = 1<<4 
	}
}
