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
using System.Text.RegularExpressions;
using StarWars.Data;
using Microsoft.EntityFrameworkCore;

namespace StarWars.UniversalWindows.ViewModels
{
    public class FilmsPageViewModel : ViewModelBase
    {
        private IMapper _mapper;
        private readonly StarWarsDbContext _context;

        public ObservableCollection<FilmViewModel> Films { get; } = new ObservableCollection<FilmViewModel>();


        public FilmsPageViewModel(StarWarsDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }        

        public async Task RefreshListAsync()
        {
            Films.Clear();

            try
            {
                var films = await _context.Films.ToListAsync();

                foreach (var film in films)
                    Films.Add(_mapper.Map<FilmViewModel>(film));
            }
            catch(Exception ex)
            {

            }
        }
    }
}
