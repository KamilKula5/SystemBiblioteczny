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
        private List<typ> Typ { get; set; }
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

        public Ksiazka()
        {
            Typ = new List<typ>();
            Autor = new List<string>();
            Gatunek = new List<string>();
        }



        public bool Dodaj()
        {
            //* Połączenie z bazą danych
            //var db = new DatabaseConnection();
            //var query = $"INSERT INTO Ksiazka (Tytul, Autor, Wydawca, RokWydania, Jezyk, MaksymalnyCzasWypozyczenia, Dostepnosc, RodzajSzkoly, ZawieraStreszczenie, ZawieraOpracowanie, Dziedzina, Bibliografia, CzyAutobiografia, CzyTragedia) " +
            //            $"VALUES ('{Tytul}', '{string.Join(", ", Autor)}', '{Wydawca}', {RokWydania}, '{Jezyk}', {MaksymalnyCzasWypozyczenia}, {Dostepnosc}, '{RodzajSzkoly}', {ZawieraStreszczenie}, {ZawieraOpracowanie}, '{Dziedzina}', '{Bibliografia}', {CzyAutobiografia}, {CzyTragedia})";
            //db.ExecuteNonQuery(query);

            //Console.WriteLine($"Dodano książkę: {Tytul}");
            return true;
        }

        public bool Usun()
        {
            // Połączenie z bazą danych
            //var db = new DatabaseConnection();
            //var query = $"DELETE FROM Ksiazka WHERE Tytul = '{Tytul}'";
            //db.ExecuteNonQuery(query);

            //Console.WriteLine($"Usunięto książkę: {Tytul}");
            return true;
        }

        public bool UaktualnijInformacje(string info)
        {
            // Połączenie z bazą danych
            //var db = new DatabaseConnection();
            //var query = $"UPDATE Ksiazka SET Informacje = '{info}' WHERE Tytul = '{Tytul}'";
            //db.ExecuteNonQuery(query);

            //Console.WriteLine("Uaktualniono informacje o książce.");
            return true;
        }

        public bool SprawdzDostepnosc()
        {
            //var db = new DatabaseConnection();
            //var result = db.ExecuteQuery($"SELECT Dostepnosc FROM Ksiazka WHERE Tytul = '{Tytul}'");

            //if (result.Read())
            //{
            //    Dostepnosc = result.GetBoolean(0);
            //}
            //Console.WriteLine("Sprawdzono dostępność książki.");
            return true;
        }

        public List<Ksiazka> PokazKsiazkiAutora(string autor)
        {
            // Połączenie z bazą danych
            //var db = new DatabaseConnection();
            //var result = db.ExecuteQuery($"SELECT * FROM Ksiazka WHERE Autor LIKE '%{autor}%'");

            //List<Ksiazka> ksiazki = new List<Ksiazka>();
            //while (result.Read())
            //{
            //    var ksiazka = new Ksiazka
            //    {
            //        Tytul = result["Tytul"].ToString(),
            //        Wydawca = result["Wydawca"].ToString(),
            //        RokWydania = result.GetInt32("RokWydania"),
            //        Jezyk = result["Jezyk"].ToString(),
            //        Dostepnosc = result.GetBoolean("Dostepnosc")
            //    };
            //    ksiazki.Add(ksiazka);
            //}

            //Console.WriteLine("Pokazano książki autora.");
            return new List<Ksiazka>();
        }

        public string PokazInformacje()
        {
            // Połączenie z bazą danych
            //var db = new DatabaseConnection();
            //var result = db.ExecuteQuery($"SELECT * FROM Ksiazka WHERE Tytul = '{Tytul}'");

            //if (result.Read())
            //{
            //    string informacje = $"Tytuł: {result["Tytul"]}, Autor: {result["Autor"]}, Rok wydania: {result["RokWydania"]}, Język: {result["Jezyk"]}";
            //    Console.WriteLine("Pokazano informacje o książce.");
            //    return informacje;
            //}
            return string.Empty;
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
            //DateTime dataZwrotu = DateTime.Parse(DataZwrotu);
            //DateTime terminZwrotu = DateTime.Parse(Wypozyczenie.TerminZwrotu);

            //if (dataZwrotu > terminZwrotu)
            //{
            //    int opoznienie = (dataZwrotu - terminZwrotu).Days;
            //    IleOpozniony = opoznienie;

            //    // Połączenie z bazą danych i aktualizacja opóźnienia
            //    var db = new DatabaseConnection();
            //    var query = $"UPDATE Zwrot SET IleOpozniony = {IleOpozniony} WHERE DataZwrotu = '{DataZwrotu}' AND WypozyczenieID = {Wypozyczenie.ID}";
            //    db.ExecuteNonQuery(query);

            //    Console.WriteLine($"Opóźnienie zwrotu: {opoznienie} dni.");
            //    return opoznienie;
            //}
            //IleOpozniony = 0;

            // Aktualizacja opóźnienia w bazie danych na 0
            //var dbZero = new DatabaseConnection();
            //var queryZero = $"UPDATE Zwrot SET IleOpozniony = 0 WHERE DataZwrotu = '{DataZwrotu}' AND WypozyczenieID = {Wypozyczenie.ID}";
            //dbZero.ExecuteNonQuery(queryZero);
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
            // Sprawdzenie czy kwota jest wystarczająca
            //if (Kwota < MinimalnaKwota)
            //{
            //    Console.WriteLine("Kwota jest mniejsza niż minimalna wymagana kwota.");
            //    return false;
            //}

            // Połączenie z bazą danych i zapisanie płatności
            //var db = new DatabaseConnection();
            //var query = $"INSERT INTO Platnosc (Kwota, DataPlatnosci, MetodaPlatnosci, ZwrotID, CzytelnikID) VALUES ({Kwota}, '{DataPlatnosci}', '{MetodaPlatnosci}', {Zwrot.ID}, {Czytelnik.Pesel})";
            //db.ExecuteNonQuery(query);

            //Console.WriteLine($"Płatność w wysokości {Kwota} została dokonana.");
            return true;
        }
    }

}
