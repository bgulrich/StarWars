using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class Vehicle : EntityBase
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
        public string VehicleClass { get; set; }

        public virtual ICollection<Film> Films { get; set; }

        public virtual ICollection<Character> Pilots { get; set; }
    }
}
