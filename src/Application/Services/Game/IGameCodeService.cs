using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.Game
{
	public interface IGameCodeService
	{
		Task<string> CreateUniqueCodeAsync();
		string CreateCode(int length);
	}
}
