using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAMKI
{
    internal class ScreenManager
    {
        public void ViewMenu()
        {
            Console.WriteLine("Menu wyboru:");
            Console.WriteLine("1 - Tworzenie zakresow");
            Console.WriteLine("2 - Obliczanie dystansu");
            Console.WriteLine("3 - Sortowanie: lon i lat = 0");
            Console.WriteLine("0 - Wyjscie");            
            Console.Write("Wybierz opcję: ");
        }
        /*
        public string GetFilePath()
        {
            Console.WriteLine("Wprowadz sciezke do pliku .txt lub naciśnij 'Enter', aby zakonczyc:");

            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Zakończono program.");
                return string.Empty;
            }
            if (File.Exists(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Podana sciezka do pliku nie istnieje.");
                return string.Empty;
            }
        }
        */
    }
}
