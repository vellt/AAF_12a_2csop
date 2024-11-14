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
using System.Windows.Threading;

namespace WpfApp37
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // vetítéshez időzítőt kell készíteni
        DispatcherTimer timer = new DispatcherTimer();
        int index = 1;
        public MainWindow()
        {
            InitializeComponent();
            elore.Click += Elore_Click;
            vissza.Click += Vissza_Click;
            vetites.Click += Vetites_Click;

            // az időzítő felkonfigurálása
            // 2 másodpercenként fog elindulni
            timer.Interval = TimeSpan.FromSeconds(2);
            // amikor 2-2 másodperc eltelik, meghívódik az eseménye
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // az előpre kattintás logikája van benne
            if (index == 5) index -= 4;
            else index++;
            kep.Source = new BitmapImage(new Uri($"0{index}.jpg", UriKind.Relative));
        }

        private void Vetites_Click(object sender, RoutedEventArgs e)
        {
            // vetítés gombra ha kattintok, és jelenleg megy az időzítő
            // azaz a vetítés, akkor azt leállítja
            if (timer.IsEnabled) timer.Stop();
            else timer.Start(); // egyébként elindítja
        }


        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            if (index==1) index += 4;
            else index--;
            kep.Source = new BitmapImage(new Uri($"0{index}.jpg", UriKind.Relative));
        }

        private void Elore_Click(object sender, RoutedEventArgs e)
        {
            if (index == 5) index -= 4;
            else index++;
            kep.Source = new BitmapImage(new Uri($"0{index}.jpg", UriKind.Relative));
        }
    }
}
