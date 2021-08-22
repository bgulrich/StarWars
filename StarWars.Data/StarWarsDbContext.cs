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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            {
                var e = modelBuilder.Entity<Film>();

                e.HasMany(x => x.Characters)
                 .WithMany(x => x.Films);

                e.HasMany(x => x.Species)
                 .WithMany(x => x.Films);

                e.HasMany(x => x.Planets)
                 .WithMany(x => x.Films);

                e.HasMany(x => x.Vehicles)
                 .WithMany(x => x.Films);

                e.HasMany(x => x.Starships)
                 .WithMany(x => x.Films);
            }

            {
                var e = modelBuilder.Entity<Character>();

                e.HasMany(x => x.Species)
                 .WithMany(x => x.Characters);

                e.HasMany(x => x.Vehicles)
                 .WithMany(x => x.Pilots);

                e.HasMany(x => x.Starships)
                 .WithMany(x => x.Pilots);
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
        }

    }
}
