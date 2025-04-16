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

        public string Validate()
        {
            string errors = null;

            if (string.IsNullOrWhiteSpace(Title))
            {
                errors += "O Campo Titulo é Obrigatório";
            }
            else if (Title.Length < 2 || Title.Length > 100)
            {
                errors += "O Titulo não atende os limites Impostos";
            }

            return errors;
        }
    
    }
}
