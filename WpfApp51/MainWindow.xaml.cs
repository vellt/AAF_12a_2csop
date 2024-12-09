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

namespace WpfApp51
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
            if (a1.Text.Trim()==""||q.Text.Trim()==""|| n.Text.Trim()=="")
            {
                MessageBox.Show("kötelező megadni a mezőket");
            }
            else
            {
                List<int> sorozatok = new List<int>();
                for (int i = 0; i < Convert.ToInt32(n.Text); i++)
                {
                    sorozatok.Add(Convert.ToInt32(a1.Text) * (int)Math.Pow(Convert.ToInt32(q.Text), i));
                }
                MessageBox.Show(string.Join(", ", sorozatok));
            }
            
        }

    }
}
