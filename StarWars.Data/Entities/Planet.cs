﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class Planet : EntityBase
    {
        public string Name { get; set; }

        public string RotationPeriod { get; set; }
        public string OribitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public string Population { get; set; }

        public virtual ICollection<FilmPlanet> FilmPlanets { get; set; }

        public virtual ICollection<CharacterPlanet> CharacterPlanets { get; set; }
    }
}
