using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    enum Nemek {Fiu, Lany }
    enum Szinek {Lila, Voros, Szurke, Fekete, Feher }
    class Cica
    {
        public int Id { get; set; }
        public string Neve { get; set; }
        public Nemek Neme { get; set; }
        public int Sulya { get; set; }
        public Szinek Szine { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public int Kor => DateTime.Now.Year - SzuletesiDatum.Year;

        public override string ToString()
        {
            return $"{Id,-5}{Neve,-15}{Neme,-5}{Sulya,-5}{Szine,-10}{SzuletesiDatum.ToString("yyy.MM.dd"),-15}{Kor}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Cica> cicak = new List<Cica>()
            {
                new Cica()
                {
                    Id=1,
                    Neme=Nemek.Fiu,
                    Neve="Megatron",
                    Sulya=20,
                    Szine=Szinek.Fekete,
                    SzuletesiDatum=new DateTime(1756,12,31),
                },
                new Cica()
                {
                    Id=2,
                    Neme=Nemek.Lany,
                    Neve="Radiátor",
                    Sulya=4,
                    Szine=Szinek.Voros,
                    SzuletesiDatum=new DateTime(2004,01,01),
                },
                new Cica()
                {
                    Id=3,
                    Neme=Nemek.Fiu,
                    Neve="Paplan",
                    Sulya=6,
                    Szine=Szinek.Fekete,
                    SzuletesiDatum=new DateTime(2012,01,01),
                },
                new Cica()
                {
                    Id=4,
                    Neme=Nemek.Fiu,
                    Neve="Cikk-cakk",
                    Sulya=10,
                    Szine=Szinek.Feher,
                    SzuletesiDatum=new DateTime(2021,12,20),
                },
            };

            Cica elsoCica= cicak.First();
            Console.WriteLine(elsoCica);

            Cica utolsoCica = cicak.Last();
            Console.WriteLine(utolsoCica);

            // 3-as id-ju cica
            Cica harmadikCica= cicak.Where(x => x.Id == 3).First();
            Console.WriteLine(harmadikCica);

            // össz súlya a cicáknak
            int osszSuly= cicak.Sum(x => x.Sulya);
            Console.WriteLine(osszSuly);

            // átlag életkoruk a cicáknak
            double atlag= cicak.Average(x => x.Kor);
            Console.WriteLine(Math.Round(atlag,2));

            // hány éves a legfiatalabb cicánk
            int legfiatalabbCica= cicak.Min(x => x.Kor);
            Console.WriteLine(legfiatalabbCica);

            // legvéznább cica
            int legveznabbCica = cicak.Min(x => x.Sulya);
            Console.WriteLine($"legvéznább cica súlya: {legveznabbCica} kg");

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            // 3 évnél idősebb cicák
            List<Cica> haromEvnelIdosebbek= cicak.Where(x => x.Kor >= 3).ToList();
            haromEvnelIdosebbek.ForEach(x => Console.WriteLine(x));

            // VAN-e 6 kilós cica
            int db = cicak.Count(x => x.Sulya == 6);
            bool van1 = db > 0;
            Console.WriteLine(van1 ? "van" : "nincs");

            bool van2 = cicak.Any(x => x.Sulya == 6);
            Console.WriteLine(van2 ? "van" : "nincs");

            bool van3 = cicak.Exists(x => x.Sulya == 6);
            Console.WriteLine(van3 ? "van" : "nincs");

            // a legkövérebb macska
            int legDagibb = cicak.Max(x => x.Sulya);
            Console.WriteLine(legDagibb);
            // legfiatalabb cica
            int legfiatalabb = cicak.Min(x => x.Kor);
            Console.WriteLine(legfiatalabb);
            // mennyi cica van
            int dsa = cicak.Count();
            Console.WriteLine(dsa);
            // a legnehezebb lány cica
            int legnehezebbLanyCica = cicak.Where(x => x.Neme == Nemek.Lany)
                .Max(x => x.Sulya);
            Console.WriteLine(legnehezebbLanyCica);
            // összes lány cica neve
            cicak.Where(x => x.Neme == Nemek.Lany)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Neve));
            // legidősebb fiú cica
            // 4kgtól nehezebb cicák
            // összesen hány lány cica van

           

            Console.ReadKey();
        }
    }
}
