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
using System.Media;

namespace WpfApp83
{
    class Dino
    {
        public string Nev { get; set; }
        public string Kep { get; set; }
        public string Leiras { get; set; }
    }
    public partial class MainWindow : Window
    {
        SoundPlayer player = new SoundPlayer();
        bool isPlaying = true;
        public MainWindow()
        {
            InitializeComponent();
            nevek.ItemsSource = ReadData();
            nevek.DisplayMemberPath = "Nev";
            nevek.SelectionChanged += Nevek_SelectionChanged;
            nevek.SelectedIndex = 0;
            elozo.Click += Elozo_Click;
            kovetkezo.Click += Kovetkezo_Click;
            player.SoundLocation = "africa.wav";
            player.PlayLooping();
            zene.MouseUp += Zene_MouseUp;
        }

        private void Zene_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image ikon = zene.Children[0] as Image;
            if (isPlaying)
            {
                player.Stop();
                isPlaying = false;
                ikon.Source = new BitmapImage(new Uri("kepek/mute.png", UriKind.Relative));
            }
            else // ez az az eset amikor az isplaying false értékű
            {
                player.PlayLooping();
                isPlaying = true;
                ikon.Source = new BitmapImage(new Uri("kepek/unmute.png", UriKind.Relative));
            }
        }

        private void Kovetkezo_Click(object sender, RoutedEventArgs e)
        {
            nevek.SelectedIndex += 1;
        }

        private void Elozo_Click(object sender, RoutedEventArgs e)
        {
            if (nevek.SelectedIndex!=0)
            {
                nevek.SelectedIndex -= 1;
            }
            
        }

        private void Nevek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dino kivalasztottDino = nevek.SelectedItem as Dino;
            szoveg.Text = kivalasztottDino.Leiras;
            kep.Source = new BitmapImage(new Uri($"kepek/{kivalasztottDino.Kep}", UriKind.Relative));
            sorszam.Text = $"{nevek.SelectedIndex+1}/7";
        }

        List<Dino> ReadData()
        {
            return File.ReadAllLines("dinok.csv")
                .Skip(1)
                .Select(x=>x.Split(';'))
                .Select(x=>new Dino()
                {
                    Nev=x[0],
                    Kep=x[1],
                    Leiras=x[2]
                }).ToList();
        }
    }
}
