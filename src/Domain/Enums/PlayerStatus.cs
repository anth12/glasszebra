
namespace GlassZebra.Domain.Enums
{
	public enum PlayerStatus
	{
		Connected = 1,
		
		Disconnected = 1<<1,

		Left = 1<<2
	}
}
