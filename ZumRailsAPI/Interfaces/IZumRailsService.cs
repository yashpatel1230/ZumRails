using ZumRailsAPI.Models;

namespace ZumRailsAPI.Interfaces
{
	public interface IZumRailsService
	{
        public Task<IEnumerable<Post>> GetPosts(string? tags, string? sortBy, string? direction);
    }
}