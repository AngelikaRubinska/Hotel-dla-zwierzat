using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_dla_zwierząt
{
    public class Osoba
    {
        private string imie, nazwisko;
        public  string Imie
        {
            get
            {
                return imie;
            }
            set
            {
                imie = value;
            }
        }
        public  string Nazwisko
        {
            get
            {
                return nazwisko;
            }
            set
            {
                nazwisko = value;
            }
        }
        public virtual string DajDane()
        {
            return Imie + " " + Nazwisko;
        }

    }
    public class Wlasciciel : Osoba
    {
        private string nrtel;
        public string NrTel
        {
            get
            {
                return nrtel;
            }
            set
            {
                if (value.Length == 9)
                {
                    nrtel = value;
                }
            }
        }
        public override string DajDane()
        {
            return "Własciciel: " + base.DajDane() + ",tel.: " + NrTel;
        }
    }
    public class Opiekun : Osoba
    {
        public Opiekun(int o)
        {
            
            if (o == 1)
            {
                Imie = "Magda";
                Nazwisko = "Kowalska";
                Staz = 4;
            }
            else if (o==2)
            {
                Imie = "Ania";
                Nazwisko = "Nowak";
                Staz = 6;
            }
        } 
        
        private int staz;
        public int Staz
        {
            get
            {
                return staz;
            }
            set
            {
                staz = value;
            }
        }
        
        
        public override string DajDane()
        {
            return "Opiekun twojego psiaka na czas pobytu: " + base.DajDane() + ", staz pracy: " + Staz + " lat.\n";
        }

    }
}
