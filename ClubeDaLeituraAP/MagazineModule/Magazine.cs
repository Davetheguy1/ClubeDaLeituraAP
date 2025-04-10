using ClubeDaLeituraAP.BoxModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.MagazineModule
{
    class Magazine
    {
        public int Id;
        public string Title;
        public string Edition;
        public DateTime LaunchDate;
        public string CurrentStatus;
        public Box MaxBorrowDays;
    
    }
}
