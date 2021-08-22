using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class Character : EntityBase
    {
        public string Name { get; set; } 
        public int Height { get; set; } 
        public int Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; } 
        public string BirthYear { get; set; } 
        public string Gender { get; set; }

        public int HomeWorldId { get; set; }

        public Planet HomeWorld { get; set; }

        public virtual ICollection<Film> Films { get; set; }

        public virtual ICollection<Species> Species { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }


        public virtual ICollection<Starship> Starships { get; set; }
    }
}
