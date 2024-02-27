using Newtonsoft.Json;

namespace ZumRailsAPI.Models
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("authorId")]
        public int AuthorId { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("reads")]
        public int Reads { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}