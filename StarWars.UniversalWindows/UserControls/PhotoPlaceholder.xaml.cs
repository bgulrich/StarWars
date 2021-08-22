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
        Species
    }

    public sealed partial class PhotoPlaceholder : UserControl
    {
        private static Color[] backgroundColors = {
                                                    Color.FromArgb(0xff, 0x4e, 0x61, 0x4d),  // green
                                                    Color.FromArgb(0xff, 0x2C, 0x1d, 0x30),  // purple
                                                    Color.FromArgb(0xff, 0xb2, 0xa6, 0x4d),  // yellow
                                                    Color.FromArgb(0xff, 0x8c, 0x68, 0x66),  // red
                                                    Color.FromArgb(0xff, 0x48, 0x51, 0x75),  // blue
                                                    Color.FromArgb(0xff, 0xd0, 0x79, 0x36)   // orange
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

            string pathString = null;

            switch(newValue)
            {
                case PlaceholderType.Film: pathString = (string)App.Current.Resources["IconPath_Film"]; break;
                case PlaceholderType.Person: pathString = (string)App.Current.Resources["IconPath_Person"]; break;
            }

            if (pathString != null)
                ph.PlaceholderIconPath.Data = Converters.Xaml.PathMarkupToGeometry(pathString);

        }

        #endregion
    }
}
