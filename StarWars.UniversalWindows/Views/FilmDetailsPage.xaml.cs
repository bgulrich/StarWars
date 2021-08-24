using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StarWars.UniversalWindows.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FilmDetailsPage : Page
    {
        public FilmDetailsPage()
        {
            this.InitializeComponent();

            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            currentView.BackRequested += (s, a) => Frame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            DataContext = e.Parameter;

            var phtotoAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("filmPhotoAnimation");

            if (phtotoAnimation != null)
            {
                phtotoAnimation.TryStart(Photo);
            }

            var titleAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("filmTitleAnimation");

            if (titleAnimation != null)
            {
                titleAnimation.TryStart(Title);
            }
        }

        public ViewModels.FilmViewModel Film => DataContext as ViewModels.FilmViewModel;
    }
}
