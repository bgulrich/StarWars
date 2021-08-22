using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StarWars.ApiClient.Models
{
    public class Film
    {
        [JsonProperty("episode_id")]
        public int EpisodeId { get; set; }
        public string Title { get; set; }

        [JsonProperty("opening_crawl")]
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty("characters")]
        public IEnumerable<string> CharacterUris { get; set; }
    }
}
