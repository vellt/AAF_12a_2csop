using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp54
{
    enum KedvencHelyek { RegiKastely, Temeto, ElhagyatottHaz, Erdo, Alagut }
    enum SzellemFajtak { Kisertet, Kopogoszellem, Arnyek, Demonszellem, Koborlelek }
    class Szellem
    {
        public bool Artalmatlan => Fajta == SzellemFajtak.Koborlelek || Fajta == SzellemFajtak.Kisertet;
        public SzellemFajtak Fajta { get; set; }
        public bool Felelmetes => Fajta == SzellemFajtak.Kopogoszellem || Fajta == SzellemFajtak.Arnyek;
        public DateTime HalalIdopont { get; set; }
        public int Id { get; set; }
        public KedvencHelyek KedvencHely { get; set; }
        public string Nev { get; set; }
        public bool Veszelyes => Fajta == SzellemFajtak.Demonszellem;

        public override string ToString()
        {
            return  $"{Artalmatlan} {Fajta} {Felelmetes} {HalalIdopont.ToShortDateString()} " +
                $"{Id} {KedvencHely} {Nev} {Veszelyes}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Szellem> szellemek = new List<Szellem>()
            {
                new Szellem()
                {
                    Id=1,
                    Fajta=SzellemFajtak.Arnyek,
                    HalalIdopont=new DateTime(1960,10,20),
                    KedvencHely=KedvencHelyek.Alagut,
                    Nev="Michael Jackson",
                },
                new Szellem()
                {
                    Id=2,
                    Fajta=SzellemFajtak.Demonszellem,
                    HalalIdopont=new DateTime(1650,10,20),
                    KedvencHely=KedvencHelyek.Temeto,
                    Nev="Tojás Tóbi",
                },
                new Szellem()
                {
                    Id=3,
                    Fajta=SzellemFajtak.Kopogoszellem,
                    HalalIdopont=new DateTime(2020,10,20),
                    KedvencHely=KedvencHelyek.Erdo,
                    Nev="Leonel Messi",
                },
                new Szellem()
                {
                    Id=4,
                    Fajta=SzellemFajtak.Kisertet,
                    HalalIdopont=new DateTime(2010,10,20),
                    KedvencHely=KedvencHelyek.Temeto,
                    Nev="Lakatos Brendon",
                },
            };

            //-az összes szellem listázva
            szellemek.ForEach(x => Console.WriteLine(x));

            //- elhalálozás szerint rendezd növekvő sorrendbe(orderBy )
            szellemek.OrderBy(x => x.HalalIdopont).ToList()
                .ForEach(x => Console.WriteLine(x));

            //-Az összes olyan szellem aki temetőben kísért(where)
            szellemek.Where(x=>x.KedvencHely==KedvencHelyek.Temeto).ToList()
                .ForEach(x => Console.WriteLine(x));

            //-van olyan szellem aki régi kastélyban kísért, de ártalmatlan ? (Exists)
            bool van = szellemek.Exists(x => x.KedvencHely == KedvencHelyek.RegiKastely && x.Artalmatlan == true);
            Console.WriteLine(van?"van":"nincs");

            //- az összes szellem darabszáma(count)
            Console.WriteLine(szellemek.Count());

            //-Az összes veszélyes és félelmetes szellem(where)
            szellemek.Where(x=>x.Veszelyes==true || x.Felelmetes==true).ToList()
                .ForEach(x => Console.WriteLine(x));

            //- A legrégebben meghalt szellem(orderBy-- > first)
            Szellem sz= szellemek.OrderBy(x => x.HalalIdopont).First();
            Console.WriteLine(sz);

            //- Az első szellem ártalmatlan szellem?
            bool artalmatlan = szellemek.First().Artalmatlan;
            Console.WriteLine(artalmatlan?"igen":"nem");

            Console.ReadKey();
        }
    }
}
