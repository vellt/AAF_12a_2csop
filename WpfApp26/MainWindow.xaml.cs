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

namespace WpfApp26
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomSzam = new Random().Next(1, 11);
        int lepes = 0;
        public MainWindow()
        {
            InitializeComponent();
            csuszka.ValueChanged += Csuszka_ValueChanged;
            gomb.Click += Gomb_Click;
            
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            lepes++;
            int gep = randomSzam;
            int felh = Convert.ToInt32(csuszka.Value);
            if (gep==felh)
            {
                MessageBox.Show($"{Convert.ToString(lepes-1)} lépésből","eltaláltad!");
                // új játék
                randomSzam = new Random().Next(1, 11);
                csuszka.Value = 1;
                lepes = 0;
            }
            else if (felh<gep)
            {
                MessageBox.Show($"{Convert.ToString(lepes - 1)}. lépés", "nagyobbra gondoltam");

            }
            else
            {
                MessageBox.Show($"{Convert.ToString(lepes - 1)}. lépés", "kisebbre gondoltam");
            }
        }

        private void Csuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            szam.Text =Convert.ToInt32(csuszka.Value).ToString();
        }
    }
}
