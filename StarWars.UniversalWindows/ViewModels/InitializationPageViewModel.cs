using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
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
        private float _progress;
        private string _message = "Welcome to the party.  Click below to initialize the database.";
        private PlaceholderType _icon;
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

        public float Progress
        {
            get => _progress;
            private set => Set(ref _progress, value);
        }


        public InitializationPageViewModel(IStarWarsApi starWarsApi, IMapper mapper)
        {
            _starWarsApi = starWarsApi ?? throw new ArgumentNullException(nameof(starWarsApi));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task<bool> InitializeDatabaseAsync()
        {
            try
            {
                using (var context = App.Current.Services.GetRequiredService<StarWarsDbContext>())
                {

                    #region database

                    Progress = 0f;

                    Message = "Creating Database...";

                    await context.Database.EnsureCreatedAsync();

                    Progress = 10f;

                    #endregion

                    #region films 

                    Message = "Loading Films...";

                    Icon = PlaceholderType.Film;

                    var films = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetFilmsAsync(new QueryParameters { page = page }));

                    var filmEntities = films.Select(f => _mapper.Map<Data.Entities.Film>(f));

                    context.Films.AddRange(filmEntities);

                    Progress = 20f;

                    #endregion

                    #region people

                    Message = "Loading Characters...";

                    Icon = PlaceholderType.Person;

                    var characters = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetPeopleAsync(new QueryParameters { page = page }));

                    var characterEntities = characters.Select(c => _mapper.Map<Data.Entities.Character>(c));

                    context.Characters.AddRange(characterEntities);

                    Progress = 40f;

                    #endregion

                    #region species

                    Message = "Loading Species...";
                    Icon = PlaceholderType.Species;

                    var species = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetSpeciesAsync(new QueryParameters { page = page }));

                    var speciesEntities = species.Select(s => _mapper.Map<Data.Entities.Species>(s));

                    context.Species.AddRange(speciesEntities);

                    Progress = 50f;

                    #endregion

                    #region planets

                    Message = "Loading Planets...";
                    Icon = PlaceholderType.Planet;

                    var planets = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetPlanetsAsync(new QueryParameters { page = page }));

                    var planetEntities = planets.Select(p => _mapper.Map<Data.Entities.Planet>(p));

                    context.Planets.AddRange(planetEntities);

                    Progress = 60f;

                    #endregion

                    #region vehicles

                    Message = "Loading Vehicles...";

                    Icon = PlaceholderType.Vehicle;

                    var vehicles = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetVehiclesAsync(new QueryParameters { page = page }));

                    var vehicleEntities = vehicles.Select(v => _mapper.Map<Data.Entities.Vehicle>(v));

                    context.Vehicles.AddRange(vehicleEntities);

                    Progress = 70f;

                    #endregion

                    #region vehicles

                    Message = "Loading Starships...";

                    Icon = PlaceholderType.Starship;

                    var starships = await ProcessPaginatedModelAsync((int page) => _starWarsApi.GetStarshipsAsync(new QueryParameters { page = page }));

                    var starshipEntities = starships.Select(s => _mapper.Map<Data.Entities.Starship>(s));

                    context.Starships.AddRange(starshipEntities);

                    Progress = 80f;

                    #endregion

                    await context.SaveChangesAsync();
                }

                Progress = 100;
                return true;
            }
            // TODO
            catch(Exception ex)
            {
                using(var context = App.Current.Services.GetRequiredService<StarWarsDbContext>())
                    await context.Database.EnsureDeletedAsync();
                
                Progress = 0f;

                return false;
            }    
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
