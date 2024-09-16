```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp11
{
    class Program
    {
        enum Szamolj { Sbetuket, Szamokat, Nagybetuket }
        static void Main(string[] args)
        {
            string[] adatok = Feltolt();
            for (int i = 0; i < adatok.Length; i++)
            {
                string adat = adatok[i];
                if (DomainVegzodes(adat).Length>=3)
                {
                    Console.WriteLine($"Eredeti szöveg: {adat}");
                    Console.WriteLine($"S karakterek: {Szamlalo(adat,Szamolj.Sbetuket)} db");
                    Console.WriteLine($"Szám karakterek: {Szamlalo(adat,Szamolj.Szamokat)} db");
                    Console.WriteLine($"Nagybetűs karakterek: {Szamlalo(adat,Szamolj.Nagybetuket)} db");
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
            return File.ReadAllLines("domain_nevek.txt");
        }

        private static int Szamlalo(string szoveg, Szamolj szamolj)
        {
            int db = 0;
            for (int i = 0; i < szoveg.Length; i++)
            {
                char karakter = szoveg[i];
                switch (szamolj)
                {
                    case Szamolj.Sbetuket:
                        if (karakter=='s' || karakter=='S')
                        {
                            db++;
                        }
                        break;
                    case Szamolj.Szamokat:
                        if (karakter>='0' && karakter<='9')
                        {
                            db++;
                        }
                        break;
                    case Szamolj.Nagybetuket:
                        if (karakter >= 'A' && karakter <= 'Z')
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
            string ujSzoveg = "|";
            for (int i = szoveg.Length - 1; i >= 0; i--)
            {
                char karkter = szoveg[i];
                if (!(karkter>='0' && karkter<='9' || karkter=='-' || karkter=='.'))
                {
                    if (karkter >= 'A' && karkter <= 'Z') 
                    {
                        ujSzoveg += (char)(karkter + 32);
                    }
                    else
                    {
                        ujSzoveg += karkter;
                    }
                    ujSzoveg += '|';
                }
            }
            return ujSzoveg;
        }

        private static string DomainVegzodes(string szoveg)
        {
            string forditott = "";
            for (int i = szoveg.Length - 1; szoveg[i]!='.'; i--)
            {
                forditott += szoveg[i];
            }

            string visszaforditott = "";
            for (int i = forditott.Length - 1; i >= 0; i--)
            {
                visszaforditott += forditott[i];
            }

            return visszaforditott;
        }
    }
}

```