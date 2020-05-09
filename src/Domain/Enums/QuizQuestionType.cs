namespace CleanArchitecture.Domain.Enums
{
	public enum QuizQuestionType
	{
		/// <summary>
		/// Standard single correct answer, participants answer independently
		/// </summary>
		SingleChoice = 1,

		/// <summary>
		/// Standard multiple choice, participants answer independently
		/// </summary>
		MultipleChoice = 1<<1,

		/// <summary>
		/// 
		/// </summary>
		FreeText = 1<<2,

		/// <summary>
		/// Single correct answer, First player to buzz answers
		/// </summary>
		SingleChoiceBuzzIn = 1<<3 | SingleChoice
	}
}
