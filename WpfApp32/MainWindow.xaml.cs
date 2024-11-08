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

namespace WpfApp32
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            hatter.MouseUp += Hatter_MouseUp;
        }

        private void Hatter_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Random r = new Random();
            int szam = r.Next(1, 7); //[1,6]
            // képet c# kódból mindig így tudunk behelyezni
            dobokocka.Source = new BitmapImage(new Uri($"dice{szam}.png", UriKind.Relative));
        }
    }
}
