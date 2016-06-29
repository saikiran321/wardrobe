using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
    public sealed partial class Opt2_MixMatch : Page
    {
        string ma;
        string pa;
        DirectoryInfo di;
        FileInfo[] Images;
        DirectoryInfo dib;
        FileInfo[] Imagesb;
        public Opt2_MixMatch()
        {
            this.InitializeComponent();
            try {
                pa = String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/Tops");
                di = new DirectoryInfo(pa);
                Images = di.GetFiles("*.jpg");
                List<String> imagesList = new List<String>();

                for (int i = 0; i < Images.Length; i++)
                {
                    //imagesList.Add(String.Format(@"{0}/{1}", pa, Images[i].Name));
                    //Debug.WriteLine(String.Format(@"{0}/{1}", pa, Images[i].Name));
                    string name = String.Format(String.Format(@"{0}/{1}", pa, Images[Images.Length-i-1].Name));
                    BitmapImage img = new BitmapImage(new Uri(name));
                    flipViewtop.Items.Add(img);
                }
            }
            catch
            { }
            try {
                ma = String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/Bottoms");
                dib = new DirectoryInfo(ma);
                Imagesb = dib.GetFiles("*.jpg");
                List<String> imagesListb = new List<String>();

                for (int i = 0; i < Imagesb.Length; i++)
                {
                    //imagesList.Add(String.Format(@"{0}/{1}", pa, Images[i].Name));
                    //Debug.WriteLine(String.Format(@"{0}/{1}", pa, Images[i].Name));
                    string name = String.Format(String.Format(@"{0}/{1}", ma, Imagesb[Imagesb.Length-i-1].Name));
                    BitmapImage img = new BitmapImage(new Uri(name));
                    flipViewbottom.Items.Add(img);
                }
            }
            catch { }

            //return imagesList;
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


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int i = flipViewtop.SelectedIndex;
            string name = String.Format(String.Format(@"{0}/{1}", pa, Images[Images.Length - i - 1].Name));
            int j = flipViewbottom.SelectedIndex;
            string nameb = String.Format(String.Format(@"{0}/{1}", ma, Imagesb[Imagesb.Length - j - 1].Name));
            using (FileStream aFile = new FileStream(String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/data.txt"), FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(aFile))
            {
                sw.WriteLine(name + "," + nameb);
            }

        }

        private void flipViewtop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
