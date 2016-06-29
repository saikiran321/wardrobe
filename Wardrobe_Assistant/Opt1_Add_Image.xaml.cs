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
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml.Media.Imaging;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Wardrobe_Assistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Opt1_Add_Image : Page
    {
         public static int Sel;
        public static StorageFile photo;
        public Opt1_Add_Image()
        {
            this.InitializeComponent();
        }

        private void Top_Click(object sender, RoutedEventArgs e)
        {
            Sel = 1;
            comboBox.PlaceholderText = "Top";
            comboBox.IsDropDownOpen=false;
        
        }


        private void Bottom_Click(object sender, RoutedEventArgs e)
        {
            Sel = 2;
            comboBox.PlaceholderText = "Bottom";
            comboBox.IsDropDownOpen = false;
        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            Saved.Visibility = Visibility.Collapsed;
            /*
                        if (Tops == null)
                            Tops = await folder.CreateFolderAsync("Tops", CreationCollisionOption.OpenIfExists);

                        if (Bottoms == null)
                            Bottoms = await folder.CreateFolderAsync("Bottoms", CreationCollisionOption.OpenIfExists);
            */

            CameraCaptureUI camera = new CameraCaptureUI();
            camera.PhotoSettings.CroppedAspectRatio = new Size(200, 200);
             photo = await camera.
                                   CaptureFileAsync(CameraCaptureUIMode.Photo);

            
            //######
            IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
            BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
            SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

            SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
        BitmapPixelFormat.Bgra8,
        BitmapAlphaMode.Premultiplied);

            SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
            await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

            image.Source = bitmapSource;

           

        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
             
        }

        private void Explore_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Main_Interface));
        }

        private void AddDress_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Opt1_Add_Image));
        }

        private void MixMatch_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Opt2_MixMatch));
        }

        private void MyCollections_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Opt3_Collections));
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {

            var folder = ApplicationData.Current.LocalFolder;
            var Tops = await folder.TryGetItemAsync("Tops") as StorageFolder;
            var Bottoms = await folder.TryGetItemAsync("Bottoms") as StorageFolder;

            if (photo != null)
            {
                DateTime da = DateTime.Now;
                string day = da.ToString("yyyy-dd-M--HH-mm-ss") + ".jpg";
                StorageFile targetFile = null;
                if (Sel == 1)
                {
                    targetFile = await Tops.CreateFileAsync(day) as StorageFile;
                }
                if (Sel == 2)
                {
                    targetFile = await Bottoms.CreateFileAsync(day) as StorageFile;
                }

                if (targetFile != null)
                {
                    await photo.MoveAndReplaceAsync(targetFile);
                }

                Saved.Visibility = Visibility.Visible;
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            Saved.Visibility = Visibility.Collapsed;

            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            photo = await picker.PickSingleFileAsync();
            if (photo != null)
            {
                // Application now has read/write access to the picked file
               // this.textBlock.Text = "Picked photo: " + photo.Name;

                IRandomAccessStream stream = await photo.OpenAsync(FileAccessMode.Read);
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                SoftwareBitmap softwareBitmap = await decoder.GetSoftwareBitmapAsync();

                SoftwareBitmap softwareBitmapBGR8 = SoftwareBitmap.Convert(softwareBitmap,
            BitmapPixelFormat.Bgra8,
            BitmapAlphaMode.Premultiplied);

                SoftwareBitmapSource bitmapSource = new SoftwareBitmapSource();
                await bitmapSource.SetBitmapAsync(softwareBitmapBGR8);

                image.Source = bitmapSource;

            }
            else
            {
                //this.textBlock.Text = "Operation cancelled.";
            }

           

        }

        private void textBlock2_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
