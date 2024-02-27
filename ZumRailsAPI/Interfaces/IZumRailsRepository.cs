using ZumRailsAPI.Models;

namespace ZumRailsAPI.Interfaces
{
	public interface IZumRailsRepository
	{
        public Task<IEnumerable<Post>> GetPosts(string? tags, string? sortBy, string? direction);
    }
}