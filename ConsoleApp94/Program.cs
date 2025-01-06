using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp94
{
    enum Mufajok { Rock, Pop, Elektronikus }
    class Album
    {
        public int Id { get; set; }
        public int MegjelenesiEve { get; set; }
        public Mufajok Mufaj { get; set; }
        public string Nev { get; set; }
        public int Kor => DateTime.Now.Year - MegjelenesiEve;
        public override string ToString()
        {
            return $"{Id} {MegjelenesiEve} {Mufaj} {Nev} {Kor}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Album> albumok = new List<Album>()
            {
                new Album
                {
                    Id=1,
                    MegjelenesiEve = 2020,
                    Mufaj = Mufajok.Elektronikus,
                    Nev = "Elefánt - Kösz"
                },
                new Album
                {
                    Id = 2,
                    MegjelenesiEve = 1999,
                    Mufaj = Mufajok.Elektronikus,
                    Nev = "Carson Coma - FELDOBOM A KÖVET"
                },
                new Album
                {
                    Id = 3,
                    MegjelenesiEve = 1999,
                    Mufaj = Mufajok.Rock,
                    Nev = "Ivan & The Parazol - Mocskos idők"
                },
                new Album
                {
                    Id = 4,
                    MegjelenesiEve = 1999,
                    Mufaj = Mufajok.Pop,
                    Nev = "Marcus King - Sucker"
                },
            };
            // Mennyi 20 évnél idősebb album van a zeneboltban?
            int idosAlbumDb = albumok.Where(x => x.Kor > 20).Count();
            Console.WriteLine(idosAlbumDb);

            // Van olyan Elektronikus műfajú album a zeneboltban, amelynek a nevében szerepel
            //“Nevermind” szó ?
            bool vanE = albumok.Exists(x => x.Mufaj == Mufajok.Elektronikus && x.Nev.Contains("Nevermind"));
            Console.WriteLine(vanE? "Igen":"Nem");

            // Listázd a boltban lévő albumokat kiadás éve szerint növekvő sorrendben.
            albumok.OrderBy(x => x.MegjelenesiEve).ToList().ForEach(x => Console.WriteLine(x));

            // Mennyi pop album van a boltban?
            int popDb = albumok.Where(x => x.Mufaj == Mufajok.Pop).Count();
            Console.WriteLine(popDb);

            // Átlagosan hány évesek az albumok?
            var atlag = albumok.Average(x => x.Kor);
            Console.WriteLine(atlag);


            // Listázd ki az első 3 legrégebbi albumot.
            albumok.OrderByDescending(x => x.Kor).Take(3).ToList().ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }
    }
}
