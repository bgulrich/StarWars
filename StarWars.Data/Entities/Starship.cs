using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class Starship : EntityBase
    {
        public string Name { get; set; }

        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CostInCredits { get; set; }
        public string Length { get; set; }
        public string MaximumAtmosphericSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string StarshipClass { get; set; }
        public string HyperdriveRating { get; set; }
        public string Mglt { get; set; }

        public virtual ICollection<FilmStarship> FilmStarships { get; set; }

        public virtual ICollection<CharacterStarship> CharacterStarships { get; set; }
    }
}
