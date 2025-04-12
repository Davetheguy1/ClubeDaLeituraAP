using ClubeDaLeituraAP.BoxModule;
using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.UserModule
{
    public class UserRepo
    {
        public User[] users = new User[100];
        public int amountOfUsers = 0;

        public void RegisterUser(User newUser)
        {
            newUser.Id = IdGenerator.GenerateUserID();

            users[amountOfUsers++] = newUser;
        }

        public bool EditUser(int selectedId, User editedUser)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == null)
                    continue;

                else if (users[i].Id == selectedId)
                {
                    users[i].Name = editedUser.Name;
                    users[i].ParentName = editedUser.ParentName;
                    users[i].Telephone = editedUser.Telephone;

                    return true;
                }
            }
            return false;
        }

        public bool DeleteUser(int selectedId)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i] == null) continue;

                else if (users[i].Id == selectedId && users[i].BlackListed == true)
                {
                    Console.WriteLine("\nErro, Este Usuário tem Pendências, portanto, não pode ser deletado.");
                    return false;
                }
                else if (users[i].Id == selectedId)
                {
                    users[i] = null;
                    return true;
                }
            } return false;
        }
        public User[] SelectUsers()
        {
            return users;
        }
    }
}
