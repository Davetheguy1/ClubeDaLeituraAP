using ClubeDaLeituraAP.Shared;
using GestãoDeEquipamentosAP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeituraAP.BoxModule
{
    public class BoxScreen
    {
        public BoxRepo boxRepo;
        public MainMenuScreen mainMenu;

        public BoxScreen(BoxRepo boxRepo, MainMenuScreen mainMenu)
        {
            this.boxRepo = boxRepo;
            this.mainMenu = mainMenu;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Caixas:");
            Console.WriteLine("-----------------------\n\n");
            Console.WriteLine("1.Registrar nova Caixa\n2.Editar Caixas\n3.Deletar Caixas\n4.Visualizar Caixas\n5.Voltar\n");
            Console.WriteLine("Digite uma opção válida: ");
            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 1:
                    RegisterBox();
                    break;
                case 2:
                    EditBox();
                    break;
                case 3:
                    DeleteBox();
                    break;
                case 4:
                    VisualizeBox(true);
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


        public void RegisterBox()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Registrar Nova Caixa");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            
            Box newBox = GetBoxData();

            boxRepo.RegisterBox(newBox);

            Notifier.ShowMessage("Caixa Registrada com Sucesso.", ConsoleColor.Green);
        }

        public void EditBox()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Editar uma Caixa");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            VisualizeBox(false);

            Console.WriteLine("Digite o Id da Caixa que deseja editar: ");
            int selectedId = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Box editedBox = GetBoxData();

            bool wasEditSucessful = boxRepo.EditBox(selectedId, editedBox);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        } 

        public void DeleteBox()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Deletar uma Caixa");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            Notifier.ShowMessage("*Caixas que ainda contém revistas não poderam ser editadas", ConsoleColor.DarkYellow);
            Console.WriteLine();
            
            VisualizeBox(false);

            Console.WriteLine("Digite o Id da caixa que deseja excluir:");
            int selectedId = int.Parse(Console.ReadLine());

            bool wasEditSucessful = boxRepo.DeleteBox(selectedId);

            if (!wasEditSucessful)
            {
                Notifier.ShowMessage("Ocorreu um Erro durante a Edição", ConsoleColor.Red);
                return;
            }

            Notifier.ShowMessage("Item Editado com Sucesso", ConsoleColor.Green);
        }

        /*public void ShowMagsinBox() 
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Listagem de Revistas da caixa");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            VisualizeBox(false);

            Console.WriteLine("Digite o Id da caixa a qual deseja inspecionar:");
            int selectedId = int.Parse(Console.ReadLine());

            boxRepo.ShowMagsInBox(selectedId);

            Console.WriteLine();
            Notifier.ShowMessage("Pressione Enter para Continuar...", ConsoleColor.DarkYellow);

        }*/

        public void VisualizeBox(bool showTitle)
        {
            if (showTitle)
            {
                Console.Clear();
                Console.WriteLine("---------------------");
                Console.WriteLine("Caixas Ativas");
                Console.WriteLine("---------------------");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(
            "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo", "Qtd. de Revistas Registradas"
        );
            Box[] registeredBoxes = boxRepo.SelectBoxes();
            

            for (int i = 0; i < registeredBoxes.Length; i++)
            {
                Box b = registeredBoxes[i];

                if (b == null) continue;

                Console.WriteLine(
                    "{0, -6} | {1, -20} | {2, -30} | {3, -30} | {4, -20}", b.Id, b.Tag, b.ColorSelection(b) ,b.MaxBorrowDays, b.AmountOfMagsInBox()
                    );
            }
            Console.WriteLine();
            Notifier.ShowMessage("Pressione Enter para Continuar...", ConsoleColor.DarkYellow);



        }


        public Box GetBoxData()
        {
            Console.WriteLine("Digite o Nome (Etiqueta) da Caixa: ");
            string tag = Console.ReadLine();

            Console.WriteLine("Informe a Cor da Caixa:\n");
            Console.WriteLine("1.Vermelho");
            Console.WriteLine("2.Verde");
            Console.WriteLine("1.Azul");
            Console.WriteLine("1.Amarelo");
            int colour = int.Parse(Console.ReadLine());
            

            Console.WriteLine("Por quanto tempo as revistas dessa caixa poderão ser emprestadas (dias)?: ");
            int maxBorrowDays = int.Parse(Console.ReadLine());

            Box box = new Box(tag, colour, maxBorrowDays);

            return box;

        }
    
    
    
    }
}
