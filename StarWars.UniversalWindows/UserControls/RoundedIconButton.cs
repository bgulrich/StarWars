using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace StarWars.UniversalWindows.UserControls
{
    [TemplatePart(Name = ShadowPart, Type = typeof(CompositionShadow))]
    public class RoundedIconButton : Button, IDisposable
    {
        private const string ShadowPart = "Shadow";

        private CompositionShadow shadow;

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            // set up items - presenter before shadow canvas so margin is set
            shadow = GetTemplateChild(ShadowPart) as CompositionShadow;
        }

        public PathGeometry IconGeometry
        {
            get { return (PathGeometry)GetValue(IconGeometryProperty); }
            set { SetValue(IconGeometryProperty, value); }
        }

        public static readonly DependencyProperty IconGeometryProperty =
          DependencyProperty.Register("IconGeometry", typeof(PathGeometry), typeof(RoundedIconButton), new PropertyMetadata(typeof(RoundedIconButton)));

        public string IconPath
        {
            get { return (string)GetValue(IconPathProperty); }
            set { SetValue(IconPathProperty, value); }
        }

        public static readonly DependencyProperty IconPathProperty =
          DependencyProperty.Register("IconPath", typeof(string), typeof(RoundedIconButton), new PropertyMetadata(typeof(RoundedIconButton), (ib, e) => { Changed(ib as RoundedIconButton, e.NewValue as string); }));

        private static void Changed(RoundedIconButton roundedIconButton, string s)
        {
            var geometry = Converters.Xaml.PathMarkupToGeometry(s);
            if (geometry != null)
                roundedIconButton.IconGeometry = (PathGeometry)geometry;
        }

        public void Dispose()
        {
            shadow?.Dispose();
        }
    }
}
