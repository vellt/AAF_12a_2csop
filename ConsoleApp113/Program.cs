using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp113
{
    class Hegy
    {
        public string HegycsucsNeve { get; set; }
        public string Hegyseg { get; set; }
        public int Magassag { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Hegy> hegyek = ReadDataFromFile();

            // írjuk ki a lista elemeit
            Console.WriteLine("\nfeladat -1:");
            hegyek.Select(x=>$"{x.HegycsucsNeve} {x.Hegyseg} {x.Magassag}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // mennyi sor adat volt a fájlban?
            Console.WriteLine("\nfeladat 0:");
            int db = hegyek.Count();
            Console.WriteLine( $"Ennyi adat van a fájlban: {db} db");

            // 01.) Szűrd ki azokat a hegycsúcsokat, 
            // amelyek magassága meghaladja az 900 métert a Bükk-vidéken.
            Console.WriteLine("\nfeladat 1:");
            hegyek.Where(x => x.Hegyseg == "Bükk-vidék" && x.Magassag>900)
                .Select(x => $"{x.HegycsucsNeve} {x.Magassag}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 02.) írd ki a hegységeket duplikáció nélkül
            Console.WriteLine("\nfeladat 2:");
            hegyek.Select(x => x.Hegyseg).Distinct()
                .ToList().ForEach(x => Console.WriteLine(x));

            // 03.) Számold meg, hány hegycsúcs található a Bükk-vidéken.
            Console.WriteLine("\nfeladat 3:");
            int asd = hegyek.Where(x => x.Hegyseg == "Bükk-vidék").Count();
            Console.WriteLine($"Bükk vidék hegycsúcsai: {asd} db");

            // 04.) Listázd ki a hegycsúcsokat magasság szerint csökkenő sorrendben.
            Console.WriteLine("\nfeladat 4:");
            hegyek.OrderByDescending(x => x.Magassag)
                .Select(x => $"{x.HegycsucsNeve}: {x.Magassag} méter")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 05.) Keresd meg azokat a hegycsúcsokat, amelyek nevében szerepel a "kő" szótag.
            Console.WriteLine("\nfeladat 5:");
            hegyek.Where(x => x.HegycsucsNeve.Contains("kő")).Select(x=> $"{x.HegycsucsNeve}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 06.) Listázd ki azokat a hegycsúcsokat, amelyek magassága 800 és 900 méter között 
            Console.WriteLine("\nfeladat 6:");
            hegyek.Where(x => x.Magassag > 800 && x.Magassag < 900)
                .Select(x => $"{x.HegycsucsNeve} {x.Hegyseg} {x.Magassag}")
                .ToList().ForEach(x => Console.WriteLine(x));
            
            // 07.) Melyik hegységnek mennyi hegycsúcsa van
            Console.WriteLine("\nfeladat 7:");
            hegyek.GroupBy(x => x.Hegyseg).Select(x=> $"{x.Key}: {x.Count()}db")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 08.) melyik hegységnek mennyi a legnagyobb magassága
            Console.WriteLine("\nfeladat 8:");
            hegyek.GroupBy(x => x.Hegyseg).Select(x => $"{x.Key}: {x.Max(y => y.Magassag)}")
                .ToList().ForEach(x => Console.WriteLine(x));

            // 09.) Hozz létre egy listát azokról a hegycsúcsokról, amelyek neve több, 
            // mint egyszer szerepel a listában, és mutasd meg ezeket a duplikációkat.
            Console.WriteLine("\nfeladat 9:");
            hegyek.Where(x => x.HegycsucsNeve.Contains("2"))
                .Select(x => x.HegycsucsNeve.TrimEnd("(2)".ToArray()))
                .ToList().ForEach(x => Console.WriteLine(x));

            // 10.) Kérjen be a hegység nevét és listázza a találatokat továbbá a találatok számát
            Console.Write("\nHegység név: ");
            string bekertAdat= Console.ReadLine();

           List<string> fdsa = hegyek.Where(x => x.Hegyseg == bekertAdat)
                .Select(x=>$"{x.HegycsucsNeve}: {x.Magassag} méter")
                .ToList();
            Console.WriteLine($"Találatok száma: {fdsa.Count()} db");
            fdsa.ForEach(x => Console.WriteLine(x));

            Console.ReadKey();


        }

        static List<Hegy> ReadDataFromFile()
        {
            return File.ReadAllLines("hegyek.csv")
                .Skip(1)
                .Select(x => x.Split(';'))
                .Select(x => new Hegy()
                {
                    HegycsucsNeve=x[0],
                    Hegyseg=x[1],
                    Magassag=Convert.ToInt32(x[2])
                }).ToList();
        }
    }
}
