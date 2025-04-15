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
        public Magazine[] magazines = new Magazine[100];
        public int AmountOfMagazines;

        public Box(string tag, int colour, int maxBorrowDays)
        {
            Tag = tag;
            Colour = colour;
            MaxBorrowDays = maxBorrowDays;
            AmountOfMagazines = 0;
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
            if (magazines == null)
                return 0;

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

        public string Validate()
        {
            string errors = null;

            if (string.IsNullOrWhiteSpace(Tag))
                errors += "O Campo Etiqueta é Obrigatório.\n";

            else if (Tag.Length < 3 || Tag.Length > 50)
                errors += "O Campo Etiqueta não atende o limite de caracteres\n";

            return errors;
            


            
        }

    }
}
