using ClubeDaLeituraAP.MagazineModule;
using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.BoxModule
{
    public class Box
    {
        public int Id;
        public string Tag;
        public int Colour;
        public int MaxBorrowDays;
        public Magazine[] magazines;

        public Box(string tag, int colour, int maxBorrowDays)
        {
            Tag = tag;
            Colour = colour;
            MaxBorrowDays = maxBorrowDays;
        }

        public void AddMag(Magazine mag)
        {
            for (int i = 0; i < magazines.Length; i++)
            {
                if (magazines[i] == null)
                {
                    magazines[i] = mag;
                }
            }
        }


        public string ColorSelection(Box box)
        {
            switch (box.Colour)
            {
                case 1:
                    return "Vermelho";
                    break;
                case 2:
                    return "Verde";
                    break;
                case 3:
                    return "Azul";
                    break;
                case 4:
                    return "Amarelo";
                    break;
                default:
                    return "N/A";


            }  
        }


       public int AmountOfMagsInBox()
        {
            int counter = 0;

            for (int i = 0; i < magazines.Length; i++)
            {
                if (magazines[i] == null)
                {
                    counter++;
                }

               
            }
            return counter;
        }

    }
}
