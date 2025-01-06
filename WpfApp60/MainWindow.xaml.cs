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

namespace WpfApp60
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<int> szavazatok = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            novel.Click += Novel_Click;
            csokkent.Click += Csokkent_Click;
        }

        private void Csokkent_Click(object sender, RoutedEventArgs e)
        {
            if (csillagok.Children.Count > 1)
            {
                csillagok.Children.RemoveAt(0);
            }
        }

        private void Novel_Click(object sender, RoutedEventArgs e)
        {
            if (csillagok.Children.Count < 5)
            {
                Image img = new Image();
                img.Source =new BitmapImage(new Uri("star.png",UriKind.Relative));
                img.Height = 20;

                csillagok.Children.Add(img);
            }
        }
    }
}
