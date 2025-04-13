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
        public int Edition;
        public DateTime LaunchDate;
        public string CurrentStatus = "Disponível";
        public int MaxBorrowDays;
        public string DesignatedBox;

        public Magazine(string title, int edition, DateTime launchDate)
        {
            title = Title;
            edition = Edition;
            launchDate = LaunchDate;
            
            
        }
    
    }
}
