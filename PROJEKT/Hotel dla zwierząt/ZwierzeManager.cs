using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_dla_zwierząt
{
    class ZwierzeManager
    {
        List<Zwierze> zwierzeta;
        public ZwierzeManager()
        {
            zwierzeta = new List<Zwierze>();
            LadujDane();
        }
        private void LadujDane()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Hotel";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            else
            {
                string[] pliki = Directory.GetFiles(folder);
                foreach (var plik in pliki)
                {
                    string[] dane = File.ReadAllLines(plik);
                    Pies zwierze = new Pies()
                    {
                        Imie = dane[0],
                        Rasa = dane[1],
                        Plec = dane[2],
                        Doby = int.Parse(dane[3])
                        
                    };
                    zwierzeta.Add(zwierze);
                }
            }
        }
        public void Rezerwacja()
        {
            Console.Clear();
          
            Menu piseczykot = new Menu();
            piseczykot.Konfiguruj(new string[] { "Zarezerwuj pobyt psa", "Zarezerwuj pobyt kota","Cofnij" });
            int wybor;
            do
            {
                Console.Clear();
                wybor = piseczykot.Wyswietl();
                switch (wybor)
                {
                    case 0:
                        ZarezerwujPsa();
                        break;
                    case 1:
                        ZarezerwujKota();
                        break;
                }
            } while (wybor != 2);
        }
        private void ZarezerwujPsa()
        {
            Pies nowy = new Pies();
            nowy.Wlasc = new Wlasciciel();
            Console.Clear();
            Console.WriteLine("********Rezerwacja pobytu pieska ********\n");
            Console.Write("Imie                    : "); nowy.Imie = Console.ReadLine();
            Console.Write("Rasa                    : "); nowy.Rasa = Console.ReadLine();
            Console.Write("Plec (pies/suczka)      : "); nowy.Plec = Console.ReadLine();
            Console.Write("Masa (w kg)             : "); nowy.Masa = double.Parse(Console.ReadLine());
            Console.Write("Długosc pobytu (1-7 dni): "); nowy.Doby = int.Parse(Console.ReadLine());
            Console.WriteLine($"Cena pobytu wynosi: {CenaPies(nowy.Masa,nowy.Doby)} zł.\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("* Dane wlasciciela *");
            Console.Write("Imie         : "); nowy.Wlasc.Imie = Console.ReadLine();
            Console.Write("Nazwisko     : "); nowy.Wlasc.Nazwisko = Console.ReadLine();
            Console.Write("Numer tel.   : "); nowy.Wlasc.NrTel = Console.ReadLine();
            Console.WriteLine("******************************************\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(nowy.Opiekun.DajDane());
            Console.ForegroundColor = ConsoleColor.Green;
            zwierzeta.Add(nowy);
            nowy.Zapisz();
            Console.ReadKey();
        }
        private void ZarezerwujKota()
        {
            Kot nowy = new Kot();
            nowy.Wlasc = new Wlasciciel();
            Console.Clear();
            Console.WriteLine("********Rezerwacja pobytu kotka ********\n");
            Console.Write("Imie                    : "); nowy.Imie = Console.ReadLine();
            Console.Write("Rasa                    : "); nowy.Rasa = Console.ReadLine();
            Console.Write("Plec (kotka/kocur)      : "); nowy.Plec = Console.ReadLine();
            Console.Write("Wiek (w latach)         : "); nowy.Wiek = double.Parse(Console.ReadLine());
            Console.Write("Długosc pobytu (1-7 dni): "); nowy.Doby = int.Parse(Console.ReadLine());
            Console.WriteLine($"Cena pobytu wynosi : {CenaKot(nowy.Wiek, nowy.Doby)} zł.\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("* Dane wlasciciela *");
            Console.Write("Imie         : "); nowy.Wlasc.Imie = Console.ReadLine();
            Console.Write("Nazwisko     : "); nowy.Wlasc.Nazwisko = Console.ReadLine();
            Console.Write("Numer tel.   : "); nowy.Wlasc.NrTel = Console.ReadLine();
            Console.WriteLine("******************************************");
            Console.ForegroundColor = ConsoleColor.Green;
            zwierzeta.Add(nowy);
            nowy.Zapisz();
            Console.ReadKey();
        }
        public int ListaZwierzat()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**Lista naszych aktualnych podopiecznych**");
            Console.ResetColor();
            Menu lista = new Menu();
            string[] dane = new string[zwierzeta.Count];
            for (int i = 0; i < dane.Length; i++)
            {
                Zwierze z = zwierzeta[i];
                dane[i] = $"{z.Imie}, {z.Rasa}, {z.Plec}, pobyt na {z.Doby} dni.";
            }
            lista.Konfiguruj(dane);

            return lista.Wyswietl();
        }
        public void Cennik()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                              *CENNIK*");
            Console.WriteLine("* MAŁE PSY (do 10kg) (Yorkshire terrier, Pinnczer min., Pomeranian, itp.) - 75zl/doba.");
            Console.WriteLine("* SREDNIE PSY (11-25kg) (Jack russel terrier, Jamnik, Beagle, itp.) - 85 zl/doba.");
            Console.WriteLine("* DUZE PSY (26-40kg) (Owczarek niemiecki, Labrador, Golden retriever, Samoyed, itp.) - 95 zl/doba.");
            Console.WriteLine("* OLBRZYMIE PSY (powyzej 41kg) ( Dog niemiecki, Owczarek podhalański, Berneński pasterski, itp.) - 105zl/doba.\n\n");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("KOTY - 80 zl/doba.\nKociaki do roku zycia - 95 zl/doba\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(Nacisnij dowolny przycisk, aby cofnac do menu glownego)");
            Console.ReadKey();
        }
        private int CenaPies(double m, int d)
        {
            int cena = 0;
            if (m >= 41)
            {
                cena = 105 * d;
            }else if (m >= 26)
            {
                cena = 95 * d;
            }else if (m >= 11)
            {
                cena = 85 * d;
            }
            else if (m > 0)
            {
                cena = 75 * d;
            }

            return cena;
        }
        private int CenaKot(double w, int d)
        {
            int cena = 0;
            if (w >= 1)
            {
                cena = 80 * d;
            }else if (w > 0)
            {
                cena = 95 * d;
            }
            return cena;
        }
        public void Warunki()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("********Warunki przyjecia********\n");
            Console.WriteLine("- Pupile muszą być odrobaczone i odpchlone.\n- Pieski powinny byc wyposazone we wlasne poslanie, smycz i obroze :)");
            Console.WriteLine("- Pupile musza posiadac aktualne szczepienia i ksiazeczke zdrowia!\n- Nie trzeba przywozic wlasnych misek, chyba ze pupil z innych nie chce jesc :)");
            Console.WriteLine("- Przed pierwszym pobytem pieska zachecamy do odwiedzenia naszego hotelu, aby oswoil sie z miejscem i opiekunami :)");
            Console.WriteLine("– Nie przyjmujemy suk w okresie cieczki ani na dzień lub dwa przed cieczką \n– suczka przyjeżdżając musi być minimum 2 tygodnie po ruji, ze względu na bezpieczeństwo pozostałych gości.\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(Nacisnij dowolny przycisk, aby cofnac do menu glownego)");
            Console.ResetColor();
            Console.ReadKey();
        }
        public void Onas()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("******** O nas ********\n");
            Console.WriteLine("Hotel 4 Lapy jest komfortowym obiektem, który powstał z myślą o Państwa zwierzątkach.  ");
            Console.WriteLine("Położony jest w cichej, przyjaznej i czystej okolicy.");
            Console.WriteLine("Wybierając nasz hotel państwa pupil będzie czuł się bezpiecznie, objęty troskliwą opieką. ");
            Console.WriteLine("Zależy nam, aby pupile czuły się u nas prawie jak w domu :)");
            Console.WriteLine("Dbamy o wygłaskanie, przytulanie i rozładowanie energii Waszego zwierzątka!\n\n");
            Console.WriteLine("Waszymi psiakami opiekuja sie Magda i Ania :)\nOpiekun zostanie przydzielony podczas skladania rezerwacji.\n\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\"Hotel 4 Lapy\" \nBialystok\nul. Rodzinna 1\nTel.: 666 444 555\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("(Nacisnij dowolny przycisk, aby cofnac do menu glownego)");
            Console.ReadKey();
           


        }
    }
}
