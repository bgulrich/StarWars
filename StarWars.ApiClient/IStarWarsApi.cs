using Refit;
using System;
using System.Threading.Tasks;
using StarWars.ApiClient.Models;

namespace StarWars.ApiClient
{
    public interface IStarWarsApi
    {
        [Get("/api/films/")]
        Task<PaginatedResults<Film>> GetFilmsAsync(QueryParameters query);

        [Get("/api/people/")]
        Task<PaginatedResults<Person>> GetPeopleAsync(QueryParameters query);

        [Get("/api/species/")]
        Task<PaginatedResults<Species>> GetSpeciesAsync(QueryParameters query);

        [Get("/api/planets/")]
        Task<PaginatedResults<Planet>> GetPlanetsAsync(QueryParameters query);

        [Get("/api/vehicles/")]
        Task<PaginatedResults<Vehicle>> GetVehiclesAsync(QueryParameters query);

        [Get("/api/starships/")]
        Task<PaginatedResults<Starship>> GetStarshipsAsync(QueryParameters query);
    }
}
