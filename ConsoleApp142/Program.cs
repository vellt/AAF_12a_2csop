using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp142
{
    class Etel
    {
        public int Id { get; set; }
        public string Neve { get; set; }
        public int Energia { get; set; }
        public int Szenh { get; set; }
        public int Ara { get; set; }
        public char Kategoria { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Etel> etelek = ReadData();
            // Listázzuk az árakat, CSAK az árakat, 
            // de ügyeljünk arra, hogy ne ismétlődjenek
            etelek.Select(x => x.Ara).Distinct()
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írassuk ki az összes Desszert nevét és árát
            etelek.Where(x => x.Kategoria == 'D')
                .Select(x => $"{x.Neve}: {x.Ara}Ft")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Mennyibe kerülne, ha az összes 
            // desszertből szeretnénk elfogyasztani 1 adagot
            int ossz=etelek.Where(x => x.Kategoria == 'D').Sum(x => x.Ara);
            Console.WriteLine($"{ossz}Ft");

            // Hányféle ételből választhatnak a vendégek az egyes 
            // ételkategóriákban? A listát rendezze az
            // ételek száma szerint növekvő sorrendbe!
            etelek.GroupBy(x => x.Kategoria).Select(x => new
            {
                Kategoria = x.Key,
                Darabszam = x.Count(),
            }).OrderBy(x => x.Darabszam)
            .Select(x=>$"{x.Kategoria}: {x.Darabszam}db").ToList()
            .ForEach(x => Console.WriteLine(x));

            // Legnagyobb energiatartalmú étel nevét és energiatartalmát írassuk ki.
            Etel maxEnergia = etelek.OrderByDescending(x => x.Energia).First();
            Console.WriteLine($"{maxEnergia.Neve}: {maxEnergia.Energia}");

            // Számoljuk meg mennyi (egyedi) kategória van a listában
            int ennyi= etelek.Select(x => x.Kategoria).Distinct().Count();
            Console.WriteLine(ennyi);

            // Listázzuk az 1000 ft-nál drágább ételeket
            etelek.Where(x => x.Ara > 1000).Select(x => $"{x.Neve}: {x.Ara}FT")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Rendezzük ár szerint növekvő sorrendben az ételeket, 
            // jelenítsük meg a nevét
            etelek.OrderBy(x => x.Ara).Select(x => x.Neve)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Mennyibe kerül az összes desszert és leves össz ára?
            int ossz2= etelek.Where(x => x.Kategoria == 'D' || x.Kategoria == 'L')
                .Sum(x => x.Ara);
            Console.WriteLine(ossz2);

            // mennyi leves van?
            int db2= etelek.Where(x => x.Kategoria == 'L').Count();
            Console.WriteLine(db2);

            // Legdrágább étel az összes élelmiszer közül.
            Etel legdragabb= etelek.OrderByDescending(x => x.Ara).First();
            Console.WriteLine($"{legdragabb.Neve}: {legdragabb.Ara}Ft");

            // legdrágább leves?
            Etel legdragabbLeves= etelek.Where(x => x.Kategoria == 'L')
                .OrderByDescending(x => x.Ara)
                .First();
            Console.WriteLine($"{legdragabbLeves.Neve}: {legdragabbLeves.Ara}Ft");

            // Minden kategória legdrágább ételének a neve.
            etelek.GroupBy(x => x.Kategoria).Select(x => new
            {
                Kategoria = x.Key,
                LegdragabbEtel = x.OrderByDescending(y => y.Ara).First().Neve,
            }).Select(x => $"{x.Kategoria}: {x.LegdragabbEtel}")
            .ToList().ForEach(x => Console.WriteLine(x));

            // Listázzuk ki az alacsony energiatartalmú ételeket, 
            //melyeknek energia értékük kevesebb mint 300.
            etelek.Where(x => x.Energia < 300).Select(x => $"{x.Neve}: {x.Energia}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Határozzuk meg, hogy melyik kategóriában van a legtöbb étel, 
            // és hogy ez hány darab ételt jelent! 
            // Rendezze a kategoriákat a benne lévő ételek 
            // darabszáma szerint növekvő sorrendbe.

            var legtobbKategoria= etelek.GroupBy(x => x.Kategoria).Select(x => new
            {
                Kategoria = x.Key,
                Darabszam = x.Count()
            }).OrderByDescending(x => x.Darabszam).First();
            Console.WriteLine($"{legtobbKategoria.Kategoria}: {legtobbKategoria.Darabszam}db");

            // Készítsünk egy listát az összes desszertről, amelyek kategóriája "D", 
            // majd árak szerint csökkenő sorrendben rendezve írassuk ki!
            etelek.Where(x => x.Kategoria == 'D').OrderByDescending(x => x.Ara)
                .Select(x=>$"{x.Neve} {x.Ara} {x.Kategoria}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írassuk ki azokat az ételeket, amelyeknek a szénhidrát tartalma nem 
            // haladja meg az energia tartalmát!

            etelek.Where(x => x.Szenh <= x.Energia).Select(x => $"{x.Neve} {x.Szenh} {x.Energia}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írassuk ki egy-egy adott kategóriához tartozó ételek 
            // átlagos árát 2 tizedesre kerekítve!
            etelek.GroupBy(x => x.Kategoria).Select(x => new
            {
                Kategoria = x.Key,
                Atlagar = x.Average(y => y.Ara)
            }).Select(x => $"{x.Kategoria}: {Math.Round(x.Atlagar, 2)}")
            .ToList().ForEach(x => Console.WriteLine(x));

            // Határozzuk meg, hogy az "L" kategóriában VAN-e legalább egy étel, 
            // amelynek a szénhidrát tartalma meghaladja az 50g - ot!
            int db = etelek.Where(x => x.Kategoria == 'L' && x.Szenh > 50).Count();
            if (db > 0) Console.WriteLine("Van");
            else Console.WriteLine("Nincs");

            // VAN-e olyan kategória amelyikben van legalább 10 étel
            bool vanE10Nagyobb = etelek.GroupBy(x => x.Kategoria).Select(x => x.Count())
                .ToList().Exists(x => x >= 10);
            Console.WriteLine(vanE10Nagyobb ? "van" : "nincs");

            // Határozzuk meg azokat az ételeket, 
            // amelyeknek a neve tartalmazza a "leves" szórészletet!
            etelek.Where(x => x.Neve.ToLower().Contains("leves"))
                .Select(x => $"{x.Neve} {x.Kategoria}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Határozzuk meg azokat az ételeket, 
            //amelyeknek a neve tartalmazza a "leves" ÉS "csirke" szórészletet!
            etelek.Where(x=>x.Neve.Contains("leves") && x.Neve.Contains("csirke"))
                .Select(x => $"{x.Neve} {x.Kategoria}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Határozzuk meg azokat az ételeket, amelyeknek a neve 
            // tartalmazza a "leves" VAGY "csirke" szórészletet!
            etelek.Where(x => x.Neve.Contains("leves") || x.Neve.Contains("csirke"))
                .Select(x => $"{x.Neve} {x.Kategoria}")
                .ToList().ForEach(x => Console.WriteLine(x));
            
            //Írassuk ki az összes olyan ételt, amelynek az ára 500 forint alatt van, de energia tartalma
            //legalább 200 kcal!
            etelek.Where(x => x.Ara < 500 && x.Energia >= 200)
                .Select(x => $"{x.Neve} {x.Energia}")
                .ToList().ForEach(x => Console.WriteLine(x));

            //!DISTINCT! Mely kategóriákban vannak jelen a 
            //csirke szórészletet tartalmazó ételek?
            etelek.Where(x => x.Neve.Contains("csirke"))
                .Select(x => x.Kategoria).Distinct()
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            // Írassuk ki a levesek árait külön külön, egy egy ár egyszer szerepelhet!
            etelek.Where(x=>x.Kategoria=='L').Select(x=>x.Ara).Distinct().ToList()
                .ForEach(x => Console.WriteLine(x));

            //A leves "L" kategóriákba tartozó ételek árait rendezzük csökkenő sorrendben. Egy ár egyszer
            // szerepeljen!
            etelek.Where(x => x.Kategoria == 'L').OrderByDescending(x => x.Ara)
                .Select(x => $"{x.Ara} {x.Kategoria}").ToList()
                .ForEach(x => Console.WriteLine(x));

            // Határozzuk meg azokat az ételeket, amelyek energiatartalma a 
            // szénhidráttartalmának legalább kétszerese!
            etelek.Where(x => x.Energia  >= x.Szenh*2)
                .Select(x => $"{x.Neve} {x.Szenh} {x.Energia}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írassuk ki azokat az ételeket, 
            //amelyek energiatartalma meghaladja az átlagos energiatartalmat.
            double atlag = etelek.Select(x => x.Energia).Sum() / 
                Convert.ToDouble(etelek.Count());
            etelek.Where(x => atlag < x.Energia).Select(x => $"{x.Neve} {x.Ara}")
                .ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine(atlag);

            // Határozzuk meg, hogy melyik ételkategóriában van a 
            // legtöbb 200 alatti energiatartalmú étel, és
            // ez hány darab ételt jelent!
            var elso = etelek.Where(x => x.Energia < 200).GroupBy(x => x.Kategoria)
                .Select(x => new
                {
                    Kategoria = x.Key,
                    Darabszam = x.Count()
                }).OrderByDescending(x => x.Darabszam).First();
            Console.WriteLine($"{elso.Kategoria}: {elso.Darabszam} db");

            // Mennyibe kerülne az összes leves és desszert?
            int levesEsDesszertAr = etelek.Where(x => x.Kategoria == 'L' || x.Kategoria == 'D')
                .Sum(x => x.Ara);
            Console.WriteLine(levesEsDesszertAr);
            Console.ReadKey();
        }

        static List<Etel> ReadData()
        {
            return File.ReadAllLines("etlap.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Etel()
                {
                    Id = Convert.ToInt32(x[0]),
                    Neve = x[1],
                    Energia = Convert.ToInt32(x[2]),
                    Szenh = Convert.ToInt32(x[3]),
                    Ara = Convert.ToInt32(x[4]),
                    Kategoria = Convert.ToChar(x[5]),
                }).ToList();
        }
    }
}
