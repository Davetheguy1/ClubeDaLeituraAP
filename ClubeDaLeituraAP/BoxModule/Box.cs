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

        /*public string GetColor()
        {
            string message;
            switch (Colour)
            {
                case 1:
                    message = Notifier.ShowMessage("Vermelho", ConsoleColor.Red);
                    break;
                case 2:
                    Notifier.ShowMessage("Verde", ConsoleColor.Green);
                    break;
                case 3:
                    Notifier.ShowMessage("Azul", ConsoleColor.Blue);
                    break;
                case 4:
                    Notifier.ShowMessage("Amarelo", ConsoleColor.Yellow);
                    break;
            }
        }*/

    }
}
