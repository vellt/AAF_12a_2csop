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
            gomb.Click += Gomb_Click;
            
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            if (ker.Text.Trim().Length==0)
            {
                MessageBox.Show("*-al jelölt mezőket kötelező kitölteni!");
            }
            else
            {
                MessageBox.Show($"A nevem {ker.Text}\n{vez.Text} {ker.Text}", "007");
            }
        }
    }
}
