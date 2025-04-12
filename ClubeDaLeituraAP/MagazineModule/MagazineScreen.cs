using ClubeDaLeituraAP.BoxModule;
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

        public MagazineScreen(MagazineRepo magazineRepo, BoxRepo boxRepo, BoxScreen boxScreen)
        {
            this.magazineRepo = magazineRepo;
            this.boxRepo = boxRepo;
            this.boxScreen = boxScreen;
        }

        public void RegisterMagazine()
        {
            Console.Clear();
            Console.WriteLine("---------------------");
            Console.WriteLine("Registrar Nova Revista");
            Console.WriteLine("---------------------");
            Console.WriteLine();

            Magazine newMagazine = GetMagData();
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
            int BoxId = int.Parse(Console.ReadLine());

            //stoped here


        }
    }
}
