using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    enum Italok { Viz, Kola, Narancs, Limonade}
    class Palack
    {
        public int Id { get; set; }
        public double KiszerelesLiter { get; set; }
        // ennek nincs set tulajdonsága a => csak get-et enged
        public bool KupakRogzitveVan => PalackozasIdeje.Year >= 2023;
        public DateTime PalackozasIdeje { get; set; }
        public Italok Tartalom { get; set; }
        // ennek nincs set tulajdonsága a => csak get-et enged
        public bool Visszavalthato => PalackozasIdeje.Year >= 2024;

        // ezt azért kell átírni, mert a WriteLine meghívja a ToString-et, de az az objektumot alapértelmezetten
        // nem tudja megjeleníteni, hiszen rengeteg tulajdonsága van. ezzel megtudjuk
        // mondani, milyen értékek látszódnak, esetünkben minden is látszódjon, a -5, -10 az a kiírást követően
        // annyi egység szóközt letesz, így táblázatos megjelenítésünk lesz.
        public override string ToString()
        {
            return $"{Id,-5} {KiszerelesLiter,-5} {KupakRogzitveVan,-10} {PalackozasIdeje.ToShortDateString(), -15} {Tartalom, -15} {Visszavalthato}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // a listába teszünk pár osztály példányt (objektumot)
            List<Palack> palackok = new List<Palack>()
            {
                new Palack()
                {
                    Id=1,
                    KiszerelesLiter=0.25,
                    PalackozasIdeje= new DateTime(2020,10,11),
                    Tartalom=Italok.Kola,
                },
                new Palack()
                {
                    Id=2,
                    KiszerelesLiter=1.75,
                    PalackozasIdeje= new DateTime(2023,12,03),
                    Tartalom=Italok.Viz,
                },
                new Palack()
                {
                    Id=3,
                    KiszerelesLiter=1,
                    PalackozasIdeje= new DateTime(2024,03,12),
                    Tartalom= Italok.Narancs,
                }
            };

            //első palackom
            Palack elsoPalack= palackok.First();
            Console.WriteLine(elsoPalack); // ha a ToString nem lenne override-olva az osztályon belül itt nem látszódnának a palack tulajdonságai

            //utolsó palackom
            Palack utolsoPalack= palackok.Last();
            Console.WriteLine(utolsoPalack);

            //hány literesek átlagosan a palackjaim
            double atlag= palackok.Average(x => x.KiszerelesLiter);
            Console.WriteLine(atlag);

            //Ha tele lennének a palackjaim hány liter lenne összesen?
            double osszSuly= palackok.Sum(x => x.KiszerelesLiter);
            Console.WriteLine(osszSuly);

            // Mennyi visszaválthatós palackom van.
            int visszaValtos = palackok.Count(x => x.Visszavalthato == true);
            Console.WriteLine(visszaValtos);

            // Listázd az összes olyan palackom, amelynek rögzített a kupakja.
            palackok.Where(x => x.KupakRogzitveVan == true)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }
    }
}
