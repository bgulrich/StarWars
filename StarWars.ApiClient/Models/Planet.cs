using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.ApiClient.Models
{
    public class Planet : ModelBase
    {
        public string Name { get; set; }

        [JsonProperty("rotation_period")]
        public string RotationPeriod { get; set; }

        [JsonProperty("orbital_period")]
        public string OribitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }

        [JsonProperty("surface_water")]
        public string SurfaceWater { get; set; }
        public string Population { get; set; }

        [JsonProperty("residents")]
        public IEnumerable<Uri> PersonUris { get; set; }

        [JsonProperty("films")]
        public IEnumerable<Uri> FilmUris { get; set; }
    }
}
