using Newtonsoft.Json;
using ZumRailsAPI.Interfaces;
using ZumRailsAPI.Models;
using ZumRailsAPI.Validators;

namespace ZumRailsAPI.Repositories
{
    public class ZumRailsRepository : IZumRailsRepository
    {
        public HttpClient client;
        public string API = "https://api.hatchways.io/assessment/blog/posts";

        public ZumRailsRepository()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<Post>> GetPosts(string? tags, string? sortBy, string? direction)
        {
            if (string.IsNullOrEmpty(tags))
            {
                throw new ArgumentException("Tags parameter is required");
            }
            else
            {
                API += "?tag=" + tags;
            }

            if (!string.IsNullOrEmpty(sortBy) && !ZumRailsValidator.IsSortByValid(sortBy))
            {
                throw new ArgumentException("sortBy parameter is invalid”");
            }
            else
            {
                API += "&sortBy=id";
            }

            if (!string.IsNullOrEmpty(direction) && !ZumRailsValidator.IsDirectionValid(direction))
            {
                throw new ArgumentException("direction parameter is invalid”");
            }
            else
            {
                API += "&direction=asc";
            }

            var request = await client.GetAsync(API);
            var response = await request.Content.ReadAsStringAsync();

            var resultList = new List<Post>();
            var postResponse = JsonConvert.DeserializeObject<PostResponse>(response);
            if (postResponse != null)
            {
                foreach (var post in postResponse.Posts)
                {
                    if (!resultList.Any(x => x.Id == post.Id))
                    {
                        resultList.Add(post);
                    }

                }
            }
            return resultList;
        }
    }
}