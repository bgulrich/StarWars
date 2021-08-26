using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.ApiClient.Models
{
    public class Starship : ModelBase
    {

        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }

        [JsonProperty("cost_in_credits")]
        public string CostInCredits { get; set; }
        public string Length { get; set; }

        [JsonProperty("max_atmosphering_speed")]
        public string MaximumAtmosphericSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }

        [JsonProperty("cargo_capacity")]
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }

        [JsonProperty("starship_class")]
        public string StarshipClass { get; set; }

        [JsonProperty("hyperdrive_rating")]
        public string HyperdriveRating { get; set; }

        [JsonProperty("MGLT")]
        public string Mglt { get; set; }

        [JsonProperty("pilots")]
        public IEnumerable<Uri> PersonUris { get; set; }

        [JsonProperty("films")]
        public IEnumerable<Uri> FilmUris { get; set; }
    }
}
