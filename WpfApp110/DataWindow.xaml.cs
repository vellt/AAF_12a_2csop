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
using NetworkHelper;
using WpfApp110.Models;

namespace WpfApp110
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        List<Photo> photos = new List<Photo>();
        public DataWindow()
        {
            InitializeComponent();
            Closing += DataWindow_Closing;
            photos = Backend.GET("https://picsum.photos/v2/list").Send().As<List<Photo>>();
            tabla.ItemsSource = photos;
            szerzok.ItemsSource = photos.Select(x => x.Author).Distinct().Prepend("Összes");
            szerzok.SelectedIndex = 0;
            gomb.Click += Gomb_Click;
            tabla.SelectionChanged += Tabla_SelectionChanged;
        }

        private void Tabla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabla.SelectedItem is Photo)
            {
                Photo kivalasztottPhoto = tabla.SelectedItem as Photo;

                PictureWindow pw = new PictureWindow();
                pw.kep.Source = new BitmapImage(new Uri(kivalasztottPhoto.DonwloadUrl, UriKind.Absolute));
                pw.Owner = this;
                pw.Show();
            }
            
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            string kivalasztottSzerzo = szerzok.SelectedItem as string;
            List<Photo> szurtLista = new List<Photo>(photos);

            if (kivalasztottSzerzo!="Összes")
            {
                szurtLista = szurtLista.Where(x => x.Author == kivalasztottSzerzo).ToList();
            }

            tabla.ItemsSource = szurtLista;
        }

        private void DataWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
