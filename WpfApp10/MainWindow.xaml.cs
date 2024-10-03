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

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            osszeadas.Click += Osszeadas_Click;
        }

        private void Osszeadas_Click(object sender, RoutedEventArgs e)
        {
            int sz1 = szam1.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(szam1.Text);
            int sz2 = szam2.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(szam2.Text);
            int eredmeny = sz1 + sz2;
            MessageBox.Show($"Összegük: {eredmeny}");
        }
    }
}
