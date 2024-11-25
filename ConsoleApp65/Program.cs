using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp65
{
    enum Markak {BMW, Audi, Volkswagen, Skoda, Suzuki }
    enum Uzemanyagok { Benzin, Dizel, Elektromos, Hibrid}
    class Auto
    {
        public int GyartasiEv { get; set; }
        public int Id { get; set; }
        public int Kor => DateTime.Now.Year - GyartasiEv;
        public Markak Marka { get; set; }
        public string Rendszam { get; set; }
        public bool UjRendszam => Rendszam.Length != 7;
        public Uzemanyagok Uzemanyag { get; set; }

        public override string ToString()
        {
            return $"{Id} {GyartasiEv} {Kor} {Marka} {Rendszam} {UjRendszam} {Uzemanyag}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>()
            {
                new Auto()
                {
                    Id=1,
                    GyartasiEv=2020,
                    Marka= Markak.Audi,
                    Rendszam= "AAA-123",
                    Uzemanyag=Uzemanyagok.Dizel,
                },
                new Auto()
                {
                    Id=2,
                    GyartasiEv=2004,
                    Marka=Markak.Skoda,
                    Rendszam="AAA-111",
                    Uzemanyag=Uzemanyagok.Benzin,
                },
                new Auto()
                {
                    Id=3,
                    GyartasiEv=2018,
                    Marka=Markak.BMW,
                    Rendszam="ABC-187",
                    Uzemanyag=Uzemanyagok.Elektromos
                },
                new Auto()
                {
                    Id=4,
                    GyartasiEv=2009,
                    Marka=Markak.Volkswagen,
                    Rendszam="ABB-122",
                    Uzemanyag=Uzemanyagok.Hibrid
                }
            };

            // első autó
            Auto elso= autok.First();
            Console.WriteLine(elso);

            // első újrendszámos autó
            Auto elsoUj= autok.Where(x => x.UjRendszam).First();
            Console.WriteLine(elsoUj);

            // első elektromos autó
            Auto elsoElektromos=  autok.Where(x => x.Uzemanyag == Uzemanyagok.Elektromos).First();
            Console.WriteLine(elsoElektromos);

            // utolsó autó
            Auto utolsoAuto = autok.Last();
            Console.WriteLine(utolsoAuto);

            // utolsó Audi
            Auto utolsoAudi = autok.Where(x => x.Marka == Markak.Audi).Last();
            Console.WriteLine(utolsoAudi);

            // hány évesek átlagosan az autók
            double atlag =  autok.Average(x => x.Kor);
            Console.WriteLine(Math.Round(atlag,2));

            //Mennyi a legidősebb autó?
            Auto legidosebbAuto = autok.OrderBy(x => x.Kor).Last();
            Console.WriteLine(legidosebbAuto);

            //Mikor gyártották a legidosebb autot?
            Console.WriteLine(legidosebbAuto.GyartasiEv);

            // Összes újrendszámos auto
            autok.Where(x => x.UjRendszam == true).ToList().ForEach(x => Console.WriteLine(x));

            //Összes benzines
            autok.Where(x => x.Uzemanyag == Uzemanyagok.Benzin).ToList().ForEach(x => Console.WriteLine(x));

            //összes bmw ami benzines
            autok.Where(x => x.Marka == Markak.BMW && x.Uzemanyag == Uzemanyagok.Benzin).ToList()
                .ForEach(x => Console.WriteLine(x));

            //az öszes 2007nél ujabb model
            autok.Where(x => x.GyartasiEv > 2007).ToList().ForEach(x=> Console.WriteLine(x));
            
            //elso auto 5 evnel idosebb
            Auto ElsoIdosAuto= autok.Where(x => x.Kor > 5).First();
            Console.WriteLine(ElsoIdosAuto);

            // hány elektromos auto a listába
            int db = autok.Where(x => x.Uzemanyag == Uzemanyagok.Elektromos).Count();
            Console.WriteLine(db);

            // létezik-e 2010  előtti
            bool letezik = autok.Exists(x => x.GyartasiEv < 2010);
            Console.WriteLine(letezik);

            //2015 után gyártott autók rendszám szerint rendezve
            autok.Where(x => x.GyartasiEv > 2015).OrderBy(x => x.Rendszam).ToList()
                .ForEach(x => Console.WriteLine(x));

            //utolso benzines auto
            Auto utolsobenzines = autok.Where(x => x.Uzemanyag == Uzemanyagok.Benzin).Last();
            Console.WriteLine(utolsobenzines);

            //Hány új rendszámos auto van a listában
            int db2 =autok.Where(x => x.UjRendszam==true).Count();
            Console.WriteLine(db2);

            //5 legfiatalabb autó a listából, növekő
            autok.OrderBy(x => x.Kor).Take(5).ToList().ForEach(x => Console.WriteLine(x));

            //Az összes 2000 és 2010 közötti autó gyártási év szerint rendezve
            autok.Where(x => x.GyartasiEv >= 2000 && x.GyartasiEv <= 2010).OrderBy(x => x.GyartasiEv)
                .ToList().ForEach(x => Console.WriteLine(x));

            //hany olyan auto van amely nem benzines
            int db3 = autok.Count(x => x.Uzemanyag != Uzemanyagok.Benzin);
            Console.WriteLine(db3);

            //van e olyan auto aminek a rendszama AAAA-123
            bool van=autok.Exists(x => x.Rendszam == "AAAA-123");
            Console.WriteLine(van);

            //hány aut készült 2020 után
            int db4 = autok.Where(x => x.GyartasiEv > 2020).Count();
            Console.WriteLine(db4);

            //auto amiben van 123 rendszámban
            autok.Where(x => x.Rendszam.Contains("123")).ToList().ForEach(x => Console.WriteLine(x));

            // összes auto amelyik audi vagy bmw
            autok.Where(x => x.Marka == Markak.Audi || x.Marka == Markak.BMW).ToList()
                .ForEach(x => Console.WriteLine(x));

            // letezik e pontosan harom eves auto
            bool letezikEHaromEves = autok.Exists(x => x.Kor == 3);
            Console.WriteLine(letezikEHaromEves);

            //hány autó készült 2000 előtt?
            int db5 = autok.Where(x => x.GyartasiEv < 2000).Count();
            Console.WriteLine(db5);

            //hany olyan auto van amineka rendszama "B"vel kezdodik
            int db6 = autok.Where(x => x.Rendszam.StartsWith("B")).Count();
            Console.WriteLine(db6);

            // páros gyártási év számú autókból az első
            Auto paros= autok.Where(x => x.GyartasiEv % 2 == 0).First();
            Console.WriteLine(paros);

            // autók száma, gyártási év páratlan
            int db7= autok.Where(x => x.GyartasiEv % 2 != 0).Count();
            Console.WriteLine(db7);

            Console.ReadKey();
        }
    }
}
