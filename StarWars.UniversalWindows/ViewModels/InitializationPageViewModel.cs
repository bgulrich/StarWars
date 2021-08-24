using AutoMapper;
using StarWars.ApiClient;
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
                Message = "Creating Database...";

                await _context.Database.EnsureCreatedAsync();

                Message = "Initializing Films...";

                var films = await _starWarsApi.GetFilmsAsync();

                var filmEntities = films.Results.Select(f => _mapper.Map<Data.Entities.Film>(f));

                _context.Films.AddRange(filmEntities);

                await _context.SaveChangesAsync();

                await Task.Delay(5000);

            }
            catch { }        
        }

    }
}
