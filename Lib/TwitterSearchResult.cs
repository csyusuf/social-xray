using System.Collections.Generic;
using System.Data.Entity.Core;
using Newtonsoft.Json;

namespace SocialXray.Lib
{
    public class TwitterSearchResult

    {
        public List<TwitterStatus> Statuses { get; set; }
        [JsonProperty("search_metadata")]
        public TwitterMetadata SearchMetadata { get; set; }
    } 
}
