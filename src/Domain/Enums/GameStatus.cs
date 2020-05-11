namespace CleanArchitecture.Domain.Enums
{
	public enum GameStatus
	{
		/// <summary>
		/// Game has been created & is being setup
		/// </summary>
		//Setup,

		/// <summary>
		/// Game is setup & waiting for participants to join the lobby
		/// </summary>
		Lobby,

		/// <summary>
		/// Game has started
		/// </summary>
		InProgress,

		/// <summary>
		/// Game has finished
		/// </summary>
		Over
	}
}
