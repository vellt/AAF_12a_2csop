using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp124
{
    class Asd
    {
        public int Ev { get; set; }
        public string Tipus { get; set; }
        public string KeresztNev { get; set; }
        public string VezetekNev { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            List<Asd> asdok = ReadDataFromFile();
            //Mennyi adatsorból áll a fájl?//
            Console.WriteLine("\n1 feladat:");
            Console.WriteLine($"Ennyi adatsorból áll: {asdok.Count()}");

            //Listázd ki az adatsorokat (minden adattagot).
            Console.WriteLine("\n2. feladat:");
            Console.WriteLine($"Az összes adat:");
            asdok.Select(x=>$"{x.Tipus} {x.Ev} {x.KeresztNev} {x.VezetekNev}")
                .ToList().ForEach(x => Console.WriteLine(x));

            //Rendezd azon Nóbel-díjasokat keresztnév szerint növekvő sorrendbe,
            //melyek 2014 után kaptak orvosi Nóbel-díjat.
            //A kiíratás Vezetéknév és Keresztnév formájában történjen. 
            Console.WriteLine("\n3. feladat:");
            asdok.OrderBy(x => x.KeresztNev)
                .Where(x => x.Ev > 2014 && x.Tipus == "orvosi")
                .Select(x => $"{x.VezetekNev} {x.KeresztNev}").ToList()
                .ForEach(x => Console.WriteLine(x));

            //Mennyi típus van (duplikációkat eltünteted, majd megszámolod)?
            Console.WriteLine("\n4. feladat:");
            int db= asdok.Select(x => x.Tipus).Distinct().Count();
            Console.WriteLine(db);

            //Listázza ki évszám szerint növekvően az 1960 és 1970 között 
            //irodalmi Nobel-díjat nyert írók nevét (vezetéknév + keresztnév). 
            // A vizsgált időszakba a határok is beletartoznak.
            Console.WriteLine("\n5. feladat:");
            asdok.OrderBy(x => x.Ev)
                .Where(x => x.Ev >= 1960 && x.Ev <= 1970 && x.Tipus == "Irodalmi")
                .Select(x => $"{x.VezetekNev} {x.KeresztNev}")
                .ToList().ForEach(x => Console.WriteLine(x));

            //Melyik típusban mennyi Nóbel-díjas van?
            Console.WriteLine("\n6. feladat:");
            asdok.GroupBy(x => x.Tipus).Select(x => $"{x.Key}: {x.Count()}db")
                .ToList().ForEach(x => Console.WriteLine(x));

            //Melyik évben mennyi Nóbel-díjas volt?
            Console.WriteLine("\n7. feladat:");
            asdok.GroupBy(x => x.Ev).Select(x => $"{x.Key}: {x.Count()}db")
                .ToList().ForEach(x => Console.WriteLine(x));

            //2015-ben mennyi Nóbel-díjas volt?
            Console.WriteLine("\n8. feladat:");
            int db2 = asdok.Where(x => x.Ev == 2015).Count();
            Console.WriteLine(db2);

            //Kérj be egy nevet és listázd azon Nóbel-díjasokat, akinek az a vezeték 
            // vagy keresztneve, amit a felhasználó adott meg konzolból, 
            // a találatok számát is írd ki.
            Console.WriteLine("\n9. feladat:");
            Console.WriteLine("név: ");
            string Nev = Console.ReadLine();
            List<Asd> talalatok = asdok.Where(x => x.KeresztNev == Nev || x.VezetekNev == Nev).ToList();
            Console.WriteLine(talalatok.Count());
            talalatok.Select(x => $"{x.VezetekNev} {x.KeresztNev}")
                .ToList().ForEach(x => Console.WriteLine(x));


            Console.ReadKey();
        }

        static List<Asd> ReadDataFromFile()
        {
            return File.ReadAllLines("nobeldijak.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Asd()
                {
                    Ev = Convert.ToInt32(x[0]),
                    Tipus = x[1],
                    KeresztNev = x[2],
                    VezetekNev = x[3]
                }).ToList();
        }
    }
}
