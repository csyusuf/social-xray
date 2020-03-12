using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SocialXray.Lib
{
    public class TwitterStatus
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

}

class TwitterDateTimeConverter : IsoDateTimeConverter
{
    public TwitterDateTimeConverter()
    {
        base.DateTimeFormat = "ddd MMM dd HH:mm:ss K yyyy";
    }
}