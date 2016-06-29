using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Wardrobe_Assistant
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Main_Interface : Page
    {
        string name;
        string nameb;
        public Main_Interface()
        {
            this.InitializeComponent();
            string pa = String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/Tops");
            try {
                DirectoryInfo di = new DirectoryInfo(pa);
                FileInfo[] Images = di.GetFiles("*.jpg");

                Random rnd = new Random();
                int i = rnd.Next(0, Images.Length);
                name = String.Format(String.Format(@"{0}/{1}", pa, Images[i].Name));
                BitmapImage img = new BitmapImage(new Uri(name));
                RandomCollectiontop.Source = img;
            }
            catch
            {

            }
            try {
                string ma = String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/Bottoms");
                DirectoryInfo dib = new DirectoryInfo(ma);
                FileInfo[] Imagesb = dib.GetFiles("*.jpg");
                Random rndb = new Random();
                int ib = rndb.Next(0, Imagesb.Length);
                nameb = String.Format(String.Format(@"{0}/{1}", ma, Imagesb[ib].Name));
                BitmapImage imgb = new BitmapImage(new Uri(nameb));
                RandomCollectionbottom.Source = imgb;
            }
            catch { }
        }

       

        private void Option1(ListViewBase sender, ChoosingGroupHeaderContainerEventArgs args)
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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            string pa = String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/Tops");
            DirectoryInfo di = new DirectoryInfo(pa);
            FileInfo[] Images = di.GetFiles("*.jpg");
            Random rnd = new Random();
            int i = rnd.Next(0, Images.Length);
            name = String.Format(String.Format(@"{0}/{1}", pa, Images[i].Name));
            BitmapImage img = new BitmapImage(new Uri(name));
            RandomCollectiontop.Source = img;

            string ma = String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/Bottoms");
            DirectoryInfo dib = new DirectoryInfo(ma);
            FileInfo[] Imagesb = dib.GetFiles("*.jpg");
            Random rndb = new Random();
            int ib = rndb.Next(0, Imagesb.Length);
            nameb = String.Format(String.Format(@"{0}/{1}", ma, Imagesb[ib].Name));
            BitmapImage imgb = new BitmapImage(new Uri(nameb));
            RandomCollectionbottom.Source = imgb;

        }
       
        private void button_Click(object sender, RoutedEventArgs e)
        {

            using (FileStream aFile = new FileStream(String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/data.txt"), FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.WriteLine(name+","+nameb);
            }

        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
    
}
