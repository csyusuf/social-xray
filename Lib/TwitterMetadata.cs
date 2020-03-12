using Newtonsoft.Json;

namespace SocialXray.Lib
{
    public class TwitterMetadata
    {
        [JsonProperty("next_results")]
        public string NextResults { get; set; }
    }
}