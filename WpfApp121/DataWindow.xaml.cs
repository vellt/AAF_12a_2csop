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
using WpfApp121.Models;
using NetworkHelper;

namespace WpfApp121
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        List<Shoe> shoes = new List<Shoe>();
        public DataWindow()
        {
            InitializeComponent();
            this.Closing += DataWindow_Closing;
            shoes = Backend.GET("https://nodejs111.dszcbaross.edu.hu/api/nike")
                .Send().As<List<Shoe>>();
            lista.ItemsSource = shoes;
            lista.DisplayMemberPath = "Title";
            kategoria.ItemsSource = shoes.Select(x => x.Category).Distinct().Prepend("Összes");
            kategoria.SelectedIndex = 0;
            gomb.Click += Gomb_Click;
            lista.SelectionChanged += Lista_SelectionChanged;
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Shoe shoe= lista.SelectedItem as Shoe;

            ProductWindow pw = new ProductWindow();
            pw.kep.Source = new BitmapImage(new Uri(shoe.Image, UriKind.Absolute));
            pw.kategoria.Text = shoe.Category;
            pw.ar.Text = shoe.Price;
            pw.cim.Text = shoe.Title;
            pw.Owner = this;
            pw.Show();
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            string kategoriaErtek = kategoria.SelectedItem as string;
            string keresoErtek = kereso.Text.Trim().ToLower();
            List<Shoe> temp = new List<Shoe>(shoes);
            if (kategoriaErtek!="Összes")
            {
                temp = temp.Where(x => x.Category == kategoriaErtek).ToList();
            }
            if (keresoErtek != "")
            {
                temp = temp.Where(x => x.Title.ToLower().Contains(keresoErtek)).ToList();
            }
            lista.ItemsSource = temp;
        }

        private void DataWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
