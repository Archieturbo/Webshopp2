using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2.Models;

namespace Webshop2
{
    internal class Shoppingcart
    {
        public static List<Product> shoppingCart = new List<Product>();

        public static void AddToShoppingCartMenu(Product product)
        {

            if (product != null)
            {


                Console.Write("Ange antal: ");

                int quantity = int.Parse(Console.ReadLine());
                for (int i = 0; i < quantity; i++)
                {
                    shoppingCart.Add(product);
                }

                Console.WriteLine($"{product.Name}, Antal: {quantity} har lagts till i varukorgen");

            }
        }


        public static void ShowShoppingCart()
        {
            Console.WriteLine("Varukorg:");

            if (shoppingCart.Count > 0)
            {
                foreach (var product in shoppingCart)
                {
                    Console.WriteLine($"{product.Name}, Pris: {product.Price:C}");
                }
            }
            else
            {
                Console.WriteLine("Varukorgen är tom.");
            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Totalt pris: {CalculateTotalPrice()}");
            Console.WriteLine("---------------------------------");
        }

        public static void UpdateQuantityInShoppingCart()
        {
            Console.Write("Ange namnet på produkten du vill ändra antal för: ");
            string productName = Console.ReadLine();

            var productToUpdate = shoppingCart.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (productToUpdate != null)
            {
                Console.Write("Ange det nya antalet: ");
                if (int.TryParse(Console.ReadLine(), out int newQuantity))
                {
                    // Ta bort de befintliga produkterna från varukorgen
                    shoppingCart.RemoveAll(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

                    // Lägg till de nya produkterna i varukorgen
                    for (int i = 0; i < newQuantity; i++)
                    {
                        shoppingCart.Add(productToUpdate);
                    }

                    Console.WriteLine("Antalet har uppdaterats i varukorgen.");
                }
                else
                {
                    Console.WriteLine("Ogiltigt antal. Försök igen.");
                }
            }
            else
            {
                Console.WriteLine("Produkten hittades inte i varukorgen.");
            }
        }


        public static void RemoveFromShoppingCart()
        {
            Console.Write("Ange namnet på en produkt du vill ta bort från varukorgen: ");
            string productName = Console.ReadLine();

            var productToRemove = shoppingCart.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (productToRemove != null)
            {
                shoppingCart.Remove(productToRemove);
                Console.WriteLine("Produkten har tagits bort från varukorgen.");
            }
            else
            {
                Console.WriteLine("Produkten hittades inte i varukorgen.");
            }
        }

        private static decimal CalculateTotalPrice()
        {

            return (decimal)(shoppingCart.Sum(p => p.Price) ?? 0.0);
        }

    }
}
