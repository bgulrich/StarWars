using Microsoft.EntityFrameworkCore;
using StarWars.Data.Entities;
using System;

namespace StarWars.Data
{
    public class StarWarsDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Starship> Starships { get; set; }
        public DbSet<Planet> Planets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Constants.DatbasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            {
                var e = modelBuilder.Entity<Film>();
            }

            {
                var e = modelBuilder.Entity<Species>();
            }

            {
                var e = modelBuilder.Entity<Vehicle>();
            }

            {
                var e = modelBuilder.Entity<Starship>();
            }

            {
                var e = modelBuilder.Entity<FilmCharacter>();

                e.HasKey(x => new { x.FilmId, x.CharacterId });

                e.HasOne(x => x.Film)
                 .WithMany(x => x.FilmCharacters)
                 .HasForeignKey(x => x.FilmId);

                e.HasOne(x => x.Character)
                 .WithMany(x => x.FilmCharacters)
                 .HasForeignKey(x => x.CharacterId);
            }

            {
                var e = modelBuilder.Entity<FilmSpecies>();

                e.HasKey(x => new { x.FilmId, x.SpeciesId });

                e.HasOne(x => x.Film)
                 .WithMany(x => x.FilmSpecies)
                 .HasForeignKey(x => x.FilmId);

                e.HasOne(x => x.Species)
                 .WithMany(x => x.FilmSpecies)
                 .HasForeignKey(x => x.SpeciesId);
            }

            {
                var e = modelBuilder.Entity<FilmPlanet>();

                e.HasKey(x => new { x.FilmId, x.PlanetId });

                e.HasOne(x => x.Film)
                 .WithMany(x => x.FilmPlanets)
                 .HasForeignKey(x => x.FilmId);

                e.HasOne(x => x.Planet)
                 .WithMany(x => x.FilmPlanets)
                 .HasForeignKey(x => x.PlanetId);
            }

            {
                var e = modelBuilder.Entity<FilmVehicle>();

                e.HasKey(x => new { x.FilmId, x.VehicleId });

                e.HasOne(x => x.Film)
                 .WithMany(x => x.FilmVehicles)
                 .HasForeignKey(x => x.FilmId);

                e.HasOne(x => x.Vehicle)
                 .WithMany(x => x.FilmVehicles)
                 .HasForeignKey(x => x.VehicleId);
            }

            {
                var e = modelBuilder.Entity<FilmStarship>();

                e.HasKey(x => new { x.FilmId, x.StarshipId });

                e.HasOne(x => x.Film)
                 .WithMany(x => x.FilmStarships)
                 .HasForeignKey(x => x.FilmId);

                e.HasOne(x => x.Starship)
                 .WithMany(x => x.FilmStarships)
                 .HasForeignKey(x => x.StarshipId);
            }

            {
                var e = modelBuilder.Entity<CharacterSpecies>();

                e.HasKey(x => new { x.CharacterId, x.SpeciesId });

                e.HasOne(x => x.Character)
                 .WithMany(x => x.CharacterSpecies)
                 .HasForeignKey(x => x.CharacterId);

                e.HasOne(x => x.Species)
                 .WithMany(x => x.CharacterSpecies)
                 .HasForeignKey(x => x.SpeciesId);
            }

            {
                var e = modelBuilder.Entity<CharacterVehicle>();

                e.HasKey(x => new { x.CharacterId, x.VehicleId });

                e.HasOne(x => x.Character)
                 .WithMany(x => x.CharacterVehicles)
                 .HasForeignKey(x => x.CharacterId);

                e.HasOne(x => x.Vehicle)
                 .WithMany(x => x.CharacterVehicles)
                 .HasForeignKey(x => x.VehicleId);
            }

            {
                var e = modelBuilder.Entity<CharacterStarship>();

                e.HasKey(x => new { x.CharacterId, x.StarshipId });

                e.HasOne(x => x.Character)
                 .WithMany(x => x.CharacterStarships)
                 .HasForeignKey(x => x.CharacterId);

                e.HasOne(x => x.Starship)
                 .WithMany(x => x.CharacterStarships)
                 .HasForeignKey(x => x.StarshipId);
            }

            {
                var e = modelBuilder.Entity<CharacterPlanet>();

                e.HasKey(x => new { x.CharacterId, x.PlanetId });

                //e.HasOne(x => x.Character)
                // .WithMany(x => x.CharacterPlanets)
                // .HasForeignKey(x => x.CharacterId);

                e.HasOne(x => x.Planet)
                 .WithMany(x => x.CharacterPlanets)
                 .HasForeignKey(x => x.PlanetId);
            }
        }

    }
}
