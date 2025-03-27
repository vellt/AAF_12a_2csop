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

namespace WpfApp108
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Offline.Click += Offline_Click;
            Online.Click += Online_Click;
        }

        private void Online_Click(object sender, RoutedEventArgs e)
        {
            InnerWindow iw = new InnerWindow(false);
            iw.Title = "Online";
            iw.Show();
            this.Close();
        }

        private void Offline_Click(object sender, RoutedEventArgs e)
        {
            InnerWindow iw = new InnerWindow(true);
            iw.Title = "Offline";
            iw.Show();
            this.Close();
        }
    }
}
