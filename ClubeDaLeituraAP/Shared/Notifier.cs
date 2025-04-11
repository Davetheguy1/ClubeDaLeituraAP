using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoDeEquipamentosAP.Shared
{
    public static class Notifier
    {
        public static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();

            Console.ReadLine();
        }

        public static void ShowErrorMessage(string[] errors)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine();

            for (int i = 0; i < errors.Length; i++)
            {
                Console.WriteLine(errors[i]);
            }
            Console.ResetColor();

            Console.Write("Pressione Enter para tentar novamente");
            Console.ReadLine();
        }
    }
}
