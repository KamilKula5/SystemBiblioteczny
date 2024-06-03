using a;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraary
{
    public class Ksiazka
    {
        private List<Typ> Typ { get; set; }
        private List<string> Autor { get; set; }
        private string Tytul { get; set; }
        private string Wydawca { get; set; }
        private int RokWydania { get; set; }
        private string Jezyk { get; set; }
        private int MaksymalnyCzasWypozyczenia { get; set; } = 30;
        private bool Dostepnosc { get; set; }
        private string RodzajSzkoly { get; set; }
        private bool ZawieraStreszczenie { get; set; } = false;
        private bool ZawieraOpracowanie { get; set; } = false;
        private string Dziedzina { get; set; }
        private string Bibliografia { get; set; }
        private bool CzyAutobiografia { get; set; } = false;
        private List<string> Gatunek { get; set; }
        private bool CzyTragedia { get; set; } = false;
        public List<EgzemplarzKsiazki> egzemplarze { get; set; }
        private List<Ksiazka> EkstensjaKsiazki { get; set; }

        public Ksiazka()
        {
            Typ = new List<Typ>();
            Autor = new List<string>();
            Gatunek = new List<string>();
        }



        public bool Dodaj()
        {
            EkstensjaKsiazki.Add(this);
            return true;
        }

        public bool Usun()
        {
            EkstensjaKsiazki.Remove(this);
            return true;
        }

        public bool UaktualnijInformacje(string info)
        {
            Console.WriteLine("Uaktualniono informacje o książce");
            return true;
        }

        public bool SprawdzDostepnosc()
        {
            Dostepnosc = egzemplarze.Any(e => e.CzyMoznaWypozyczyc);
            Console.WriteLine("Sprawdzono dostępność książki");
            return true;
        }

        public List<Ksiazka> PokazKsiazkiAutora(string autor)
        {
            var ksiazkiAutora = EkstensjaKsiazki.Where(k => k.Autor.Contains(autor)).ToList();
            Console.WriteLine("Pokazano książki autora");
            return ksiazkiAutora;
        }

        public string PokazInformacje()
        {
            string informacje = $"Tytuł: {Tytul}, Autor: {string.Join(", ", Autor)}, Rok wydania: {RokWydania}, Język: {Jezyk}";
            Console.WriteLine("Pokazano informacje o książce");
            return informacje;
        }
    }
    public class Zwrot
    {
        private string DataZwrotu { get; set; }
        private string StanEgzemplarza { get; set; }
        private int IleOpozniony { get; set; }

        public Wypozyczenie Wypozyczenie { get; set; }
        public Platnosc Platnosc { get; set; }

        public int ObliczOpoznienie()
        {
            DateTime dataZwrotu = DateTime.Parse(DataZwrotu);
            DateTime terminZwrotu = DateTime.Parse(Wypozyczenie.TerminZwrotu);

            if (dataZwrotu > terminZwrotu)
            {
                int opoznienie = (dataZwrotu - terminZwrotu).Days;
                IleOpozniony = opoznienie;

                // Aktualizacja opóźnienia
                Console.WriteLine($"Opóźnienie zwrotu: {opoznienie} dni.");
                return opoznienie;
            }

            IleOpozniony = 0;
            Console.WriteLine("Brak opóźnienia.");
            return 0;
        }
    }

    public class Platnosc
    {

        private double Kwota { get; set; }
        private string DataPlatnosci { get; set; }
        private string MetodaPlatnosci { get; set; }
        private double MinimalnaKwota { get; set; } = 1.0;
        private string TerminWzrostuKary { get; set; }
        public Zwrot Zwrot { get; set; }
        public Czytelnik Czytelnik { get; set; }
        public bool Zaplac()
        {
            if (Kwota < MinimalnaKwota)
            {
                return false;
            }

            Console.WriteLine($"Płatność w wysokości {Kwota} została dokonana");
            return true;
        }
    }

}
