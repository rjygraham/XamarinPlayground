using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinPlayground.Models;

namespace XamarinPlayground.Services
{
	public interface IUnsplashService
	{
		Task<IEnumerable<Photo>> GetRandomPhotosAsync(int count);
	}
}
