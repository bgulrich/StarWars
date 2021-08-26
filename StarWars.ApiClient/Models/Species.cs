using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.ApiClient.Models
{
    public class Species : ModelBase
    {
        public string Name { get; set; }

        public string Classification { get; set; }
        public string Designation { get; set; }

        [JsonProperty("average_height")]
        public string AverageHeight { get; set; }

        [JsonProperty("skin_colors")]
        public string SkinColors { get; set; }

        [JsonProperty("hair_colors")]
        public string HairColors { get; set; }

        [JsonProperty("eye_colors")]
        public string EyeColors { get; set; }

        [JsonProperty("average_lifespan")]
        public string AverageLifespan { get; set; }

        public string Language { get; set; }

        [JsonProperty("homeworld")]
        public Uri HomeWorldUri { get; set; }

        [JsonProperty("films")]
        public IEnumerable<Uri> FilmUris { get; set; }

        [JsonProperty("people")]
        public IEnumerable<Uri> PersonUris { get; set; }
    }
}
