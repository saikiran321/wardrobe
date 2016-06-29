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
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Wardrobe_Assistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            /*
            progress1.IsActive = true;
            progress1.Visibility = Visibility.Visible;
            */

            /*  progress1.IsActive = false;
                    progress1.Visibility = Visibility.Collapsed; */
         

        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private  async void button_Click(object sender, RoutedEventArgs e)
        {
            
            var folder = ApplicationData.Current.LocalFolder;
            var Tops = await folder.TryGetItemAsync("Tops") as StorageFolder;
            if (Tops == null)
            
                Tops = await folder.CreateFolderAsync("Tops", CreationCollisionOption.OpenIfExists);
            
            var Bottoms = await folder.TryGetItemAsync("Bottoms") as StorageFolder;
            if (Bottoms == null)
                Bottoms = await folder.CreateFolderAsync("Bottoms", CreationCollisionOption.OpenIfExists);
            var Collections = await folder.TryGetItemAsync("Collections") as StorageFolder;
            if (Collections == null)
            {
                Collections = await folder.CreateFolderAsync("Collections", CreationCollisionOption.OpenIfExists);
                Frame.Navigate(typeof(Intro));
            }
            else
                Frame.Navigate(typeof(Main_Interface));
        }
    }
}
