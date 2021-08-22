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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace StarWars.UniversalWindows.UserControls
{
    public sealed partial class Photo : UserControl
    {
        public Photo()
        {
            this.InitializeComponent();
        }

        #region Dependency Properties

        public bool UseRandomBackgroundColor
        {
            get { return PhotoPlaceholder.UseRandomBackgroundColor; }
            set { PhotoPlaceholder.UseRandomBackgroundColor = value; }
        }

        public static readonly DependencyProperty UseAnimationProperty
           = DependencyProperty.Register("UseAnimation", typeof(bool), typeof(Photo),
           new PropertyMetadata(true));


        public bool UseAnimation
        {
            get { return (bool)GetValue(UseAnimationProperty); }
            set { SetValue(UseAnimationProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty
            = DependencyProperty.Register("Image", typeof(ImageSource), typeof(Photo),
            new PropertyMetadata(null, (up, e) => { ImageChanged(up as Photo, e); }));

        private static void ImageChanged(Photo p, DependencyPropertyChangedEventArgs e)
        {
            p.ImageChanged(e.NewValue as ImageSource);
        }

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty PlaceholderTypeProperty
            = DependencyProperty.Register("PlaceholderType", typeof(PlaceholderType), typeof(Photo),
            new PropertyMetadata(false, (p, e) => { (p as Photo).PhotoPlaceholder.PlaceholderType = (PlaceholderType)e.NewValue; }));


        public PlaceholderType PlaceholderType
        {
            get { return (PlaceholderType)GetValue(PlaceholderTypeProperty); }
            set { SetValue(PlaceholderTypeProperty, value); }
        }

        #endregion

        private void ImageChanged(ImageSource bmp)
        {
            if (!UseAnimation)
            {
                EllipseBrush.ImageSource = bmp;

                if (bmp != null)
                {
                    PhotoPlaceholder.Visibility = Visibility.Collapsed;
                    PhotoEllipse.Visibility = Visibility.Visible;
                }
                else
                {
                    PhotoPlaceholder.Visibility = Visibility.Visible;
                    PhotoEllipse.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                AnimatePhotoChange(bmp);
            }
        }

        private ImageSource copy;
        private Storyboard lastTransition;
        private Duration transitionDuration = new Duration(TimeSpan.FromMilliseconds(200));

        private void AnimatePhotoChange(ImageSource bmp)
        {
            // avoid running conflicting animations simultaneously
            if (lastTransition != null)
                lastTransition.Stop();

            // no previous photo
            if (PhotoPlaceholder.Visibility == Visibility.Visible)
            {
                // nothing to do
                if (bmp == null)
                    return;

                // initial state
                EllipseBrush.ImageSource = bmp;
                PhotoEllipse.Opacity = 1.0d;
                PhotoEllipse.Visibility = Visibility.Visible;

                // New storyboard
                Storyboard storyboard = new Storyboard();

                // animate opacity changes
                // placeholder
                DoubleAnimation pha = new DoubleAnimation()
                {
                    Duration = transitionDuration,
                    From = 1.0d,
                    To = 0.0d
                };

                Storyboard.SetTarget(pha, PhotoPlaceholder);
                Storyboard.SetTargetProperty(pha, "Opacity");
                storyboard.Children.Add(pha);

                storyboard.Completed += ToImage_Completed;

                lastTransition = storyboard;

                // kick off the animation
                storyboard.Begin();
            }
            // previous photo
            else
            {
                // to placeholder
                if (bmp == null)
                {
                    // initial state
                    PhotoPlaceholder.Opacity = 0.0d;
                    PhotoPlaceholder.Visibility = Visibility.Visible;

                    // New storyboard
                    Storyboard storyboard = new Storyboard();

                    // animate opacity changes
                    // placeholder
                    DoubleAnimation pha = new DoubleAnimation()
                    {
                        Duration = transitionDuration,
                        From = 0.0d,
                        To = 1.0d
                    };

                    Storyboard.SetTarget(pha, PhotoPlaceholder);
                    Storyboard.SetTargetProperty(pha, "Opacity");
                    storyboard.Children.Add(pha);

                    storyboard.Completed += ToPlaceholder_Completed;

                    lastTransition = storyboard;

                    // kick off the animation
                    storyboard.Begin();
                }
                // to new image
                else
                {
                    // initial state
                    PhotoEllipse.Opacity = 1.0d;
                    PhotoEllipse.Visibility = Visibility.Visible;

                    copy = bmp;

                    // New storyboard
                    Storyboard storyboard = new Storyboard();

                    // animate opacity changes
                    // photo
                    DoubleAnimation pa = new DoubleAnimation()
                    {
                        Duration = transitionDuration,
                        From = 1.0d,
                        To = 0.1d
                    };

                    Storyboard.SetTarget(pa, PhotoEllipse);
                    Storyboard.SetTargetProperty(pa, "Opacity");
                    storyboard.Children.Add(pa);

                    storyboard.Completed += OldImageFade_Completed;

                    lastTransition = storyboard;

                    // kick off the animation
                    storyboard.Begin();
                }
            }
        }

        private void OldImageFade_Completed(object sender, object e)
        {
            // now set the new photo
            EllipseBrush.ImageSource = copy;

            // Now fade it back in
            // New storyboard
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = TimeSpan.FromMilliseconds(100);

            // animate opacity changes
            // placeholder
            DoubleAnimation pa = new DoubleAnimation()
            {
                Duration = new Duration(duration),
                From = 0.1d,
                To = 1.0d
            };

            Storyboard.SetTarget(pa, PhotoEllipse);
            Storyboard.SetTargetProperty(pa, "Opacity");
            storyboard.Children.Add(pa);

            lastTransition = storyboard;

            // kick off the animation
            storyboard.Begin();
        }

        private void ToImage_Completed(object sender, object e)
        {
            PhotoPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void ToPlaceholder_Completed(object sender, object e)
        {
            PhotoEllipse.Visibility = Visibility.Collapsed;
            EllipseBrush.ImageSource = null;
        }
    }
}
