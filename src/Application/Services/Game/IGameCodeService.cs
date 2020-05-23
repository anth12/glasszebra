using System.Threading.Tasks;

namespace GlassZebra.Application.Services.Game
{
	public interface IGameCodeService
	{
		Task<string> CreateUniqueCodeAsync();
		string CreateCode(int length);
	}
}
