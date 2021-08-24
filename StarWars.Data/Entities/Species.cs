using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class Species : EntityBase
    {
        public string Name { get; set; }

        public string Classification { get; set; }
        public string Designation { get; set; }
        public string AverageHeight { get; set; }
        public string SkinColors { get; set; }
        public string HairColors { get; set; }
        public string EyeColors { get; set; }
        public string AverageLifespan { get; set; }
        public string Language { get; set; }

        public int HomeWorldId { get; set; }        

        public virtual ICollection<FilmSpecies> FilmSpecies { get; set; }

        public virtual ICollection<CharacterSpecies> CharacterSpecies { get; set; }
    }
}
