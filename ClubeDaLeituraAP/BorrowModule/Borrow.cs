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
        public User User;
        public Magazine Magazine;
        public DateTime InitialDate;
        public DateTime FinalDate;
        public Box Box;

        public Borrow(User user, Magazine magazine, Box box)
        {
            User = user;
            Magazine = magazine;
            InitialDate = new DateTime();
            FinalDate = InitialDate.AddDays(box.MaxBorrowDays);
        }
    }
}
