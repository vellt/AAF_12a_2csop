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

namespace WpfApp31
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            szovegBevitel.TextChanged += SzovegBevitel_TextChanged;
        }

        private void SzovegBevitel_TextChanged(object sender, TextChangedEventArgs e)
        {
            int karakterHossza = szovegBevitel.Text.Length;
            karakter.Text = karakterHossza.ToString();
        }
    }
}
