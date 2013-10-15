using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GraphicNotes
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    BitmapImage bi = imageEdit1.Source as BitmapImage;
        //    byte[] data;
        //    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create(bi));
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        encoder.Save(ms);
        //        data = ms.ToArray();

        //        BitmapImage imageSource = new BitmapImage();
        //        imageSource.BeginInit();
        //        imageSource.StreamSource = new MemoryStream(data);
        //        imageSource.EndInit();

        //        // Assign the Source property of your image
           
        //    }

        //    Console.WriteLine(data[0] + " " + data[1] + " " + data[2] + " " + data[3]);
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SolidColorBrush iconBrush = new SolidColorBrush(); 
            iconBrush.Color = Colors.Orange; 
            this.Resources["IconBrush1"] = iconBrush;

        }
    }
}
