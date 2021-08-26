using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class Character : EntityBase
    {
        public string Name { get; set; } 
        public string Height { get; set; } 
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; } 
        public string BirthYear { get; set; } 
        public string Gender { get; set; }

        public int? HomeWorldId { get; set; }

        public Planet HomeWorld { get; set; }

        public virtual ICollection<FilmCharacter> FilmCharacters { get; set; }

        public virtual ICollection<CharacterSpecies> CharacterSpecies { get; set; }

        public virtual ICollection<CharacterVehicle> CharacterVehicles { get; set; }

        public virtual ICollection<CharacterStarship> CharacterStarships { get; set; }
    }
}
