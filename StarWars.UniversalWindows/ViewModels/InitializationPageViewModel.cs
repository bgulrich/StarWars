using AutoMapper;
using StarWars.ApiClient;
using StarWars.ApiClient.Models;
using StarWars.Data;
using StarWars.UniversalWindows.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.UniversalWindows.ViewModels
{
    public class InitializationPageViewModel : ViewModelBase
    {
        private string _message = "Welcome to the party.  Click below to initialize the database.";
        private PlaceholderType _icon;
        private readonly StarWarsDbContext _context;
        private readonly IStarWarsApi _starWarsApi;
        private readonly IMapper _mapper;

        public string Message
        {
            get => _message;
            private set => Set(ref _message, value, nameof(Message)); 
        }

        public PlaceholderType Icon
        {
            get => _icon;
            private set => Set(ref _icon, value);
        }

        public InitializationPageViewModel(StarWarsDbContext context, IStarWarsApi starWarsApi, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _starWarsApi = starWarsApi ?? throw new ArgumentNullException(nameof(starWarsApi));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task InitializeDatabaseAsync()
        {
            try
            {
                #region database

                Message = "Creating Database...";

                await _context.Database.EnsureCreatedAsync();

                #endregion

                #region films 

                Message = "Loading Films...";

                var films = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetFilmsAsync(new QueryParameters { page = page }));

                var filmEntities = films.Select(f => _mapper.Map<Data.Entities.Film>(f));

                _context.Films.AddRange(filmEntities);

                #endregion

                #region people

                Message = "Loading Characters...";

                var characters = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetPeopleAsync(new QueryParameters { page = page }));

                var characterEntities = characters.Select(c => _mapper.Map<Data.Entities.Character>(c));

                _context.Characters.AddRange(characterEntities);

                #endregion

                #region species

                Message = "Loading Species...";

                var species = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetSpeciesAsync(new QueryParameters { page = page }));

                var speciesEntities = species.Select(s => _mapper.Map<Data.Entities.Species>(s));

                _context.Species.AddRange(speciesEntities);

                #endregion

                #region planets

                Message = "Loading Planets...";

                var planets = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetPlanetsAsync(new QueryParameters { page = page }));

                var planetEntities = planets.Select(p => _mapper.Map<Data.Entities.Planet>(p));

                _context.Planets.AddRange(planetEntities);

                #endregion

                #region vehicles

                Message = "Loading Vehicles...";

                var vehicles = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetVehiclesAsync(new QueryParameters { page = page }));

                var vehicleEntities = vehicles.Select(v => _mapper.Map<Data.Entities.Vehicle>(v));

                _context.Vehicles.AddRange(vehicleEntities);

                #endregion

                #region vehicles

                Message = "Loading Starships...";

                var starships = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetStarshipsAsync(new QueryParameters { page = page }));

                var starshipEntities = starships.Select(s => _mapper.Map<Data.Entities.Starship>(s));

                _context.Starships.AddRange(starshipEntities);

                #endregion

                await _context.SaveChangesAsync();

            }
            // TODO
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex) { }
            catch { }        
        }

        private async Task<IEnumerable<TModel>> ProcessPaginatedModelAsync<TModel>(Func<int, Task<PaginatedResults<TModel>>> getter)
        {
            var page = 1;
            var paginatedResults = await getter(page);

            var results = new List<TModel>(paginatedResults.Count);
            results.AddRange(paginatedResults.Results);

            while (paginatedResults.Next != null)
            {
                paginatedResults = await getter(++page);
                results.AddRange(paginatedResults.Results);
            }

            return results;
        }
    }
}
