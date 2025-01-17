using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace WpfApp72
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Tick();
        }

        private async void Tick()
        {

            while (true)
            {
                await Task.Delay(1000);

                // lekérjük a pontos időt, amiket 2 tizdes pontosan mentünk le
                // pl ha 7 óra van azt 07-nek mentjük le.
                string ora=DateTime.Now.Hour.ToString("00");
                string perc=DateTime.Now.Minute.ToString("00");
                string masodperc=DateTime.Now.Second.ToString("00");

                // kijelezzük a program alján decimálisan is az időt
                hourFirst.Text = ora[0].ToString();
                hourSecond.Text = ora[1].ToString();
                minuteFirst.Text = perc[0].ToString();
                minuteSecond.Text = perc[1].ToString();
                secFirst.Text = masodperc[0].ToString();
                secSecond.Text = masodperc[1].ToString();

                // bin debugban keresi a zenét, ha nem találja le fog állni a program
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "putty.wav";
                player.Play();

                // dec to bin
                // az óra tizes helyiértékét átalakítjuk 10-esből 2-es számrendszerbe, pl
                // 7 --> 0111, viszont a c# elé tesz két db 1-est--> 110111
                // de nekünk úgyis mindig ennek a stringnek a 2,3,4,5. indexe kell, azaz 0111
                // óra tizedes helyiérték esetében, mivel maximum 2-es érték lehet 
                // (pl 22 vagy 21 órából a 2), azaz maximum alulról a második karika
                // lesz beszinezve, az első kettőt ki is hagyjuk emiatt.
                string oraTizesBin = Convert.ToString(Convert.ToInt32(ora[0]), 2);
                // lehivatkozok egy-egy karikát anélkül, hogy nevet adtam volna neki,
                // kiindulok a this-ből, azaz a window-ból, az tartalmaz egy Gridet
                // annak vannak gyermekelemei, pl 0. 1. 2. stb.., a 0. és az 1. gyermekelemre pl nincs szükségünk
                // így azokat nem hivatkozzuk le, csak az oszlop utolsó két karikáját.
                ((this.Content as Grid).Children[2] as Ellipse).Fill = (oraTizesBin[4]=='1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[3] as Ellipse).Fill = (oraTizesBin[5]=='1') ? Brushes.Black : Brushes.LightGray;

                // itt már mindegyik karikát befogjuk
                string oraEgyesBin = Convert.ToString(Convert.ToInt32(ora[1]), 2);
                ((this.Content as Grid).Children[4] as Ellipse).Fill = (oraEgyesBin[2] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[5] as Ellipse).Fill = (oraEgyesBin[3] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[6] as Ellipse).Fill = (oraEgyesBin[4] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[7] as Ellipse).Fill = (oraEgyesBin[5] == '1') ? Brushes.Black : Brushes.LightGray;

                string percTizesBin = Convert.ToString(Convert.ToInt32(perc[0]), 2);
                ((this.Content as Grid).Children[9] as Ellipse).Fill = (percTizesBin[3] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[10] as Ellipse).Fill = (percTizesBin[4] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[11] as Ellipse).Fill = (percTizesBin[5] == '1') ? Brushes.Black : Brushes.LightGray;

                string percEgyesBin = Convert.ToString(Convert.ToInt32(perc[1]), 2);
                ((this.Content as Grid).Children[12] as Ellipse).Fill = (percEgyesBin[2] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[13] as Ellipse).Fill = (percEgyesBin[3] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[14] as Ellipse).Fill = (percEgyesBin[4] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[15] as Ellipse).Fill = (percEgyesBin[5] == '1') ? Brushes.Black : Brushes.LightGray;

                string masodpercTizesBin = Convert.ToString(Convert.ToInt32(masodperc[0]), 2);
                ((this.Content as Grid).Children[17] as Ellipse).Fill = (masodpercTizesBin[3] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[18] as Ellipse).Fill = (masodpercTizesBin[4] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[19] as Ellipse).Fill = (masodpercTizesBin[5] == '1') ? Brushes.Black : Brushes.LightGray;

                string masodpercEgyesBin = Convert.ToString(Convert.ToInt32(masodperc[1]), 2);
                ((this.Content as Grid).Children[20] as Ellipse).Fill = (masodpercEgyesBin[2] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[21] as Ellipse).Fill = (masodpercEgyesBin[3] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[22] as Ellipse).Fill = (masodpercEgyesBin[4] == '1') ? Brushes.Black : Brushes.LightGray;
                ((this.Content as Grid).Children[23] as Ellipse).Fill = (masodpercEgyesBin[5] == '1') ? Brushes.Black : Brushes.LightGray;
            }
        }
    }
}
