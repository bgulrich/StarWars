using Microsoft.Extensions.DependencyInjection;
using StarWars.ApiClient.Models;
using StarWars.Data;
using StarWars.UniversalWindows.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Refit;
using StarWars.ApiClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AutoMapper;

namespace StarWars.UniversalWindows
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }


        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<StarWarsDbContext>();

            services.AddTransient<ViewModels.InitializationPageViewModel>();
            services.AddTransient<ViewModels.FilmsPageViewModel>();

            services.AddAutoMapper(cfg =>
            {
                #region api models to db entities

                Func<Uri, int> getId = (Uri uri) => int.Parse(uri.Segments.Last().Trim('/'));
                Func<Uri, int?> getNullableId = (Uri uri) => uri == null ? (int?)null : getId(uri);

                cfg.CreateMap<Film, Data.Entities.Film>()
                   .ForMember(e => e.Id, opt => opt.MapFrom(f => getId(f.Uri)))
                   .ForMember(e => e.FilmCharacters, opt => opt.MapFrom(f => f.CharacterUris.Select(uri => new Data.Entities.FilmCharacter { FilmId = getId(f.Uri), CharacterId = getId(uri) })))
                   .ForMember(e => e.FilmSpecies, opt => opt.MapFrom(f => f.SpeciesUris.Select(uri => new Data.Entities.FilmSpecies { FilmId = getId(f.Uri), SpeciesId = getId(uri) })))
                   .ForMember(e => e.FilmPlanets, opt => opt.MapFrom(f => f.PlanetUris.Select(uri => new Data.Entities.FilmPlanet { FilmId = getId(f.Uri), PlanetId = getId(uri) })))
                   .ForMember(e => e.FilmVehicles, opt => opt.MapFrom(f => f.VehicleUris.Select(uri => new Data.Entities.FilmVehicle { FilmId = getId(f.Uri), VehicleId = getId(uri) })))
                   .ForMember(e => e.FilmStarships, opt => opt.MapFrom(f => f.StarshipUris.Select(uri => new Data.Entities.FilmStarship { FilmId = getId(f.Uri), StarshipId = getId(uri) })));

                cfg.CreateMap<Person, Data.Entities.Character>()
                   .ForMember(e => e.Id, opt => opt.MapFrom(p => getId(p.Uri)))
                   .ForMember(e => e.HomeWorldId, opt => opt.MapFrom(p => getNullableId(p.HomeWorldUri)))
                   .ForMember(e => e.CharacterSpecies, opt => opt.MapFrom(p => p.SpeciesUris.Select(uri => new Data.Entities.CharacterSpecies { CharacterId = getId(p.Uri), SpeciesId = getId(uri) })))
                   .ForMember(e => e.CharacterStarships, opt => opt.MapFrom(p => p.StarshipUris.Select(uri => new Data.Entities.CharacterStarship { CharacterId = getId(p.Uri), StarshipId = getId(uri) })))
                   .ForMember(e => e.CharacterVehicles, opt => opt.MapFrom(p => p.VehicleUris.Select(uri => new Data.Entities.CharacterVehicle { CharacterId = getId(p.Uri), VehicleId = getId(uri) })));

                cfg.CreateMap<Species, Data.Entities.Species>()
                   .ForMember(e => e.Id, opt => opt.MapFrom(s => getId(s.Uri)))
                   .ForMember(e => e.HomeWorldId, opt => opt.MapFrom(s => getNullableId(s.HomeWorldUri)));

                cfg.CreateMap<Planet, Data.Entities.Planet>()
                   .ForMember(e => e.Id, opt => opt.MapFrom(p => getId(p.Uri)));

                cfg.CreateMap<Vehicle, Data.Entities.Vehicle>()
                   .ForMember(e => e.Id, opt => opt.MapFrom(v => getId(v.Uri)));

                cfg.CreateMap<Starship, Data.Entities.Starship>()
                   .ForMember(e => e.Id, opt => opt.MapFrom(s => getId(s.Uri)));

                #endregion

                #region db entities to view models

                cfg.CreateMap<Data.Entities.Film, FilmViewModel>();

                #endregion
            });

            services.AddRefitClient<IStarWarsApi>(new RefitSettings(new NewtonsoftJsonContentSerializer(new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() })))
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://swapi.dev/"));

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(Views.InitializationPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
