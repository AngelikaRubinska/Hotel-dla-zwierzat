using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_dla_zwierząt
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Menu menuGlowne = new Menu();
            ZwierzeManager manager = new ZwierzeManager();
            menuGlowne.Konfiguruj(new string[] { "Zarezerwuj pobyt","Lista podopiecznych", "Cennik", "Warunki przyjecia", "O nas", "Zakończ" });
            int zadanie;
            do {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("****Hotel dla zwierząt****");
                Console.WriteLine("       ***4 Łapy***\n");
                Console.ResetColor();
               zadanie= menuGlowne.Wyswietl();
                switch (zadanie)
                {
                    case 0:
                        manager.Rezerwacja();
                        break;
                    case 1:
                        manager.ListaZwierzat();
                        
                        break;
                    case 2:
                        manager.Cennik();
                        break;
                    case 3:
                        manager.Warunki();
                        break;
                    case 4:
                        manager.Onas();
                        break;
                }
            } while (zadanie!=5);

            
            
        }
    }
}
