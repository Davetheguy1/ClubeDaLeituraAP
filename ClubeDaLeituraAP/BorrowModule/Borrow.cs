using ClubeDaLeituraAP.BoxModule;
using ClubeDaLeituraAP.MagazineModule;
using ClubeDaLeituraAP.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.BorrowModule
{
    public class Borrow
    {
        public int Id;
        public string User;
        public string Magazine;
        public DateTime InitialDate;
        public DateTime FinalDate;
        public int MaxBorrowDays;

        public Borrow(string user, string magazine, int maxBorrowDays)
        {
            User = user;
            Magazine = magazine;
            InitialDate = new DateTime();
            MaxBorrowDays = maxBorrowDays;
            FinalDate = InitialDate.AddDays(MaxBorrowDays);
        }
    }
}
