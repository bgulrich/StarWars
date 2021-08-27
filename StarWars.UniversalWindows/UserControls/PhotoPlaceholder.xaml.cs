using System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StarWars.UniversalWindows.UserControls
{
    public enum PlaceholderType
    {
        None,
        Film,
        Person,
        Starship,
        Vehicle,
        Species,
        Planet
    }

    public sealed partial class PhotoPlaceholder : UserControl
    {
        private static Color[] backgroundColors = {
                                                    (Color)App.Current.Resources["MutedGreen"],
                                                    (Color)App.Current.Resources["MutedYellow"],
                                                    (Color)App.Current.Resources["MutedRed"],
                                                    (Color)App.Current.Resources["MutedBlue"],
                                                    (Color)App.Current.Resources["MutedOrange"],
                                                    (Color)App.Current.Resources["MutedPurple"]
                                                  };

        private static Brush[] backgroundBrushes;
        private static Random random = new Random();

        public PhotoPlaceholder()
        {
            this.InitializeComponent();
        }

        static PhotoPlaceholder()
        {
            backgroundBrushes = new Brush[backgroundColors.Length];

            for (int i = 0; i < backgroundBrushes.Length; ++i)
                backgroundBrushes[i] = new SolidColorBrush(backgroundColors[i]);
        }

        #region Dependency Properties

        public static readonly DependencyProperty UseRandomBackgroundColorProperty
            = DependencyProperty.Register("UseRandomBackgroundColor", typeof(bool), typeof(PhotoPlaceholder),
            new PropertyMetadata(false, (uph, e) => { ColorModeChanged(uph as PhotoPlaceholder, e); }));

        public bool UseRandomBackgroundColor
        {
            get { return (bool)GetValue(UseRandomBackgroundColorProperty); }
            set { SetValue(UseRandomBackgroundColorProperty, value); }
        }

        private static void ColorModeChanged(PhotoPlaceholder ph, DependencyPropertyChangedEventArgs e)
        {
            if (!(bool)e.NewValue)
                ph.Ellipse.Fill = backgroundBrushes[0]; // use default
            else
                ph.Ellipse.Fill = backgroundBrushes[random.Next(0, backgroundBrushes.Length)];
        }

        public static readonly DependencyProperty PlaceholderTypeProperty
            = DependencyProperty.Register("PlaceholderType", typeof(PlaceholderType), typeof(PhotoPlaceholder),
            new PropertyMetadata(PlaceholderType.None, (ph, e) => { PlaceholderTypeChanged(ph as PhotoPlaceholder, e); }));


        public PlaceholderType PlaceholderType
        {
            get { return (PlaceholderType)GetValue(PlaceholderTypeProperty); }
            set { SetValue(PlaceholderTypeProperty, value); }
        }

        private static void PlaceholderTypeChanged(PhotoPlaceholder ph, DependencyPropertyChangedEventArgs e)
        {
            var newValue = (PlaceholderType)e.NewValue;

            if (newValue == (PlaceholderType)e.OldValue)
                return;

            string pathKey = null;


            switch(newValue)
            {
                case PlaceholderType.Film: pathKey = "IconPath_Film"; break;
                case PlaceholderType.Person: pathKey = "IconPath_Person"; break;
                case PlaceholderType.Starship: pathKey = "IconPath_Rocket"; break;
                case PlaceholderType.Vehicle: pathKey = "IconPath_Car"; break;
                case PlaceholderType.Planet: pathKey = "IconPath_Planet"; break;
                case PlaceholderType.Species: pathKey = "IconPath_Monkey"; break;
            }

            if (pathKey != null)
                ph.PlaceholderIconPath.Data = Converters.Xaml.PathMarkupToGeometry((string)App.Current.Resources[pathKey]);

        }

        #endregion
    }
}
