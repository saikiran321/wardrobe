using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
    /// 
    public class MyImage
    {
        public BitmapImage teaser_image { get; set; }
    }
    public class MyFlipViewSource
    {
        public ObservableCollection<MyImage> MyGridViewImageSource { get; set; }
    }
    public sealed partial class Opt3_Collections : Page
    {
        public ObservableCollection<MyFlipViewSource> MyFlipViewSourceList = new ObservableCollection<MyFlipViewSource>();
        int n=0;
        public Opt3_Collections()
        {
            this.InitializeComponent();
            string filename = String.Format(ApplicationData.Current.LocalFolder.Path.ToString() + @"/data.txt");
            List<String> image = new List<string>();
            List<String> imageb = new List<string>();
            
            if (System.IO.File.Exists(filename)==true)
            {
                //System.IO.StreamReader objReader;
                //byte[] byteArray = Encoding.UTF8.GetBytes(filename);
                //MemoryStream stream = new MemoryStream(byteArray);
                //objReader = new StreamReader(stream);
                string[] lines = System.IO.File.ReadAllLines(filename);
                n = lines.Length;
                foreach (string line in lines)
                {
                    imageb.Add(line.Substring(((line.Length - 10) / 2) + 4, (line.Length +2)/2));
                    image.Add(line.Substring(0,(line.Length-4)/2));    
                }    

            }

            for(int i=0; i<n; i++)
            {
                BitmapImage img = new BitmapImage(new Uri(image[i]));
                BitmapImage imgb = new BitmapImage(new Uri(imageb[i]));
                flipViewtop.Items.Add(img);
                flipViewbottom.Items.Add(imgb);
               
            }

            
           
           
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

        private void flipViewtop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            flipViewbottom.IsEnabled = true;
            int i = flipViewtop.SelectedIndex;
            //flipViewbottom.SelectedIndex = flipViewbottom.SelectedIndex+1;
            if (i > 0 || (i==0&& flipViewbottom.SelectedIndex>0))
            {
                flipViewbottom.SelectedIndex = i;
            }
            flipViewbottom.IsEnabled = false;
        }
    }
}
