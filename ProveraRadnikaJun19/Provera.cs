using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProveraRadnikaJun19
{
    public class Provera : IProvera
    {
        public List<string> listaPrisustva(string ime_radnika)
        {
            Radnik radnik = null;
            foreach (Radnik r in Repository.Instance.radnici)
                if (r.ime.Equals(ime_radnika))
                    radnik = r;

            if(radnik == null)
            {
                Console.WriteLine($"Radnik sa {ime_radnika} ne postoji u bazi.");
                return null;
            }
            else
            {
                return radnik.lista_prisustva;
            }
        }

        public bool login(string ime)
        {
            Radnik radnik = null;
            Boolean registrovan = false;
            foreach (Radnik r in Repository.Instance.radnici)
                if (r.ime.Equals(ime))
                {
                    registrovan = true;
                    radnik = r;
                }


            if (registrovan == false)
            {
                radnik = new Radnik(ime);
                Repository.Instance.radnici.Add(radnik);
                Console.WriteLine("Registracija i Logovanje uspesno izvrseno");

                radnik.ulogovan = $"Radnik {ime} je stigao na posao u {DateTime.Now}. ";
            }
            else
            {
                if (radnik.ulogovan != "")
                {
                    Console.WriteLine($"Radnik {ime} je na poslu. Ponovno prijavljivanje nije moguce");
                    return false;
                }
                else
                {
                    radnik.ulogovan = $"Radnik {ime} je stigao na posao u {DateTime.Now}. ";

                }

            }
            return true;
        }

        public bool logout(string ime)
        {
            Radnik radnik = null; 
            foreach (Radnik r in Repository.Instance.radnici)
                if (r.ime.Equals(ime))
                {
                    radnik = r;
                }

            if (radnik == null)
                return false;

            if (radnik.ulogovan == "")
            {
                Console.WriteLine($"Radnik {ime} jos uvek nije stigao na posao");
                return false;
            }
            else
            {
                radnik.ulogovan += $"Radnik je otisao sa posla u {DateTime.Now}";

                radnik.lista_prisustva.Add(radnik.ulogovan);

                radnik.ulogovan = "";

                Console.WriteLine("Odjava uspesno izvrsena.");
            }

            return true;

                
        }
    }
}
