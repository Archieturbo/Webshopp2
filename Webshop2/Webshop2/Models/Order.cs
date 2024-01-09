using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2.Models
{
    public class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Shipaddress { get; set; }
        public int? DeliveryId { get; set; }
        public Customer? Customer { get; set; }
        public Delivery? Delivery { get; set; }
        public ICollection<Orderdetail> Orderdetails { get; set; }


        public static void FraktView()
        {
            Console.WriteLine("Fyll i leveransinformation:");

            Console.Write("Namn: ");
            string customerName = Console.ReadLine();

            Console.Write("Adress: ");
            string customerAddress = Console.ReadLine();

            Console.WriteLine("Välj fraktalternativ:");
            Console.WriteLine("1. Standardfrakt - 50 SEK");
            Console.WriteLine("2. Expressfrakt - 100 SEK");

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
                        Console.WriteLine("Ogiltigt val. Standardfrakt har valts.");
                        fraktPris = 50.0m; // Standardfrakt som fallback
                        break;
                }

                // Här kan du använda customerName, customerAddress, och fraktPris för att göra vad du vill, t.ex. spara det i din databas eller utföra andra operationer.

                Console.WriteLine($"Frakten är vald: {fraktVal}. Pris: {fraktPris:C}");
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Standardfrakt har valts.");
            }
        }

        public static void BetalaView(List<Product> shoppingCart)
        {
            Console.WriteLine("Varukorg:");

            if (shoppingCart.Count > 0)
            {
                foreach (var product in shoppingCart)
                {
                    Console.WriteLine($"{product.Name}, Pris: {product.Price}");
                }
            }
            else
            {
                Console.WriteLine("Varukorgen är tom.");
                return;
            }

            Console.WriteLine("---------------------------------");

            // Här kan du lägga till frakt och moms om det behövs
            decimal fraktPris = GetFraktPris(); // Anropa en metod som beräknar fraktpriset
            decimal momsPris = CalculateMoms(shoppingCart); // Anropa en metod som beräknar momsen

            decimal totalPris = CalculateTotalPriceWithFraktAndMoms(shoppingCart, fraktPris, momsPris);

            Console.WriteLine($"Frakt: {fraktPris:C}");
            Console.WriteLine($"Moms: {momsPris:C}");
            Console.WriteLine($"Totalt att betala: {totalPris:C}");

            Console.WriteLine("Välj betalningsmetod:");
            Console.WriteLine("1. Kreditkort");
            Console.WriteLine("2. Swish");

            Console.Write("Ange ditt val: ");
            if (int.TryParse(Console.ReadLine(), out int betalningsMetodVal))
            {
                switch (betalningsMetodVal)
                {
                    case 1:
                        Console.WriteLine("Du har valt Kreditkort. Betalningen är inte på riktigt.");
                        break;

                    case 2:
                        Console.WriteLine("Du har valt Swish. Betalningen är inte på riktigt.");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Standardmetod (Kreditkort) har valts.");
                        break;
                }

                // Här kan du utföra ytterligare åtgärder för att simulera en betalning, t.ex. nollställa varukorgen
                shoppingCart.Clear();
            }
            else
            {
                Console.WriteLine("Ogiltigt val. Standardmetod (Kreditkort) har valts.");
            }
        }

        private static decimal GetFraktPris()
        {
            // Implementera logik för att beräkna fraktpriset här
            // Du kan be användaren ange fraktpriset eller använda en fördefinierad siffra
            return 0.0m; // Just nu returneras 0 som ett exempel
        }

        private static decimal CalculateMoms(List<Product> shoppingCart)
        {
            // Implementera logik för att beräkna momsen här
            // Du kan använda en fast procentsats eller be användaren ange den
            return shoppingCart.Sum(product => product.Price) * 0.25m; // Just nu används en hårdkodad moms på 25%
        }

        private static decimal CalculateTotalPriceWithFraktAndMoms(List<Product> shoppingCart, decimal fraktPris, decimal momsPris)
        {
            // Implementera logik för att beräkna det totala priset inklusive frakt och moms här
            return shoppingCart.Sum(product => product.Price) + fraktPris + momsPris;
        }


    }
}
