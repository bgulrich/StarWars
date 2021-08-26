using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.ApiClient.Models
{
    public class Person : ModelBase
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }
        public string Gender { get; set; }

        [JsonProperty("homeworld")]
        public Uri HomeWorldUri { get; set; }

        [JsonProperty("films")]
        public IEnumerable<Uri> FilmUris { get; set; }

        [JsonProperty("species")]
        public IEnumerable<Uri> SpeciesUris { get; set; }

        [JsonProperty("vehicles")]
        public IEnumerable<Uri> VehicleUris { get; set; }

        [JsonProperty("starships")]
        public IEnumerable<Uri> StarshipUris { get; set; }
    }
}
