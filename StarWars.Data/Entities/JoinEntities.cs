using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class FilmCharacter
    {
        public int FilmId { get; set; }

        public int CharacterId { get; set; }

        public Film Film { get; set; }
        public Character Character { get; set; }
    }

    public class FilmSpecies
    {
        public int FilmId { get; set; }

        public int SpeciesId { get; set; }

        public Film Film { get; set; }
        public Species Species { get; set; }
    }

    public class FilmPlanet
    {
        public int FilmId { get; set; }

        public int PlanetId { get; set; }

        public Film Film { get; set; }
        public Planet Planet { get; set; }
    }

    public class FilmVehicle
    {
        public int FilmId { get; set; }

        public int VehicleId { get; set; }

        public Film Film { get; set; }
        public Vehicle Vehicle { get; set; }
    }

    public class FilmStarship
    {
        public int FilmId { get; set; }

        public int StarshipId { get; set; }

        public Film Film { get; set; }
        public Starship Starship { get; set; }
    }

    public class CharacterSpecies
    {
        public int CharacterId { get; set; }

        public int SpeciesId { get; set; }

        public Character Character { get; set; }
        public Species Species { get; set; }
    }

    public class CharacterVehicle
    {
        public int CharacterId { get; set; }

        public int VehicleId { get; set; }

        public Character Character { get; set; }
        public Vehicle Vehicle { get; set; }
    }

    public class CharacterStarship
    {
        public int CharacterId { get; set; }

        public int StarshipId { get; set; }

        public Character Character { get; set; }
        public Starship Starship { get; set; }
    }

    public class CharacterPlanet
    {
        public int CharacterId { get; set; }

        public int PlanetId { get; set; }

        public Character Character { get; set; }
        public Planet Planet { get; set; }
    }
}
