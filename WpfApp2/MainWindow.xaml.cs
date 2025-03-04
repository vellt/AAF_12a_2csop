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

namespace WpfApp2
{

    class Szinesz
    {
        public string Kep { get; set; }
        public int Nepszeruseg { get; set; }
        public string Nev { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lista.ItemsSource = File.ReadAllLines("szineszek.csv")
                .Skip(1)
                .Select(x=>x.Split(';'))
                .Select(x=> new Szinesz()
                {
                    Kep=x[0],
                    Nepszeruseg=Convert.ToInt32(x[1]),
                    Nev=x[2]
                }).ToList();
            lista.DisplayMemberPath = "Nev";
            lista.SelectionChanged += Lista_SelectionChanged;
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Szinesz szines = lista.SelectedItem as Szinesz;
            nev.Text = szines.Nev;
            nepszeruseg.Text = $"Népszerűség: {szines.Nepszeruseg}%";
            kep.Fill = new ImageBrush(new BitmapImage(new Uri(szines.Kep, UriKind.Relative)));
            indikator.Value = szines.Nepszeruseg;
        }
    }
}
