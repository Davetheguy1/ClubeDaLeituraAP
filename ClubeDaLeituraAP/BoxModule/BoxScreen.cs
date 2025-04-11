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
            Box newBox = GetBoxData();
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
