using ClubeDaLeituraAP.BoxModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.MagazineModule
{
    public class Magazine
    {
        public int Id;
        public string Title;
        public string Edition;
        public DateTime LaunchDate;
        public string CurrentStatus;
        public Box MaxBorrowDays;

        public Magazine(string title, string edition, DateTime launchDate, int maxBorrowDays, Box box)
        {
            title = Title;
            edition = Edition;
            launchDate = LaunchDate;
            maxBorrowDays = box.MaxBorrowDays;
        }
    
    }
}
