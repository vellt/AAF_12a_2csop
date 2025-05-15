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
using WpfApp125.Models;

namespace WpfApp125
{
    /// <summary>
    /// Interaction logic for SzereplokWindow.xaml
    /// </summary>
    public partial class SzereplokWindow : Window
    {
        List<Szereplo> szereplok = new List<Szereplo>();
        public SzereplokWindow()
        {
            InitializeComponent();
            this.Closing += DetailsWindow_Closing;
            szereplok = Backend.GET("https://akabab.github.io/starwars-api/api/all.json")
                .Send().As<List<Szereplo>>();
            lista.ItemsSource = szereplok;
            lista.DisplayMemberPath = "Name";
        }

        private void DetailsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
