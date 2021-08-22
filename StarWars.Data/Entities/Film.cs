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

        public virtual ICollection<Character> Characters { get; set; }

        public virtual ICollection<Species> Species { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Starship> Starships { get; set; }
    }
}
