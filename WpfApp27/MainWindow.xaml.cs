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

namespace WpfApp27
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            meme.MouseEnter += Meme_MouseEnter;
        }

        private void Meme_MouseEnter(object sender, MouseEventArgs e)
        {
            veleltlenHely(sender as Image);
            for (int i = 0; i < 2; i++)
            {
                Image img = new Image();
                img.Height = 200;
                img.Width = 200;
                img.Source = new BitmapImage(new Uri("egg.png", UriKind.Relative));
                img.MouseEnter += Meme_MouseEnter;

                kijelzo.Children.Add(img);
                veleltlenHely(img);
            }
        }

        private void veleltlenHely(Image image)
        {
            int x =r.Next(Convert.ToInt32(SystemParameters.PrimaryScreenWidth-image.Width));
            int y = r.Next(Convert.ToInt32(SystemParameters.PrimaryScreenHeight - image.Height));
            Canvas.SetLeft(image,x);
            Canvas.SetTop(image,y);
        }
    }
}
