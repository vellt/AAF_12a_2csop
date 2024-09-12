```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dolgozat_vnev_knev
{
    class Program
    {
        enum Szamolj { Maganhangzokat, Massalhangzokat, Kisbetuket }
        static void Main(string[] args)
        {
            string[] adatok = Feltolt();
            for (int i = 0; i < adatok.Length; i++)
            {
                string adat = adatok[i];
                if (Fizetes(adat)>300_000)
                {
                    Console.WriteLine($"Eredeti szöveg: {adat}");
                    Console.WriteLine($"Magánhangzók száma: {Szamlalo(adat,Szamolj.Maganhangzokat)} db");
                    Console.WriteLine($"Mássalhangzók száma: {Szamlalo(adat,Szamolj.Massalhangzokat)} db");
                    Console.WriteLine($"Kisbetűk száma: {Szamlalo(adat,Szamolj.Kisbetuket)} db");
                    Console.WriteLine("módosított szöveg:");
                    Console.WriteLine($"\t- transzformáció: {Modositott(adat)}");
                    Console.WriteLine($"\t- karakterhossza: {Modositott(adat).Length}");
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }

        private static string[] Feltolt()
        {
            return File.ReadAllLines("berek.txt");
        }

        private static int Szamlalo(string szoveg, Szamolj szamolj)
        {
            int db = 0;
            for (int i = 0; i < szoveg.Length; i++)
            {
                char karakter = szoveg[i];
                switch (szamolj)
                {
                    case Szamolj.Maganhangzokat:
                        if (
                            karakter=='a' || 
                            karakter=='A' ||
                            karakter=='e' ||
                            karakter=='E' ||
                            karakter=='i' ||
                            karakter=='I' ||
                            karakter=='u' ||
                            karakter=='U' ||
                            karakter=='o' ||
                            karakter=='O' )
                        {
                            db++;
                        }
                        break;
                    case Szamolj.Massalhangzokat:
                        if (!(
                            karakter == 'a' ||
                            karakter == 'A' ||
                            karakter == 'e' ||
                            karakter == 'E' ||
                            karakter == 'i' ||
                            karakter == 'I' ||
                            karakter == 'u' ||
                            karakter == 'U' ||
                            karakter == 'o' ||
                            karakter == 'O' ||
                            karakter == ' ' ||
                            karakter>='0' && karakter<='9'))
                        {
                            db++;
                        }
                        break;
                    case Szamolj.Kisbetuket:
                        if (karakter>='a' && karakter<='z')
                        {
                            db++;
                        }
                        break;
                }
            }
            return db;
        }

        private static string Modositott(string szoveg)
        {
            string ujSzoveg="|";
            for (int i = szoveg.Length - 1; i >= 0; i--)
            {
                char karakter = szoveg[i];
                if (!(karakter>='A' && karakter <='Z' || karakter==' '))
                {
                    if(karakter>='a' && karakter <= 'z')
                    {
                        ujSzoveg += (char)(karakter - 32);
                    }
                    else
                    {
                        // számok
                        ujSzoveg += karakter;
                    }
                    ujSzoveg += '|';
                }
            }
            return ujSzoveg;
        }

        private static int Fizetes(string szoveg)
        {
            string forditott = "";
            for (int i = szoveg.Length - 1; szoveg[i]!=' '; i--)
            {
                char karakter = szoveg[i];
                forditott += karakter;
            }

            string visszaforditott = "";
            for (int i = forditott.Length - 1; i >= 0; i--)
            {
                visszaforditott += forditott[i];
            }

            return Convert.ToInt32(visszaforditott);
        }
    }
}

```