using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class Film : EntityBase
    {
        public string Title { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<FilmCharacter> FilmCharacters { get; set; }

        public virtual ICollection<FilmSpecies> FilmSpecies { get; set; }

        public virtual ICollection<FilmPlanet> FilmPlanets { get; set; }
        public virtual ICollection<FilmVehicle> FilmVehicles { get; set; }
        public virtual ICollection<FilmStarship> FilmStarships { get; set; }
    }
}
