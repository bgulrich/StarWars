using Microsoft.Extensions.DependencyInjection;
using StarWars.UniversalWindows.UserControls;
using StarWars.UniversalWindows.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StarWars.UniversalWindows.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FilmsPage : Page
    {

        public FilmsPage()
        {
            this.InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<FilmsPageViewModel>();
        }

        // strongly-typed view models enable compiled bindings
        public ViewModels.FilmsPageViewModel ViewModel => DataContext as ViewModels.FilmsPageViewModel;

        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.RefreshListAsync();

           
        }

        private void Film_Click(object sender, ItemClickEventArgs e)
        {
            var listView = sender as ListView;
            var filmItem = (listView.ContainerFromItem(e.ClickedItem) as ListViewItem).ContentTemplateRoot as FilmItem;

            var connectedAnimationService = ConnectedAnimationService.GetForCurrentView();
            connectedAnimationService.PrepareToAnimate("filmPhotoAnimation", filmItem.PhotoControl);
            connectedAnimationService.PrepareToAnimate("filmTitleAnimation", filmItem.TitleControl);

            var filmViewModel = e.ClickedItem as FilmViewModel;
            Frame.Navigate(typeof(Views.FilmDetailsPage), filmViewModel);
        }
    }
}
