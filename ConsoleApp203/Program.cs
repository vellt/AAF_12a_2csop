using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // Annotációk miatt
using NetworkHelper; // GET-es hívást indítani!

namespace ConsoleApp203
{
    class Sutemeny
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
        [JsonProperty("original_price")]
        public int OriginalPrice { get; set; }
        [JsonProperty("discount")]
        public string Discount { get; set; }
        [JsonProperty("weight")]
        public string Weight { get; set; }
        [JsonProperty("price_per_kg")]
        public string PricePerKg { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }

        public int Gramm()
        {
            string gNelkuli = Weight.Replace("g", ""); // "50g"-->"50"
            int szam = Convert.ToInt32(gNelkuli); // "50"-->50
            return szam;
        }

        public int Kedvezmeny()
        {
            if (Discount != null) // akcios
            {
                string szazalekSzoveg = Discount.Split('%')[0];
                return Convert.ToInt32(szazalekSzoveg);
            }
            else
            {
                return 0; // nincs kedvezmény
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://nodejs111.dszcbaross.edu.hu/api/bakery";
            List<Sutemeny> sutemenyek = Backend.GET(url)
                .Send()
                .As<List<Sutemeny>>();

            // Mennyi akciós termék van?
            int db = sutemenyek.Where(x => x.Discount != null).Count();
            Console.WriteLine(db);

            // mennyi 200 és 300 forint közötti termék van
            int db2 = sutemenyek.Where(x => x.Price >= 200 && x.Price <= 300).Count();

            // Listázd ki az összes 90 gramm alatti terméket
            sutemenyek.Where(x => x.Gramm() < 90).ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Weight}"));

            // Van a termékek között olyan, aminek a nevében szerepel a „kakaó”
            bool van = sutemenyek.Exists(x => x.Name.Contains("kakaó")); // Any
            Console.WriteLine(van ? "van" : "nincs");

            // Számold meg a páratlan súlyú termékeket
            // páratlan: n % 2 != 0
            // páros: n % 2 == 0
            int db3 = sutemenyek.Where(x => x.Gramm() % 2 != 0).Count();
            Console.WriteLine(db3);

            // Rendezd a termékeket ár szerint csökkenő sorrendbe.
            sutemenyek.OrderByDescending(x => x.Price).ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Price}"));

            // Rendezd a termékeket a nevük hossza szerint csökkenő sorrendbe.
            sutemenyek.OrderByDescending(x => x.Name.Length).ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Name.Length}"));

            //Melyik termék a legdrágább
            Sutemeny legdragabbtermek = sutemenyek
                .OrderByDescending(x => x.Price).First();
            Console.WriteLine($"{legdragabbtermek.Name} {legdragabbtermek.Price}");

            // Melyik a legolcsóbb termék?
            Sutemeny asd = sutemenyek
                .OrderByDescending(x => x.Price).Last();
            Console.WriteLine($"{asd.Name} {asd.Price}");

            // Melyik a top 3 legdrágább termék?
            sutemenyek.OrderByDescending(x => x.Price).Take(3).ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Price}"));

            //Melyik a top 3 legdrágább étel 50 és 100 gramm között?
            sutemenyek.Where(x => x.Gramm() >= 50 && x.Gramm() <= 100)
                .OrderByDescending(x => x.Price).Take(3).ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Price}"));

            // Mennyit kellene fizetnem, ha mindegyikből vennék egyet?
            int osszAr = sutemenyek.Sum(x => x.Price);
            Console.WriteLine(osszAr);

            // Mennyit kellene fizetnem, ha mindegyikből vennék 5-öt?
            int osszAr5 = sutemenyek.Sum(x => x.Price*5);
            Console.WriteLine(osszAr5);

            // Mennyit kellene fizetnem, ha a top 5 legdrágább 
            // termékből vennék egyet-egyet?
            int top5Ar= sutemenyek.OrderByDescending(x => x.Price)
                .Take(5).Sum(x => x.Price);
            Console.WriteLine(top5Ar);

            // Kérj be egy terméknevet (pl fánk, pogácsa) és listázd 
            // azon termékeket, melyek nevében szerepel a bekért szórészlet.
            Console.Write("terméknév: ");
            string szoveg = Console.ReadLine();

            sutemenyek.Where(x => x.Name.ToLower().Contains(szoveg.ToLower()))
                .ToList().ForEach(x => Console.WriteLine(x.Name));

            // Hány karakterhosszú a leghosszabb nevű termék?
            int hossz = sutemenyek.OrderByDescending(x => x.Name.Length)
                .First().Name.Length;
            Console.WriteLine(hossz);

            int hossz2 = sutemenyek.Max(x => x.Name.Length);
            Console.WriteLine(hossz2);

            // Hány % a legnagyobb kedvezmény?
            int maxKedvezmeny = sutemenyek.Max(x => x.Kedvezmeny());
            Console.WriteLine(maxKedvezmeny);




            Console.ReadKey();
        }
    }
}
