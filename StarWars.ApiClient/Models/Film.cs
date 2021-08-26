using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace StarWars.ApiClient.Models
{
    public class Film : ModelBase
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
        public IEnumerable<Uri> CharacterUris { get; set; }

        [JsonProperty("planets")]
        public IEnumerable<Uri> PlanetUris { get; set; }

        [JsonProperty("species")]
        public IEnumerable<Uri> SpeciesUris { get; set; }

        [JsonProperty("vehicles")]
        public IEnumerable<Uri> VehicleUris { get; set; }

        [JsonProperty("starships")]
        public IEnumerable<Uri> StarshipUris { get; set; }
    }
}
