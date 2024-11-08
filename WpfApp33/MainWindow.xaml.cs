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

namespace WpfApp33
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // csak a gomboknak van dedikált click eseményük, 
            // ha más elemenek szeretnénk click eseményszerűséget 
            // rendelni, használjunk a MauseUp eseményt!
            le.Click += Le_Click; 
            fel.Click += Fel_Click;
        }

        private void Fel_Click(object sender, RoutedEventArgs e)
        {
            int jelenlegiSzam = Convert.ToInt32(szam.Text);
            jelenlegiSzam++; // növeltem az értékét
            szam.Text = jelenlegiSzam.ToString();
        }

        private void Le_Click(object sender, RoutedEventArgs e)
        {
            int jelenlegiSzam = Convert.ToInt32(szam.Text);
            jelenlegiSzam--; // csökkentettem az értékét
            szam.Text = jelenlegiSzam.ToString();
        }
    }
}
