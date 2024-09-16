```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp9
{
    class Program
    {
        enum Szamolj { Szokozoket, Massalhangzokat, Betuket }
        static void Main(string[] args)
        {
            string[] adatok = Feltolt();
            for (int i = 0; i < adatok.Length; i++)
            {
                string adat = adatok[i];
                if (Szerzo(adat).Length <= 10) 
                {
                    Console.WriteLine($"Eredeti szöveg: {adat}");
                    Console.WriteLine($"Szóközök száma: {Szamlalo(adat, Szamolj.Szokozoket)} db");
                    Console.WriteLine($"Mássalhagzók száma: {Szamlalo(adat, Szamolj.Massalhangzokat)} db");
                    Console.WriteLine($"Betűk száma: {Szamlalo(adat, Szamolj.Betuket)} db");
                    Console.WriteLine("módosított szöveg:");
                    Console.WriteLine($"\t-transzformáció: {Modositott(adat)}");
                    Console.WriteLine($"\t-karakterhossza: {Modositott(adat).Length}");
                    Console.WriteLine();

                }
            }
            Console.ReadKey();
        }

        private static string[] Feltolt()
        {
            return File.ReadAllLines("konyvek.txt");
        }

        private static int Szamlalo(string szoveg, Szamolj szamolj)
        {
            int db = 0;
            for (int i = 0; i < szoveg.Length; i++)
            {
                char karakter = szoveg[i];
                switch (szamolj)
                {
                    case Szamolj.Szokozoket:
                        if(karakter==' ')
                        {
                            db++;
                        }
                        break;
                    case Szamolj.Massalhangzokat:
                        if (!(
                            karakter=='a' ||
                            karakter=='A' ||
                            karakter=='e' ||
                            karakter=='E' ||
                            karakter=='i' ||
                            karakter=='I' ||
                            karakter=='o' ||
                            karakter=='O' ||
                            karakter=='u' ||
                            karakter=='U' ||
                            karakter==' ' ||
                            karakter==',' ))
                        {
                            db++;
                        }
                        break;
                    case Szamolj.Betuket:
                        if (karakter>='a' && karakter<='z' || karakter>='A' && karakter<='Z')
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
                char karakter = szoveg[i];
                if (!(karakter==' ' || karakter>='A' && karakter<='Z'))
                {
                    if (karakter>='a' && karakter<='z')
                    {
                        ujSzoveg += (char)(karakter - 32);
                    }
                    else
                    {
                        ujSzoveg += karakter; // itt kéne ,
                    }
                    ujSzoveg += '|';
                }
            }
            return ujSzoveg;
        }

        private static string Szerzo(string szoveg)
        {
            string forditott = "";

            for (int i = szoveg.Length - 1; szoveg[i]!=','; i--)
            {
                forditott += szoveg[i];
            }

            string visszaforditott = "";
            for (int i = forditott.Length - 2; i >= 0; i--)
            {
                visszaforditott += forditott[i];
            }

            return visszaforditott;
        }
    }
}

```