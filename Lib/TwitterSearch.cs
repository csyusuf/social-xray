using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Authenticators;

namespace SocialXray.Lib
{
    public static class TwitterSearch
    {
        private static string BASE_TWITTER_SEARCH_URL = "https://api.twitter.com/1.1/search/tweets.json";

        private static string BEARER_TOKEN =
            "AAAAAAAAAAAAAAAAAAAAAMYXDAEAAAAArYNTFqyAWfyq51c1yNzmd68clGw%3DVAWBxzXBRI5pd7R6ef45I5BYQF6q8tVgHeJyFgFTeqA4i3pTIZ";
        private static RestClient _twitterClient;
        public static Dictionary<DateTime, int> SearchByHashTag(string tag, int pages)
        {
            var query = $"?q=%23{tag}&count=100&lang=en";
            var results = new Dictionary<DateTime, int>();
            for (int i = 0; i < pages; i++)
            {
                var queryResult = GetResult(query);
                foreach (var status in queryResult.Statuses)
                {
                    var date = status.CreatedAt.Date;
                    if (!results.ContainsKey(date))
                    {
                        results[date] = 0;
                    }

                    results[date] = results[date] + 1;
                }

                if (!string.IsNullOrEmpty(queryResult.SearchMetadata.NextResults))
                {
                    query = queryResult.SearchMetadata.NextResults;
                }
                else
                {
                    break;
                }
            }

            return results;
        }

        private static TwitterSearchResult GetResult(string query)
        {
            var request = new RestRequest(query);
            var response = TwitterClient.Get(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error retrieving search results");
            }

            var serializeSettings = new JsonSerializerSettings();
            serializeSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "ddd MMM dd HH:mm:ss K yyyy" });
            var result = JsonConvert.DeserializeObject<TwitterSearchResult>(response.Content, serializeSettings);
            return result;
        }

        private static RestClient TwitterClient
        {
            get
            {
                if (_twitterClient == null)
                {
                    _twitterClient = new RestClient(BASE_TWITTER_SEARCH_URL);
                    _twitterClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", BEARER_TOKEN));

                }

                return _twitterClient;
            }
        }

    }
}