using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_dla_zwierząt
{
   public class Menu
    {
        private string[] elementy;
        public void Konfiguruj(string[] elementyMenu)
        {
            if (elementyMenu.Length <= 20)
            {
                elementy = elementyMenu;
            }
            else
            {
                elementy = new string[0];
            }
        }
        public int Wyswietl()
        {
            int dlugosc=0;
            for (int i = 0; i < elementy.Length; i++)
            {
                if (dlugosc < elementy[i].Length)
                {
                    dlugosc = elementy[i].Length;
                }
            }

            int wybrany = 0;
            if (elementy != null)
            {
                ConsoleKeyInfo keyInfo;
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                do
                {
                    Console.SetCursorPosition(0, 3);
                    for (int i = 0; i < elementy.Length; i++)
                    {
                        if (wybrany == i)
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                        }
                        Console.WriteLine(elementy[i].PadRight(dlugosc+1));
                    }

                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        wybrany--;
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        wybrany++;
                    }
                } while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);
                
            }
            Console.ResetColor();
            return wybrany;
        }
    }
}
