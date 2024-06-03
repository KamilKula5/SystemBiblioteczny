using System;
using System.Collections.Generic;


namespace a
{


    enum Stan
    {
        nowy, lekkoZniszczony, srednioZniszczony, mocnoZniszczony
    }

    enum Typ
    {
        lektura, bibliografia, powiesc, dramat, ksiazkaNaukowa
    }

    enum Status
    {
        zlozona, odebrana, anulowanaPrzezKlienta, anulowanaPrzezSystem
    }

    enum Uprawnienia
    {
        brak, dodawanieKsiazek, usuwanieKsiazek
    }

    public abstract class Osoba
    {
        private string Nazwisko { get; set; }
        private string Imie { get; set; }
        private string Login { get; set; }
        private string Haslo { get; set; }

        public Osoba(string nazwisko, string imie, string login, string haslo)
        {
            Nazwisko = nazwisko;
            Imie = imie;
            Login = login;
            Haslo = haslo;
        }

        public abstract bool Zaloguj();
        public abstract void PrzegladajKsiazki();
    }

    public class Czytelnik : Osoba
    {
        private string NumerKarty { get; set; }
        private int Pesel { get; set; }
        private int Telefon { get; set; }
        private string Email { get; set; }
        private Wypozyczenie[] AktualneWypozyczenia { get; set; }

        public List<Rezerwacja> Rezerwacje { get; private set; }
        public List<Wypozyczenie> Wypozyczenia { get; private set; }
        public List<Platnosc> Platnosci { get; private set; }

        private List<Czytelnik> EkstensjaCzytelnicy { get; set; }

        public Czytelnik(string nazwisko, string imie, string login, string haslo, string numerKarty, int pesel, int telefon, string email = null)
            : base(nazwisko, imie, login, haslo)
        {
            NumerKarty = numerKarty;
            Pesel = pesel;
            Telefon = telefon;
            Email = email;
            AktualneWypozyczenia = new Wypozyczenie[5];
            Rezerwacje = new List<Rezerwacja>();
            Wypozyczenia = new List<Wypozyczenie>();
            Platnosci = new List<Platnosc>();
        }

        public override bool Zaloguj()
        {
            // Implementacja logowania
            Console.WriteLine("Czytelnik zalogowany.");
            return true;
        }

        public override void PrzegladajKsiazki()
        {
            // Implementacja przeglądania książek
            Console.WriteLine("Przeglądanie książek.");
        }

        public void SprawdzHistorie()
        {
            // Implementacja sprawdzania historii wypożyczeń
            Console.WriteLine("Historia wypożyczeń:");
            foreach (var wypozyczenie in Wypozyczenia)
            {
                Console.WriteLine($"Wypożyczenie: {wypozyczenie}");
            }
        }
    }

    public class Bibliotekarz : Osoba
    {
        private List<Uprawnienia> Uprawnienia { get; set; }

        public Bibliotekarz(string nazwisko, string imie, string login, string haslo)
            : base(nazwisko, imie, login, haslo)
        {
            Uprawnienia = new List<Uprawnienia>();
        }

        public override bool Zaloguj()
        {
            // Implementacja logowania
            Console.WriteLine("Bibliotekarz zalogowany.");
            return true;
        }

        public override void PrzegladajKsiazki()
        {
            // Implementacja przeglądania książek
            Console.WriteLine("Przeglądanie książek.");
        }

        public void DodajKsiazke(Ksiazka ksiazka)
        {
            // Implementacja dodawania książki
            Console.WriteLine($"Dodano książkę: {ksiazka.Tytul}");
        }

        public void UsunKsiazke(Ksiazka ksiazka)
        {
            // Implementacja usuwania książki
            Console.WriteLine($"Usunięto książkę: {ksiazka.Tytul}");
        }
    }

    public class Ksiazka
    {
        private List<Typ> Typ { get; set; }
        private List<string> Autor { get; set; }
        public string Tytul { get; set; }
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
        public List<EgzemplarzKsiazki> Egzemplarze { get; private set; }

        public Ksiazka(string tytul, string wydawca, int rokWydania, string jezyk)
        {
            Tytul = tytul;
            Wydawca = wydawca;
            RokWydania = rokWydania;
            Jezyk = jezyk;
            Typ = new List<Typ>();
            Autor = new List<string>();
            Gatunek = new List<string>();
            Egzemplarze = new List<EgzemplarzKsiazki>();
        }

