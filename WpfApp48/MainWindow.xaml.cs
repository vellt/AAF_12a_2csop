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

namespace WpfApp48
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> szovegek = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            szovegek = File.ReadAllLines("meme_szovegek.csv").ToList();
            gomb.Click += Gomb_Click;
            UjMeme();
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            UjMeme();
        }

        void UjMeme()
        {
            Random r = new Random();
            int kepIndex = r.Next(69) + 1;
            int szovegIndex = r.Next(szovegek.Count());

            szoveg.Text = szovegek[szovegIndex];
            kep.Source = new BitmapImage(new Uri($"Images/{kepIndex}.jpg", UriKind.Relative));
        }
    }
}
