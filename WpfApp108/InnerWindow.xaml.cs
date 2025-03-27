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
using System.IO;
using WpfApp108.Models;
using NetworkHelper;

namespace WpfApp108
{
    /// <summary>
    /// Interaction logic for InnerWindow.xaml
    /// </summary>
    public partial class InnerWindow : Window
    {
        public InnerWindow(bool isOffline)
        {
            InitializeComponent();
            this.Closing += InnerWindow_Closing;
            if (isOffline == true)
            {
                //id;name;age;gender;fur_length;image_path
                lista.ItemsSource = File.ReadAllLines("macskak.csv")
                    .Skip(1)
                    .Select(x => x.Split(';'))
                    .Select(x => new Cica()
                    {
                        Id = Convert.ToInt32(x[0]),
                        Name = x[1],
                        Age = Convert.ToInt32(x[2]),
                        Gender = x[3],
                        FurLenght = x[4],
                        ImagePath = x[5]
                    }).ToList();
                lista.DisplayMemberPath = "Name";
            }
            else
            {
                lista.ItemsSource = Backend.GET("https://nodejs109.dszcbaross.edu.hu/cats")
                    .Send().As<List<Cica>>();
            }
            lista.SelectionChanged += Lista_SelectionChanged;
        }

        private void Lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cica kivalasztottcica = lista.SelectedItem as Cica;

            nev.Text = kivalasztottcica.Name;
            kor.Text = $"Kor: {kivalasztottcica.Age}";
            szorhossz.Text = $"szorhossz: {kivalasztottcica.FurLenght}";
            nem.Text = $"neme: {kivalasztottcica.Gender}";
            kep.Source = new BitmapImage(new Uri($"./Images/{kivalasztottcica.ImagePath}", UriKind.Relative));

        }

        private void InnerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
