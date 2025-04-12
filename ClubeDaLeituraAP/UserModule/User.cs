using ClubeDaLeituraAP.MagazineModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.UserModule
{
    public class User
    {
        public int Id;
        public string Name;
        public string ParentName;
        public string Telephone;
        public int Strikes;
        public bool BlackListed;
        public string HavePendencies;
        public Magazine rentedMagazine;
        public User[] AllUsers;

        public User(string name, string parentName, string telephone)
        {
            name = Name;
            parentName = ParentName;
            telephone = Telephone;
            
        }

        
        public string IsUserBlackListed(User user)
        {
            if (user.Strikes > 2)
            {
                user.BlackListed = true;
                return "Sim";
            } else
            {
                user.BlackListed = false;
                return "Não";
            }
            
        }
    }
}
