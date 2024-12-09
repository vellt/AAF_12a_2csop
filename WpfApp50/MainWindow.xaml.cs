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

namespace WpfApp50
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isVisible = true;
        public MainWindow()
        {

            InitializeComponent();
            this.MouseUp += MainWindow_MouseUp;
        }

        private void MainWindow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isVisible == true)
            {
                isVisible = false;
                kekKonyv.Visibility = Visibility.Collapsed; // vagy hidden
            }
            else
            {
                isVisible = true;
                kekKonyv.Visibility = Visibility.Visible;
            }

        }
    }
}
