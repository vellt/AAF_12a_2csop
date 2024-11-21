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

namespace WpfApp43
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pirosCsuszka.ValueChanged += PirosCsuszka_ValueChanged;
            zoldCsuszka.ValueChanged += ZoldCsuszka_ValueChanged;
            kekCsuszka.ValueChanged += KekCsuszka_ValueChanged;
        }

        private void KekCsuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            kekErtek.Text = kekCsuszka.Value.ToString();
            Szinezes();
        }

        private void ZoldCsuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            zoldErtek.Text = zoldCsuszka.Value.ToString();
            Szinezes();
        }

        private void PirosCsuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            pirosErtek.Text = pirosCsuszka.Value.ToString();
            Szinezes();
        }

        private void Szinezes()
        {
            byte r = Convert.ToByte(pirosCsuszka.Value);
            byte g = Convert.ToByte(zoldCsuszka.Value);
            byte b = Convert.ToByte(kekCsuszka.Value);
            kijelzo.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}
