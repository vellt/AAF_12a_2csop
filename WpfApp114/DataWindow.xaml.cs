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
using System.Windows.Shapes;
using WpfApp114.Models;
using NetworkHelper;

namespace WpfApp114
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        List<Movie> movies = new List<Movie>();
        public DataWindow()
        {
            InitializeComponent();
            this.Closing += DataWindow_Closing;

            string url = "https://nodejs111.dszcbaross.edu.hu/api/movie";
            movies = Backend.GET(url).Send().As<List<Movie>>();

            lista.ItemsSource = movies;
            lista.DisplayMemberPath = "Title";

            mufaj.ItemsSource = movies.Select(x => x.Genre)
                .Distinct().ToList().Prepend("Összes");
            mufaj.SelectedIndex = 0;

            korhatar.ItemsSource = movies.Select(x => x.AgeRating.ToString())
                .Distinct().ToList().Prepend("Összes");
            korhatar.SelectedIndex = 0;

            gomb.Click += Gomb_Click;

            lista.SelectionChanged += Lista_SelectionChanged;
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Movie kivalasztottFilm = lista.SelectedItem as Movie;

            MovieWindow mw = new MovieWindow();
            mw.Owner = this;
            mw.kep.Source = 
                new BitmapImage(new Uri(kivalasztottFilm.Image, UriKind.Absolute));
            mw.cim.Text = kivalasztottFilm.Title;
            mw.mufaj.Text = kivalasztottFilm.Genre;
            mw.korhatar.Source = 
                new BitmapImage(new Uri($"./Images/{kivalasztottFilm.AgeRating}.png", UriKind.Relative));
            mw.Show();
            
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            List<Movie> filteredList = new List<Movie>(movies);
            string mufajErtek = mufaj.SelectedItem as string;
            string korhatarErtek = korhatar.SelectedItem as string;
            string cimErtek = cim.Text;
            if (mufajErtek!="Összes")
            {
                filteredList = filteredList
                    .Where(x => x.Genre == mufajErtek).ToList();
            }
            if (korhatarErtek!="Összes")
            {
                filteredList = filteredList
                    .Where(x => x.AgeRating == Convert.ToInt32(korhatarErtek))
                    .ToList();
            }
            if (cimErtek.Trim()!="")
            {
                filteredList = filteredList
                    .Where(x => x.Title.ToLower().Contains(cimErtek.ToLower()))
                    .ToList();
            }

            lista.ItemsSource = filteredList;
        }

        private void DataWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
