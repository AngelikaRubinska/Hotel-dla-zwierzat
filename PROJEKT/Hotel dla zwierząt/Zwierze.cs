
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_dla_zwierząt
{

    public abstract class Zwierze
    {
        public string Imie, Rasa, Plec;
        private int doby;

        public Wlasciciel Wlasc { get; set; }


        public void Zapisz()
        {

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Hotel";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string[] dane = new string[] { Imie, Rasa, Plec, Doby.ToString(), Wlasc.DajDane(), "Dodatkowe informacje: "+Info() };
            File.WriteAllLines($@"{folder}\{Imie}_{Plec}.txt", dane);
        }
        public int Doby
        {
            get
            {
                return doby;
            }
            set
            {
                if (value <= 7)
                {
                    doby = value;
                }
                else
                {
                    doby = 7;
                }
            }
        }
        public abstract string Info();
       
    }
   public class Pies : Zwierze
    {
        private double masa;
        public double Masa
        {
            get
            {
                return masa;
            }
             set
            {
                if (value > 0)
                    masa = value;
            }
        }
        public Pies()
        {

            Random r = new Random(DateTime.Now.Millisecond);
            int o= r.Next(3);
            opiekun = new Opiekun(o);
        }
        
        private Opiekun opiekun;
        public Opiekun Opiekun => opiekun;

        public override string Info()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Prosimy o podanie dodatkowych informacji o psiaku {Imie}.");
            Console.WriteLine("Jaki ma stosunek do innych psow, czy ma lek separacyjny, jakie ma nastawienie do obcych, itp.");
            Console.ResetColor();
           return Console.ReadLine();
        }


    }
    class Kot : Zwierze

    {
        private double wiek;
        public double Wiek
        {
            get
            {
                return wiek;
            }
            set
            {
                if (value > 0)
                {
                    wiek = value;
                }
            }
        }
        public override string Info()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Prosimy o podanie dodatkowych informacji o kocie {Imie}.");
            Console.WriteLine("Czy jest to kot wychodzący, jaki ma stosunek do innych kotów, czy jest wysterylizowany/wykastrowany,\nw przypadku kotki data ostatniej rujki");
            Console.ResetColor();
           return Console.ReadLine();
        }
    }
}
