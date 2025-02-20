using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp141
{
    class Etel
    {
        public int Id { get; set; }
        public string Neve { get; set; }
        public int Enegergia { get; set; }
        public int Szenh { get; set; }
        public int Ara { get; set; }
        public char Kategoria { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Etel> etelek = ReadData();

            // Írassuk ki az ételeknek a kategória, neve, ára értékeit
            etelek.ForEach(x => Console.WriteLine($"({x.Kategoria}) {x.Neve}: {x.Ara}Ft"));

            etelek.Select(x => $"({x.Kategoria}) {x.Neve}: {x.Ara}Ft")
                .ToList().ForEach(x => Console.WriteLine(x));

            etelek.Select(x=> new // anoním osztály
            {
                Kategoria=x.Kategoria,
                Neve=x.Neve,
                Ara=x.Ara,
                Euro=x.Ara/400.0, // bővítettük
            }).Select(x=> $"({x.Kategoria}) {x.Neve}: {x.Ara}Ft/{x.Euro:0.00}Euro")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írassuk ki az ételeknek a neve és a szénhidrát értékeit
            etelek.ForEach(x => Console.WriteLine($"{x.Neve}: {x.Szenh}"));
            etelek.Select(x => $"{x.Neve}: {x.Szenh}").ToList().ForEach(x => Console.WriteLine(x));
            etelek.Select(x=> new
            {
                Neve=x.Neve,
                Szenh=x.Szenh
            }).Select(x => $"{x.Neve}: {x.Szenh}").ToList().ForEach(x => Console.WriteLine(x));

            // Írassuk ki az ételeket de csak a nevük látszódjon.
            etelek.Select(x => x.Neve).ToList().ForEach(x => Console.WriteLine(x));

            // Rendezzük az ételeket név alapján ábécé szerint növekvő sorrendben.
            etelek.Select(x => x.Neve).OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            etelek.OrderBy(x => x.Neve).ToList().ForEach(x => Console.WriteLine(x.Neve));

            // Rendezzük az ételeket név alapján ábécé szerint csökkenő sorrendben
            etelek.OrderByDescending(x => x.Neve).ToList().ForEach(x => Console.WriteLine(x.Neve));

            // Mennyi étel van a listában?
            Console.WriteLine($"{etelek.Count()}db");

            // Van aranygaluska nevű étel a listában?
            bool van = etelek.Exists(x => x.Neve.ToLower() == "aranygaluska");
            Console.WriteLine(van ? "van" : "nincs");
            /*
            if (van)
            {
                Console.WriteLine("van");
            }
            else
            {
                Console.WriteLine("nincs");
            }
            */

            // Van olyan étel a listában ami tartalmaz arany szórészletet?
            bool van2 = etelek.Exists(x => x.Neve.ToLower().Contains("arany"));
            Console.WriteLine(van2 ? "van" : "nincs");

            // Írassuk ki az első ételét a listának.
            Etel elsoEtel= etelek.First();
            Console.WriteLine($"{elsoEtel.Neve}: {elsoEtel.Ara}Ft");

            // Írassuk ki az utolsó ételét a listának.
            Etel utolsoVacsora= etelek.Last();
            Console.WriteLine($"{utolsoVacsora.Neve}: {utolsoVacsora.Ara}Ft");

            // Listázzuk azon ételeket amiknek az ára 550 forint
            etelek.Where(x => x.Ara == 550)
                .ToList().ForEach(x => Console.WriteLine($"{x.Neve}: {x.Ara}"));

            // Listázza az összes olyan ételt ami nem leves de az ára 550 forint
            etelek.Where(x=>x.Ara==550 && x.Kategoria!='L')
                .ToList().ForEach(x => Console.WriteLine($"{x.Neve}: {x.Ara}, {x.Kategoria}"));

            // Legdrágább étel megtalálása
            Etel legdragabb = etelek.OrderBy(x => x.Ara).Last();
            Console.WriteLine($"{legdragabb.Neve}: {legdragabb.Ara}Ft");

            // Legnagyobb árérték megtalálása
            int maxAr= etelek.Max(x => x.Ara);
            int maxAr2 = etelek.OrderBy(x => x.Ara).Last().Ara;
            Console.WriteLine(maxAr);

            //Írassuk ki melyik kategóriában mennyi étel van
            etelek.GroupBy(x => x.Kategoria).Select(x => new
            {
                KategoriaNeve = x.Key,
                Darabszam = x.Count()
            }).ToList().ForEach(x => Console.WriteLine($"{x.KategoriaNeve}: {x.Darabszam}db"));

            // Írassuk ki melyik kategóriában mennyi étel van, 
            // rendezze darabszám szerint csökkenő sorrendben.
            etelek.GroupBy(x => x.Kategoria).Select(x => new
            {
                KategoriaNeve = x.Key,
                Darabszam = x.Count()
            }).OrderByDescending(x=>x.Darabszam).ToList()
            .ForEach(x => Console.WriteLine($"{x.KategoriaNeve}: {x.Darabszam}db"));

            // Írassuk ki az összes kategória összárát egyesével, 
            // tehát hogy az egyes kategóriákban lévő ételek mennyibe kerülnek
            etelek.GroupBy(x => x.Kategoria).Select(x => new
            {
                KategoriaNeve = x.Key,
                Osszertek = x.Sum(y => y.Ara)
            }).ToList().ForEach(x => Console.WriteLine($"{x.KategoriaNeve}: {x.Osszertek}Ft"));

            // Listázzuk az árakat, CSAK az árakat, de ügyeljünk arra, hogy ne ismétlődjenek


            Console.ReadKey();
        }

        static List<Etel> ReadData()
        {
            return File.ReadAllLines("etlap.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Etel()
                {
                    Id=Convert.ToInt32(x[0]),
                    Neve=x[1],
                    Enegergia= Convert.ToInt32(x[2]),
                    Szenh= Convert.ToInt32(x[3]),
                    Ara= Convert.ToInt32(x[4]),
                    Kategoria= Convert.ToChar(x[5]),
                }).ToList();
        }
    }
}
