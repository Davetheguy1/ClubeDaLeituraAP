using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeituraAP.BoxModule;
using ClubeDaLeituraAP.MagazineModule;
using ClubeDaLeituraAP.Shared;
using ClubeDaLeituraAP.UserModule;
using GestãoDeEquipamentosAP.Shared;

namespace ClubeDaLeituraAP.BorrowModule
{
    public class BorrowScreen
    {
        public BorrowRepo borrowRepo;
        public MagazineRepo magazineRepo;
        public MagazineScreen magazineScreen;
        public UserRepo userRepo;
        public UserScreen userScreen;
        public MainMenuScreen mainMenu;

        public BorrowScreen(BorrowRepo borrowRepo, MagazineRepo magazineRepo, MagazineScreen magazineScreen, UserRepo userRepo, UserScreen userScreen, MainMenuScreen mainMenu)
        {
            this.borrowRepo = borrowRepo;
            this.magazineRepo = magazineRepo;
            this.magazineScreen = magazineScreen;
            this.userRepo = userRepo;
            this.userScreen = userScreen;
            this.mainMenu = mainMenu;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Empréstimos:");
            Console.WriteLine("-----------------------\n\n");
            Console.WriteLine("1.Registrar novo Empréstimo\n2.Editar Empréstimos\n3.Deletar Empréstimos\n4.Visualizar Empréstimos\n5.Voltar\n");
            Console.WriteLine("Digite uma opção válida: ");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    RegisterBorrow();
                    break;
                case 2:
                    EditBorrow();
                    break;
                case 3:
                    DeleteBorrow();
                    break;
                case 4:
                    VisualizeBorrows(true);
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

        public void RegisterBorrow()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Registrar Novo Empréstimo");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            Borrow newBorrow = GetBorrowData();
            borrowRepo.RegisterBorrow(newBorrow);

            Notifier.ShowMessage("Empréstimo Registrado com Sucesso.", ConsoleColor.Green);
        }

        public void EditBorrow()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Editar um Empréstimo");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            VisualizeBorrows(false);

            Console.WriteLine("Digite o Id do Empréstimo que deseja editar: ");
            int selectedId = int.Parse(Console.ReadLine());

            Borrow editedBorrow = GetBorrowData();

            bool wasEditSucessful = borrowRepo.EditBorrow(selectedId, editedBorrow);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        public void DeleteBorrow()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Deletar uma Empréstimo");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            VisualizeBorrows(false);

            Console.WriteLine("Digite o Id do Empréstimo a ser Deletado");
            int selectedId = int.Parse(Console.ReadLine());

            bool wasEditSucessful = borrowRepo.DeleteBorrow(selectedId);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        public void VisualizeBorrows(bool showTitle)
        {
            if (showTitle)
            {
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("Todas os Empréstimos:");
                Console.WriteLine("---------------------");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
            "Id", "Usuário", "Revista Alugada", "Data Inicial", "Data Final"
        );
            Borrow[] registeredBorrows = borrowRepo.SelectBorrows();

            for (int i = 0; i< registeredBorrows.Length; i++)
            {
                Borrow b = registeredBorrows[i];

                if (b == null) continue;

                Console.WriteLine(
                    "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20} | {5, -20}", b.Id, b.User, b.Magazine, b.InitialDate, b.FinalDate
                    );
            }
        }

        private Borrow GetBorrowData()
        {
            magazineScreen.VisualizeMagazines(false);

            Console.WriteLine("Digite o Id da revista a ser emprestada");
            int magazineId = int.Parse(Console.ReadLine());

            string mag = borrowRepo.GetMagId(magazineId);

            int maxBorrowDays = borrowRepo.GetBorrowDays(magazineId);

            userScreen.VisualizeUser(false);

            Console.WriteLine("Digite o Id do usuário que pegará a revista");
            int userId = int.Parse(Console.ReadLine());

            string user = borrowRepo.GetUserId(userId);


            Borrow newBorrow = new Borrow(user, mag, maxBorrowDays);

            return newBorrow;


        }



    }
}
