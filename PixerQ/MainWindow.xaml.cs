using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.IO;

namespace PixerQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string image;
        public MainWindow()
        {
            InitializeComponent();
            OriginalPicture.Width = (Application.Current.MainWindow.Width / 2) - 10;
            OriginalPicture.Height = Application.Current.MainWindow.Height / 1.5;
            ModifiedPicture.Width = (Application.Current.MainWindow.Width / 2) - 10;
            ModifiedPicture.Height = Application.Current.MainWindow.Height / 1.5;
        }

        private void SubMenuOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg; *.jpg)|*.png;*.jpeg; *.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (openFileDialog.ShowDialog() == true)
            {
                OriginalPicture.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                image = openFileDialog.FileName;
            }
        }

        private void SubMenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Filter_Black_White_Click(object sender, RoutedEventArgs e)
        {
            Bitmap bmp = new Bitmap(image);

            int widht = bmp.Width;
            int height = bmp.Height;

            System.Drawing.Color p;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < widht; x++)
                {
                    p = bmp.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int avg = (r + g + b) / 3;

                    bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, avg, avg, avg));
                }
            }
            Stream imageStream = new MemoryStream();
            bmp.Save(imageStream, ImageFormat.Bmp);
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            imageStream.Seek(0, SeekOrigin.Begin);
            img.StreamSource = imageStream;
            img.EndInit();
            ModifiedPicture.Source = img;
        }

        private void SubMenuSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            saveFile.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|PNG Image|*.png";
            saveFile.DefaultExt = "jpeg";
            saveFile.Title = "Imagem a gravar";
            saveFile.ShowDialog();
            if(saveFile.ShowDialog() == true)
            {
               //ModifiedPicture.
            }
        }

        private void Filter_Sepia_Click(object sender, RoutedEventArgs e)
        {
            Bitmap bmp = new Bitmap(image);

            int widht = bmp.Width;
            int height = bmp.Height;

            System.Drawing.Color p;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < widht; x++)
                {
                    p = bmp.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                    int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                    int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                    //set new RGB value
                    if (tr > 255)
                    {
                        r = 255;
                    }
                    else
                    {
                        r = tr;
                    }

                    if (tg > 255)
                    {
                        g = 255;
                    }
                    else
                    {
                        g = tg;
                    }

                    if (tb > 255)
                    {
                        b = 255;
                    }
                    else
                    {
                        b = tb;
                    }

                    bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(a, r, g, b));
                }
            }
            Stream imageStream = new MemoryStream();
            bmp.Save(imageStream, ImageFormat.Bmp);
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            imageStream.Seek(0, SeekOrigin.Begin);
            img.StreamSource = imageStream;
            img.EndInit();
            ModifiedPicture.Source = img;
        }

        private void Filter_Nevative_Click(object sender, RoutedEventArgs e)
        {
            //a
        }
    }
}
