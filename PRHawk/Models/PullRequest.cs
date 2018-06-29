namespace PRHawk.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Pull Request Model
    /// </summary>
    public class PullRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}