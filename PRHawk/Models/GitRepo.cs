namespace PRHawk.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Git Repo Model
    /// </summary>
    public class GitRepo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public string CreatedDate { get; set; }

        [JsonProperty("html_url")]
        public string Url { get; set; }

        public int PRCount { get; set; }
    }
}