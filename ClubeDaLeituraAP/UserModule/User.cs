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
            Name = name;
            ParentName = parentName;
            Telephone = telephone;
            
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

        public string Validate()
        {
            string errors = null;

            if (string.IsNullOrWhiteSpace(Name))
                errors += "O Campo Nome é Obrigatório.\n";

            else if (Name.Length < 3 || Name.Length > 100)
                errors += "O Campo Nome não atende o limite de caracteres\n";

            if (string.IsNullOrWhiteSpace(ParentName))
                errors += "O Campo Nome do Responsável é Obrigatório.\n";

            else if (Name.Length < 3 || Name.Length > 100)
                errors += "O Campo Nome do responsável não atende o limite de caracteres\n";

            if (string.IsNullOrWhiteSpace(Telephone))
                errors += "O Campo Telefone é obrigatório\n";

            else if (Telephone.Length < 11)
            {
                errors += "O Campo Telefone Não atende o limite imposto";
            }

                return errors;
        }
    }
}
