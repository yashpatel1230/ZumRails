using System;
using ZumRailsAPI.Interfaces;
using ZumRailsAPI.Models;

namespace ZumRailsAPI.Services
{
    public class ZumRailsService : IZumRailsService
    {
        public readonly IZumRailsRepository repository;

        public ZumRailsService(IZumRailsRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<Post>> GetPosts(string? tags, string? sortBy, string? direction)
        {
            var result = await repository.GetPosts(tags, sortBy, direction);
            return result;
        }
    }
}