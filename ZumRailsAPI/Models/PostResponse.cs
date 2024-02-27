using Newtonsoft.Json;

namespace ZumRailsAPI.Models
{
    public class PostResponse
    {
        [JsonProperty("posts")]
        public IEnumerable<Post> Posts { get; set; }
    }
}