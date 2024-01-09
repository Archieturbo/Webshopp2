using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2.Models;

namespace Webshop2
{
    internal class shippment
    {

        public static void FraktView()
        {
            Console.WriteLine("Fyll i leveransinformation:");

            Console.Write("Namn: ");
            string customerName = Console.ReadLine();

            Console.Write("Adress: ");
            string customerAddress = Console.ReadLine();

            Console.WriteLine("Välj fraktalternativ:");
            Console.WriteLine("1. Postnord - 50 SEK");
            Console.WriteLine("2. DHL - 100 SEK");

            Console.Write("Ange ditt val: ");
            if (int.TryParse(Console.ReadLine(), out int fraktVal))
            {
                decimal fraktPris = 0.0m;

                switch (fraktVal)
                {
                    case 1:
                        fraktPris = 50.0m;
                        break;

                    case 2:
                        fraktPris = 100.0m;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Postnord har valts.");
                        fraktPris = 50.0m; // Standardfrakt som fallback
                        break;
                }

                // Här kan du använda customerName, customerAddress, och fraktPris för att göra vad du vill, t.ex. spara det i din databas eller utföra andra operationer.

                Console.WriteLine($"Frakten är vald: {fraktVal}. Pris: {fraktPris}");
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Postnord har valts.");
            }
        }

    }
}

