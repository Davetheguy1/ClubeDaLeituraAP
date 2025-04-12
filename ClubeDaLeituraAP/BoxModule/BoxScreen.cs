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

        public BoxScreen(BoxRepo boxRepo)
        {
            this.boxRepo = boxRepo;
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

        public void ShowMagsinBox() // stil need mag module to do this one
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Listagem de Conteudos da caixa");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            VisualizeBox(false);

            Console.WriteLine("Digite o Id da caixa a qual deseja inspecionar:");
            int selectedId = int.Parse(Console.ReadLine());

        }

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
            Notifier.ShowMessage("1.Vermelho\n", ConsoleColor.Red);
            Notifier.ShowMessage("2.Verde\n", ConsoleColor.Green);
            Notifier.ShowMessage("3.Azul\n", ConsoleColor.Blue);
            Notifier.ShowMessage("4.Amarelo\n", ConsoleColor.Yellow);
            int colour = int.Parse(Console.ReadLine());
            

            Console.WriteLine("Por quanto tempo as revistas dessa caixa poderão ser emprestadas?: ");
            int maxBorrowDays = int.Parse(Console.ReadLine());

            Box box = new Box(tag, colour, maxBorrowDays);

            return box;

        }
    
    
    
    }
}
