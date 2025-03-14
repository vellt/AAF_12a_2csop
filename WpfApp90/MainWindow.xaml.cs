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

namespace WpfApp90
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            csusza.ValueChanged += Csusza_ValueChanged;
            minusz.Click += Minusz_Click;
            plusz.Click += Plusz_Click;
            szamitas.Click += Szamitas_Click;
        }

        private void Szamitas_Click(object sender, RoutedEventArgs e)
        {
            int kg = Convert.ToInt32(suly.Text);
            int cm = Convert.ToInt32(magassag.Text);
            int bodyIndex = (int)((kg / Math.Pow(cm, 2)) * 10_000);
            if (bodyIndex>=18 && bodyIndex <= 25)
            {
                //MessageBox.Show("Normál", $"body inxdex: {bodyIndex}");
                ResultWindow rw = new ResultWindow();
                rw.Index = bodyIndex;
                rw.Eredmeny = "Normál";
                rw.Show();

            } else if (bodyIndex > 25)
            {
                //MessageBox.Show("Túlsúlyos", $"body inxdex: {bodyIndex}");
                ResultWindow rw = new ResultWindow();
                rw.Index = bodyIndex;
                rw.Eredmeny = "Túlsúlyos";
                rw.Show();
            }
            else
            {
                //MessageBox.Show("Sovány", $"body inxdex: {bodyIndex}");
                ResultWindow rw = new ResultWindow();
                rw.Index = bodyIndex;
                rw.Eredmeny = "Sovány";
                rw.Show();
            }
        }

        private void Plusz_Click(object sender, RoutedEventArgs e)
        {
            int kg = Convert.ToInt32(suly.Text);
            if (kg + 1 <= 300)
            {
                suly.Text = (++kg).ToString();
            }
        }

        private void Minusz_Click(object sender, RoutedEventArgs e)
        {
            int kg = Convert.ToInt32(suly.Text);
            if (kg-1>=30)
            {
                suly.Text = (--kg).ToString();
            }
        }

        private void Csusza_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            magassag.Text = csusza.Value.ToString();
        }
    }
}
