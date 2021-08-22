using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace StarWars.UniversalWindows.Converters
{
    public static class Xaml
    {
        const string pathFormatter = "<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Path.Data>{0}</Path.Data ></Path >";

        public static Geometry PathMarkupToGeometry(string pathMarkup)
        {
            try
            {
                // Detach the PathGeometry from the Path
                if (XamlReader.Load(string.Format(pathFormatter, pathMarkup)) is Path path)
                {
                    Geometry geometry = path.Data;
                    path.Data = null;
                    return geometry;
                }
                return null;
            }
            catch
            { return null; }
        }
    }
}
