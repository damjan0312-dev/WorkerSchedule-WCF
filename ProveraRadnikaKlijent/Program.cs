using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProveraRadnikaKlijent.ServiceReference1;

namespace ProveraRadnikaKlijent
{
    class Program
    {
        static void Main()
        {
            ProveraClient proxy = new ProveraClient();

            Console.WriteLine(">>>>> DOBRODOSLI, MUNJA TRANS 2019 <<<<<< \n");
            Console.WriteLine("Izaberite jednu od sledecih opcija: \n" +
                "a) Prijava dolaska \n" +
                "b) Prijava odlaska \n" +
                "c) Lista dolazak i odlazaka \n" +
                "z) Izlaz");

            string opcija = Console.ReadLine();

            while(opcija != "z")
            {
                Console.WriteLine("Unesite ime radnika: ");
                string ime = Console.ReadLine();

                if (opcija == "a")
                {
                    if (proxy.login(ime))
                    {
                        Console.WriteLine("---------------Radnik uspesno prijavljen");
                    }
                }
                if(opcija == "b")
                {

                    if (proxy.logout(ime))
                    {
                        Console.WriteLine("---------------Radnik uspesno odjavljen");
                    }
                    else
                    {
                        Console.WriteLine("---------------Radnik nije uspesno odjavljen");
                    }
                }
                if(opcija == "c")
                {
                    string[] lista = proxy.listaPrisustva(ime);

                    Console.WriteLine($"Lista prisustva za radnik {ime}: \n");
                    foreach(string zapis in lista)
                        Console.WriteLine($"\n -> {zapis}");
                }

                Console.WriteLine("Izaberite jednu od sledecih opcija: \n" +
                                      "a) Prijava dolaska \n" +
                                      "b) Prijava odlaska \n" +
                                      "c) Lista dolazak i odlazaka \n" +
                                      "z) Izlaz");

                opcija = Console.ReadLine();
            }

        }
    }
}
