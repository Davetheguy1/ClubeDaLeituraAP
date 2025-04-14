using ClubeDaLeituraAP.BoxModule;
using ClubeDaLeituraAP.MagazineModule;
using ClubeDaLeituraAP.Shared;
using ClubeDaLeituraAP.UserModule;
using GestãoDeEquipamentosAP.Shared;

namespace ClubeDaLeituraAP
{
    internal class Program
    {     
        static void Main(string[] args)
        {
            MainMenuScreen mainMenu = new MainMenuScreen();
            mainMenu.MainMenu();
        }
    }
}