        public int PokazLiczbeWypozyczen()
        {
            // Implementacja
            Console.WriteLine("Pokazuję liczbę wypożyczeń.");
            return Egzemplarze.Count;
        }

        public bool DodajEgzemplarz(EgzemplarzKsiazki egzemplarz)
        {
            Egzemplarze.Add(egzemplarz);
            egzemplarz.Ksiazka = this;
            Console.WriteLine("Dodano egzemplarz książki.");
            return true;
        }

        public bool UsunEgzemplarz(EgzemplarzKsiazki egzemplarz)
        {
            Egzemplarze.Remove(egzemplarz);
            Console.WriteLine("Usunięto egzemplarz książki.");
            return true;
        }

        public bool UaktualnijInformacje(string info)
        {
            // Implementacja
            Console.WriteLine("Uaktualniono informacje o książce.");
            return true;
        }

        public bool SprawdzDostepnosc()
        {
            // Implementacja
            Console.WriteLine("Sprawdzono dostępność książki.");
            return Dostepnosc;
        }

        public List<Ksiazka> PokazKsiazkiAutora(string autor)
        {
            // Implementacja
            Console.WriteLine("Pokazano książki autora.");
            return new List<Ksiazka>();
        }

        public string PokazInformacje()
        {
            // Implementacja
            Console.WriteLine("Pokazano informacje o książce.");
            return $"Tytuł: {Tytul}, Autor: {string.Join(", ", Autor)}, Rok wydania: {RokWydania}, Język: {Jezyk}";
        }
    }

    public class EgzemplarzKsiazki
    {
        private string Sygnatura { get; set; }
        public Stan Stan { get; set; } = Stan.nowy;
        private string DataDodania { get; set; }
        private bool CzyMoznaWypozyczyc { get; set; }
        private Bibliotekarz KtoWycofalKsiazke { get; set; }
        private string PowodWycofania { get; set; }
        private bool CzyWycofany { get; set; }

        public Ksiazka Ksiazka { get; set; }
        public List<Rezerwacja> Rezerwacje { get; private set; }
        public List<Wypozyczenie> Wypozyczenia { get; private set; }
        public List<EgzemplarzKsiazki> EkstensjaEgzemplarzy { get; private set; }

        public EgzemplarzKsiazki(string sygnatura, string dataDodania)
        {
            Sygnatura = sygnatura;
            DataDodania = dataDodania;
            Rezerwacje = new List<Rezerwacja>();
            Wypozyczenia = new List<Wypozyczenie>();
        }

        public void Wycofaj(Bibliotekarz bibliotekarz, string powod)
        {
            CzyMoznaWypozyczyc = false;
            KtoWycofalKsiazke = bibliotekarz;
            PowodWycofania = powod;
            CzyWycofany = true;
            Console.WriteLine("Wycofano egzemplarz książki.");
        }

        public void Dodaj()
        {
            // Implementacja
            Console.WriteLine("Dodano egzemplarz książki.");
        }

        public void PotwierdzWycofanie()
        {
            // Implementacja
            Console.WriteLine("Potwierdzono wycofanie egzemplarza książki.");
        }

        public void WyswietlKomunikat(string komunikat)
        {
            Console.WriteLine(komunikat);
        }

        public void ZablokujWypozyczanie()
        {
            CzyMoznaWypozyczyc = false;
            Console.WriteLine("Zablokowano wypożyczanie egzemplarza książki.");
        }

        public void ZmienStanEgzemplarza(Stan stan)
        {
            Stan = stan;
            Console.WriteLine("Zmieniono stan egzemplarza książki.");
        }

        public void DodajRezerwacje(Rezerwacja rezerwacja)
        {
            Rezerwacje.Add(rezerwacja);
            Console.WriteLine("Dodano rezerwację.");
        }

        public void UsunRezerwacje(Rezerwacja rezerwacja)
        {
            Rezerwacje.Remove(rezerwacja);
            Console.WriteLine("Usunięto rezerwację.");
        }
        public List<EgzemplarzKsiazki> WyszukajZeStanem(Stan stan)
        {
            Stan = stan;
            Console.WriteLine("Wyszukuj ze stanem");
        }
    }

    public class Rezerwacja
    {
        private string DataRezerwacji { get; set; }
        private Status Status { get; set; } = Status.zlozona;

        public List<EgzemplarzKsiazki> Egzemplarze { get; private set; }
        public Czytelnik Czytelnik { get; set; }
        private List<Rezerwacja> EkstensjaRezerwacji { get; set; }

