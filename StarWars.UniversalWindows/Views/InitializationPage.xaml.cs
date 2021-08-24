using StarWars.UniversalWindows.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StarWars.UniversalWindows.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InitializationPage : Page
    {
        public InitializationPage()
        {
            this.InitializeComponent();
            DataContext = App.Current.Services.GetRequiredService<InitializationPageViewModel>();
        }

        InitializationPageViewModel ViewModel => DataContext as InitializationPageViewModel;

        private async void InitializeButton_Click(object sender, RoutedEventArgs e)
        {
            InitializeButton.IsEnabled = false;

            // clear logo
            Icon.Image = null;

            try
            {
                await ViewModel.InitializeDatabaseAsync();
                Frame.Navigate(typeof(FilmsPage));
            }
            catch 
            { 
                // TODO: content dialog to inform, cleanup db
            }

            InitializeButton.IsEnabled = true;
        }
    }
}
