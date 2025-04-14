using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeituraAP.BorrowModule;
using ClubeDaLeituraAP.BoxModule;
using ClubeDaLeituraAP.MagazineModule;
using ClubeDaLeituraAP.UserModule;

namespace ClubeDaLeituraAP.Shared
{
    public class MainMenuScreen

    {
        public void MainMenu()
        {
            BoxRepo boxRepo = new BoxRepo();
            BoxScreen box = new BoxScreen(boxRepo, this);


            UserRepo userRepo = new UserRepo();
            UserScreen user = new UserScreen(userRepo, this);

            MagazineRepo magazineRepo = new MagazineRepo();
            MagazineScreen magazine = new MagazineScreen(magazineRepo, boxRepo, box, this);

            BorrowRepo borrowRepo= new BorrowRepo();
            BorrowScreen borrow = new BorrowScreen(borrowRepo, magazineRepo, magazine, userRepo,user, this);
            




            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------------------");
                Console.WriteLine("Organizador Clube da Leitura");
                Console.WriteLine("--------------------------\n\n");

                Console.WriteLine("Criar, Editar e Deletar Elementos\n");
                Console.WriteLine("1.Usuários\n2.Caixas\n3.Revistas\n");

                Console.WriteLine("4.Empréstimos\n");
                Console.WriteLine("5.Sair\n");

                Console.WriteLine("Digite uma Opção Válida: ");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        user.Menu();
                        break;
                    case 2:
                        box.Menu();
                        break;
                    case 3:
                        magazine.Menu();
                        break;
                    case 4:
                        borrow.Menu();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Erro, Opção Inválida.");
                        Console.ReadLine();
                        break;

                }

            }






        }
    }
}