        public Rezerwacja(string dataRezerwacji, Czytelnik czytelnik)
        {
            DataRezerwacji = dataRezerwacji;
            Czytelnik = czytelnik;
            Egzemplarze = new List<EgzemplarzKsiazki>();
        }

        public void Anuluj()
        {
            Status = Status.anulowanaPrzezKlienta;
            Console.WriteLine("Rezerwacja została anulowana.");
        }

        public bool AnulujWszystkieNieodebrane()
        {
            Console.WriteLine("Anuluj wszystkie");
            return true;
        }
        public void Stworz(Czytelnik czytelnik, EgzemplarzKsiazki egzemplarz)
        {
            Czytelnik = czytelnik;
            egzemplarz.DodajRezerwacje(this);
            Egzemplarze.Add(egzemplarz);
            Console.WriteLine("Rezerwacja została stworzona.");
        }

        public void AktualizujStatus(Status status)
        {
            Status = status;
            Console.WriteLine($"Status rezerwacji został zaktualizowany do: {status}");
        }
        public void AktualizujStatusy(Status status, string kryteria)
        {
            Status = status;
            Console.WriteLine($"Status rezerwacji został zaktualizowany do: {status}");
        }
    }

    public class Wypozyczenie
    {
        public string TerminZwrotu { get; set; }
        private string DataWypozyczenia { get; set; }

        public Czytelnik Czytelnik { get; set; }
        public EgzemplarzKsiazki Egzemplarz { get; set; }
        public Zwrot Zwrot { get; set; }
        private List<Wypozyczenie> EkstensjaWypozyczen { get; set; }

        public Wypozyczenie(string dataWypozyczenia, string terminZwrotu)
        {
            DataWypozyczenia = dataWypozyczenia;
            TerminZwrotu = terminZwrotu;
        }

        public bool Zwroc()
        {
            // Implementacja zwrotu
            Console.WriteLine("Zwrócono egzemplarz książki.");
            return true;
        }

        public bool Wypozycz(Czytelnik czytelnik, EgzemplarzKsiazki egzemplarz)
        {
            Czytelnik = czytelnik;
            Egzemplarz = egzemplarz;
            egzemplarz.Wypozyczenia.Add(this);
            czytelnik.Wypozyczenia.Add(this);
            Console.WriteLine("Wypożyczono egzemplarz książki.");
            return true;
        }

        public void SprawdzTerminZwrotu()
        {
            Console.WriteLine($"Termin zwrotu: {TerminZwrotu}");
        }
        public int WyslijPowiadomienieOKarze()
        {
            int licznik = 0;
            if (Zwrot.IleOpozniony > 0)
            {
                licznik++;
            }
            return licznik;
        }
        public int WyslijPowiadomienieOTerminieZwrotu()
        {
            int licznik = 0;
            DateTime dataZwrotu = DateTime.Parse(Zwrot.DataZwrotu);
            DateTime terminZwrotu = DateTime.Parse(TerminZwrotu);
            if (dataZwrotu > terminZwrotu)
            {
                licznik++;
            }
            return licznik;
        }
    }

    public class Zwrot
    {
        public string DataZwrotu { get; set; }
        private string StanEgzemplarza { get; set; }
        public int IleOpozniony { get; set; }

        public Wypozyczenie Wypozyczenie { get; set; }
        public Platnosc Platnosc { get; set; }

        public Zwrot(string dataZwrotu, string stanEgzemplarza)
        {
            DataZwrotu = dataZwrotu;
            StanEgzemplarza = stanEgzemplarza;
        }

        public int ObliczOpoznienie()
        {
            DateTime dataZwrotu = DateTime.Parse(DataZwrotu);
            DateTime terminZwrotu = DateTime.Parse(Wypozyczenie.TerminZwrotu);

            if (dataZwrotu > terminZwrotu)
            {
                int opoznienie = (dataZwrotu - terminZwrotu).Days;
                IleOpozniony = opoznienie;
                Console.WriteLine($"Opóźnienie zwrotu: {opoznienie} dni.");
                return opoznienie;
            }
            IleOpozniony = 0;
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
        public Platnosc(double kwota, string dataPlatnosci, string metodaPlatnosci, string terminWzrostuKary)
        {
            Kwota = kwota;
            DataPlatnosci = dataPlatnosci;
            MetodaPlatnosci = metodaPlatnosci;
            TerminWzrostuKary = terminWzrostuKary;
        }

        public bool Zaplac()
        {
            Console.WriteLine($"Płatność w wysokości {Kwota} została dokonana.");
            return true;
        }
    }
}