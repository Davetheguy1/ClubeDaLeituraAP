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
        public string Colour;
        public int MaxBorrowDays;

        public Box(string tag, string colour, int maxBorrowDays)
        {
            Tag = tag;
            Colour = colour;
            MaxBorrowDays = maxBorrowDays;
        }

    }
}
