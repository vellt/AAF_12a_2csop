using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp109
{
    class Barat
    {
        public string Nev { get; set; }
        public int IranyitoSzam { get; set; }
        public string Varos { get; set; }
        public string Cim { get; set; }
        public string Telefonszam { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Nev} {IranyitoSzam} {Varos} {Cim} {Telefonszam} {Email}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Barat> baratok = ReadData();

            // feladat1 -------------------------------------------------------
            Console.WriteLine("\n feladat1: ");
            List<string> rendezettLista = baratok.OrderBy(x => x.Nev)
                .Select(x => x.ToString()).ToList();
            // konzol
            rendezettLista.ForEach(x => Console.WriteLine(x));
            // txt-be mentés
            File.WriteAllLines("feladat1.txt", rendezettLista); // csak string tömböt, vagy listát tudunk bele tenni

            // feladat2 -------------------------------------------------------
            Console.WriteLine("\n feladat2: ");
            List<string> vanTelefonszam = baratok.Where(x => x.Telefonszam != "")
                .Select(x=>$"{x.Nev} {x.Telefonszam}").ToList();
            // konzol
            vanTelefonszam.ForEach(x => Console.WriteLine(x));
            // fájl
            File.WriteAllLines("feladat2.txt", vanTelefonszam);

            /// feladat3 -------------------------------------------------------
            Console.WriteLine("\n feladat3: ");
            List<string> emailEsTelefonszam= baratok.Where(x => x.Telefonszam != "" && x.Email != "")
                .Select(x => $"{x.Nev} {x.Telefonszam} {x.Email}").ToList();
            // konzolra
            emailEsTelefonszam.ForEach(x => Console.WriteLine(x));
            // fájlba
            File.WriteAllLines("feladat3.txt", emailEsTelefonszam);

            // feladat 4 -------------------------------------------------------
            Console.WriteLine("\n feladat4: ");
            Console.Write("Írányítószám: ");
            int iranyitoszam = Convert.ToInt32(Console.ReadLine());
            List<string> talalatok = baratok.Where(x => x.IranyitoSzam == iranyitoszam)
                .Select(x=>$"- {x}").ToList();
            // konzolra
            Console.WriteLine($"Találatok száma: {talalatok.Count()} db");
            talalatok.ForEach(x => Console.WriteLine(x));
            // fájlba
            talalatok.Insert(0, $"Találatok száma: {talalatok.Count()} db");
            File.WriteAllLines("feladat4.txt", talalatok);

            // 5. feladat -------------------------------------------------------
            Console.WriteLine("\n feladat5: ");
            List<string> csoportositas = baratok.GroupBy(x => x.Varos)
                .Select(x => $"{x.Key}: {x.Count()} db").ToList();
            // konzolra
            csoportositas.ForEach(x => Console.WriteLine(x));
            // fajlba
            File.WriteAllLines("feladat5.txt", csoportositas);
            Console.ReadKey();
        }

        static List<Barat> ReadData()
        {
            return File.ReadAllLines("barat.txt")
                .Skip(1)
                .Select(x=>x.Split('\t'))
                .Select(x=>new Barat()
                {
                    Nev=x[0],
                    IranyitoSzam=Convert.ToInt32(x[1]),
                    Varos=x[2],
                    Cim=x[3],
                    Telefonszam=x[4],
                    Email=x[5]
                }).ToList();
        }
    }
}
