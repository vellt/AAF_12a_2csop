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
using System.IO;

namespace WpfApp89
{
    class Karakter
    {
        public string Nev { get; set; }
        public string Haz { get; set; }
        public int SzuletesiEv { get; set; }
        public string Kep { get; set; }
        public int Erosseg { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            karakterTallozo.ItemsSource = ReadData();
            karakterTallozo.DisplayMemberPath = "Nev";
            karakterTallozo.SelectionChanged += KarakterTallozo_SelectionChanged;
            karakterTallozo.SelectedIndex = 0;
        }

        private void KarakterTallozo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Karakter kivalasztottKarakter = karakterTallozo.SelectedItem as Karakter;
            kep.Source = new BitmapImage(new Uri(kivalasztottKarakter.Kep, UriKind.Absolute)); // Absolute, mert netes képet hivatkoz le!
            nev.Text = kivalasztottKarakter.Nev;
            haz.Text =$"Ház: {kivalasztottKarakter.Haz}";
            ev.Text =$"Születési év: {kivalasztottKarakter.SzuletesiEv}";
            erosseg2.Value = kivalasztottKarakter.Erosseg;

            // jön a gyámhatóság 
            erosseg.Children.Clear();
            for (int i = 0; i < kivalasztottKarakter.Erosseg; i++)
            {
                Image villam = new Image();
                villam.Source = new BitmapImage(new Uri("images/strong.png", UriKind.Relative));
                villam.Width = 30;
                villam.Margin = new Thickness(10);

                erosseg.Children.Add(villam);
            }
        }

        List<Karakter> ReadData()
        {
            return File.ReadAllLines("harry_potter_characters_hu.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Karakter()
                {
                    Nev=x[0],
                    Haz=x[1],
                    SzuletesiEv=Convert.ToInt32(x[2]),
                    Kep=x[3],
                    Erosseg=Convert.ToInt32(x[4])
                }).ToList();
        }
    }
}
