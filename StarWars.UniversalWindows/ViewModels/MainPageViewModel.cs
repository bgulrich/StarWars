using AutoMapper;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Refit;
using StarWars.ApiClient;
using StarWars.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using System.Text.RegularExpressions;

namespace StarWars.UniversalWindows.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IStarWarsApi _starWarsApi;
        private Mapper _mapper;

        public ObservableCollection<FilmViewModel> Films { get; } = new ObservableCollection<FilmViewModel>();


        public MainPageViewModel()
        {
            _starWarsApi = RestService.For<IStarWarsApi>("https://swapi.dev/", new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() })));

            
            
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Film, FilmViewModel>()
                   .ForMember(fvm => fvm.CharacterIndices, opt => opt.MapFrom(f => f.CharacterUris.Select(s => GetIndex(s))));
            }));
        }

        private Regex _indexRegex = new Regex(@"/?(<index>\d*)/$");

        private int GetIndex(string url)
        {
            return int.Parse(new Uri(url).Segments.Last().Trim('/'));
        }

        public async Task RefreshListAsync()
        {
            Films.Clear();

            try
            {
                var films = await _starWarsApi.GetFilmsAsync();

                foreach (var film in films.Results)
                    Films.Add(_mapper.Map<FilmViewModel>(film));
            }
            catch(Exception ex)
            {

            }
        }
    }
}
