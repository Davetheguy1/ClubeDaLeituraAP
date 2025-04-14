using ClubeDaLeituraAP.BoxModule;
using ClubeDaLeituraAP.Shared;
using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.MagazineModule
{



    public class MagazineScreen
    {
        public MagazineRepo magazineRepo;
        public BoxRepo boxRepo;
        public BoxScreen boxScreen;
        public MainMenuScreen mainMenu;
        public int BoxId;

        public MagazineScreen(MagazineRepo magazineRepo, BoxRepo boxRepo, BoxScreen boxScreen, MainMenuScreen mainMenu)
        {
            this.magazineRepo = magazineRepo;
            this.boxRepo = boxRepo;
            this.boxScreen = boxScreen;
            this.mainMenu = mainMenu;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Revistas:");
            Console.WriteLine("-----------------------\n\n");
            Console.WriteLine("1.Registrar nova revistas\n2.Editar Revistas\n3.Deletar Revistas\n4.Visualizar Revistas\n5.Voltar\n");
            Console.WriteLine("Digite uma opção válida: ");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    RegisterMagazine();
                    break;
                case 2:
                    EditMagazine();
                    break;
                case 3:
                    DeleteMagazine();
                    break;
                case 4:
                    VisualizeMagazines(true);
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

        public void RegisterMagazine()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Registrar Nova Revista");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            Magazine newMagazine = GetMagData();
            magazineRepo.RegisterMagazine(newMagazine);
            magazineRepo.AlocateMag(BoxId, newMagazine);

            Notifier.ShowMessage("Revista Registrada com Sucesso.", ConsoleColor.Green);
        }

        public void EditMagazine()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Editar Revista");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            VisualizeMagazines(false);

            Console.WriteLine("Digite o Id da revista que deseja editar: ");
            int selectedId = int.Parse(Console.ReadLine());

            Magazine editedMag = GetMagData();

            bool wasEditSucessful = magazineRepo.EditMagazine(selectedId, editedMag);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);

        }

        public void DeleteMagazine()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Deletar uma Revista");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            Console.WriteLine("*Revistas atualmente emprestadas não poderão ser Deletadas.");
            Console.WriteLine();

            VisualizeMagazines(false);

            Console.WriteLine("Digite o Id da revista que deseja excluir:");
            int selectedId = int.Parse(Console.ReadLine());

            bool wasEditSucessful = magazineRepo.DeleteMagazine(selectedId);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        public void VisualizeMagazines(bool showTitle)
        {
            if (showTitle)
            {
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("Todas as Revistas:");
                Console.WriteLine("---------------------");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20} | {5, -20}",
            "Id","Título", "Nº Da Edição", "Data de Lançamento", "Caixa", "Disponibilidade" // last one needs borrow module;
        );
            Magazine[] registerMagazines = magazineRepo.SelectMagazines();

            for (int i = 0; i < registerMagazines.Length; i++)
            {
                Magazine m = registerMagazines[i];

                if (m == null) continue;

                Console.WriteLine(
                    "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20} | {5, -20}", m.Id, m.Title, m.Edition, m.LaunchDate, m.DesignatedBox, m.CurrentStatus
                    );
            }
            Console.WriteLine();
            Notifier.ShowMessage("Pressione Enter para Continuar...", ConsoleColor.DarkYellow);
        }

        public Magazine GetMagData()
        {
            Console.WriteLine("Digite o Titulo da Revista: ");
            string title = Console.ReadLine();

            Console.WriteLine("Digite o Nº da Edição: ");
            int edition = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Data de Lançamento (dd/mm/yyyy): ");
            DateTime launchDate = DateTime.Parse(Console.ReadLine());


            boxScreen.VisualizeBox(false);
            Console.WriteLine("Digite o Id da Caixa em que está revista deverá ser armazenda: ");
            BoxId = int.Parse(Console.ReadLine());

            Magazine newMagazine = new Magazine(title, edition, launchDate);

            return newMagazine;

            

 

        }
    }
}
