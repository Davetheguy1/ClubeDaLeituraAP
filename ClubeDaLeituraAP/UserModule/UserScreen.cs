﻿using ClubeDaLeituraAP.BoxModule;
using ClubeDaLeituraAP.Shared;
using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.UserModule
{
    public class UserScreen
    {
        public UserRepo userRepo;
        public MainMenuScreen mainMenu;
        
        public UserScreen(UserRepo userRepo, MainMenuScreen mainMenu)
        {
            this.userRepo = userRepo;
            this.mainMenu = mainMenu;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Usuários:");
            Console.WriteLine("-----------------------\n\n");
            Console.WriteLine("1.Registrar novo usuário\n2.Editar Usuários\n3.Deletar Usuários\n4.Visualizar Usuários\n5.Voltar\n");
            Console.WriteLine("Digite uma opção válida: ");
            int input = int.Parse(Console.ReadLine());

            switch (input) {
                case 1:
                    RegisterUser();
                    break;
                case 2:
                    EditUser();
                    break;
                case 3:
                    DeleteUser();
                    break;
                case 4:
                    VisualizeUser(true);
                    break;
                case 5:
                    mainMenu.MainMenu();
                    break;
                default:
                    Console.WriteLine("Erro, Opção Inválida.");
                    Console.ReadLine();
                    break;
            
            
            
            
            }

        }

        public void RegisterUser()
        {

            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Registrar Novo Usuário");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            User newUser = GetUserData();

            userRepo.RegisterUser(newUser);

            string errors = newUser.Validate();

            if (errors.Length > 0)
            {
                Notifier.ShowMessage(errors, ConsoleColor.Red);

                return;
            }

            Notifier.ShowMessage("Usuário Registrado com Sucesso.", ConsoleColor.Green);
        }

        public void EditUser()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Editar um Usuário");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            VisualizeUser(false);

            Console.WriteLine("Digite o Id do Usuário que deseja editar: ");
            int selectedId = int.Parse(Console.ReadLine());

            User editedUser = GetUserData();

            bool wasEditSucessful = userRepo.EditUser(selectedId, editedUser);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        public void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Deletar um Usuário");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            Notifier.ShowMessage("*Usuários com Pendências Não poderam ser Excluidos", ConsoleColor.DarkYellow);
            Console.WriteLine();

            VisualizeUser(false);

            Console.WriteLine("Digite o Id do Usuário que Deseja Deletar");
            int selectedId = int.Parse(Console.ReadLine());

            bool wasEditSucessful = userRepo.DeleteUser(selectedId);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        public void VisualizeUser(bool showTitle)
        {
            if (showTitle)
            {
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("Lista de Usuários");
                Console.WriteLine("---------------------");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20} | {5, -20}",
            "Id", "Nome", "Nom. Responsável", "Telefone", "Revista Alugada", "Tem Pendências?"
        );
            User[] registeredUsers = userRepo.SelectUsers();


            for (int i = 0; i < registeredUsers.Length; i++)
            {
                User u = registeredUsers[i];

                if (u == null) continue;

                Console.WriteLine(
                    "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20} | {5, -20}", u.Id, u.Name, u.ParentName, u.Telephone, u.rentedMagazine, u.IsUserBlackListed(u)
                    );
            }
            Console.WriteLine();
            Notifier.ShowMessage("Pressione Enter para Continuar...", ConsoleColor.DarkYellow);
        }

        public User GetUserData()
        {
            Console.WriteLine("Digite O Nome do Usuário");
            string name = Console.ReadLine();

            Console.WriteLine("Digite o Nome do Responsável Legal do usuário");
            string parentName = Console.ReadLine();

            Console.WriteLine("Digite o Telefone de Contato ((XX) XXXX-XXXX)");
            string telephone = Console.ReadLine();

            User newUser = new User(name, parentName, telephone);

            return newUser;
        }
    
    
    }
}
