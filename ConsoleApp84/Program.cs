using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp84
{
    enum Kategoriak
    {
        Ora, Cipo
    }
    class Termek
    {
        public int Ar { get; set; }
        public int Id { get; set; }
        public Kategoriak Kategoria { get; set; }
        public bool Kedvezmeny =>Kategoria==Kategoriak.Ora;
        public int Keszlet { get; set; }
        public string Nev { get; set; }

        public override string ToString()
        {
            return $"{Ar} {Id} {Kategoria} {Kedvezmeny} {Keszlet} {Nev}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Termek> termekek = new List<Termek>()
            {
                new Termek()
                {
                    Id=1,
                    Ar=500_000,
                    Kategoria=Kategoriak.Ora,
                    Nev="Rolex Submariner",
                    Keszlet=10,
                },
                //new Termek
            };

            // Mennyi kedvezményes termék van?
            int db = termekek.Where(x => x.Kedvezmeny == true).Count();
            Console.WriteLine(db);

            // Amennyiben a kedvezményes termékekre 10%-ot ad Dominik, mennyibe kerül
            // a legdrágább óra kedvezménnyel?
            Termek legdragabbOra = termekek.Where(x => x.Kedvezmeny == true).OrderBy(x => x.Ar).Last();
            Console.WriteLine(legdragabbOra.Ar * 0.9);

            // Van olyan terméke, amely jelenleg nincs készleten?
            bool van= termekek.Exists(x => x.Keszlet == 0);
            Console.WriteLine(van?"van":"nincs");

            // Melyik termékből van a legtöbb készleten?
            Termek legtobb= termekek.OrderBy(x => x.Keszlet).Last();
            Console.WriteLine(legtobb);

            // Listázd ki az összes cipőt ár szerint növekvő sorrendben.
            termekek.Where(x => x.Kategoria == Kategoriak.Cipo).OrderBy(x => x.Ar)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Van olyan terméke, amelynek a nevében benne van az “Air”?
            bool igen= termekek.Exists(x => x.Nev.Contains("Air"));
            Console.WriteLine(igen?"igen":"nem");

            Console.ReadKey();
        }
    }
}
