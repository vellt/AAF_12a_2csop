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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        class Varos
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            List<Varos> varosok = new List<Varos>()
            {
                new Varos() { Name="Berlin",  Value= "Berlin" },
                new Varos() { Name="Tokió",  Value= "Tokyo" },
                new Varos() { Name="Rio",  Value= "Rio" },
                new Varos() { Name="Nairobi",  Value= "Nairobi" },
                new Varos() { Name="Lisszabon",  Value= "Lisbon" },
                new Varos() { Name="Moszkva",  Value= "Moscow" },
                new Varos() { Name="Denver",  Value= "Denver" },
                new Varos() { Name="Stockholm",  Value= "Stockholm" },
                new Varos() { Name="Helsinki",  Value= "Helsinki" },
                new Varos() { Name="Professzor",  Value= "Professor" },
            };

            valaszto.ItemsSource = varosok;
            valaszto.DisplayMemberPath = "Name";
            valaszto.SelectedIndex = 0;

            valaszto.SelectionChanged += Valaszto_SelectionChanged;

        }

        private void Valaszto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Varos kivalasztottVaros = valaszto.SelectedItem as Varos;
            varosNeve.Text = kivalasztottVaros.Name;

            Image img = new Image();
            img.Height =200;
            img.Source = new BitmapImage(new Uri($"kepek/{kivalasztottVaros.Value}.jpg", UriKind.Relative));

            kepTarolo.Children.Clear();
            kepTarolo.Children.Add(img);

        }
    }
}
