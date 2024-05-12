using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DBracket.Common.UI.WPF.Controls
{
    // Source: https://stackoverflow.com/questions/70456743/wpf-ui-performance-impact-when-loading-images

    public class AsyncImage : Image
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"

        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
    //    public static readonly DependencyProperty ImagePathProperty =
    //DependencyProperty.Register(
    //    nameof(ImagePath), typeof(string), typeof(AsyncImage),
    //    new PropertyMetadata(async (o, e) =>
    //        await ((AsyncImage)o).LoadImageAsync((string)e.NewValue)));        
        
        
        public static readonly DependencyProperty ImagePathProperty =
    DependencyProperty.Register(
        nameof(ImagePath), typeof(string), typeof(AsyncImage),
        new PropertyMetadata((o, e) =>
            ((AsyncImage)o).LoadImageAsync((string)e.NewValue)));

        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        public static readonly DependencyProperty DefaultSourceProperty =
DependencyProperty.Register(
nameof(DefaultSource), typeof(Uri), typeof(AsyncImage),
new PropertyMetadata(null, HandleTest));

        private static void HandleTest(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var image = (AsyncImage)d;
            if (image is null)
                return;

            if (image.Source is null && image.DefaultSource is not null)
                image.Source = new BitmapImage(image.DefaultSource);
        }

        public Uri DefaultSource
        {
            get { return (Uri)GetValue(DefaultSourceProperty); }
            set { SetValue(DefaultSourceProperty, value); }
        }

        private Task LoadImageAsync(string imagePath)
        {
            if (DefaultSource is not null)
            {
                Source = new BitmapImage(DefaultSource);// DefaultSource;
            }

            if (imagePath.EndsWith(".db"))
                return null;

            var t = Task.Run(() =>
            {
                Debug.WriteLine($"Start");
                using (var stream = File.OpenRead(imagePath))
                {
                    var bi = new BitmapImage();
                    try
                    {
                        bi.BeginInit();
                        bi.CacheOption = BitmapCacheOption.OnLoad;
                        bi.StreamSource = stream;
                        bi.EndInit();
                        bi.Freeze();
                        Application.Current.Dispatcher.Invoke(() => Source = bi);

                    }
                    catch (Exception ex)
                    {
                        //return null;
                    }
                    //return bi;
                }
                Debug.WriteLine($"Stop");
            });
            return t;
        }
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}