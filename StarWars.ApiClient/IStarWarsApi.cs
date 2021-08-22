using Refit;
using System;
using System.Threading.Tasks;
using StarWars.ApiClient.Models;

namespace StarWars.ApiClient
{
    public interface IStarWarsApi
    {
        [Get("/api/films/")]

        Task<PaginatedResults<Film>> GetFilmsAsync();
    }
}
