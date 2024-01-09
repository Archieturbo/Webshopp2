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
        public static void ShowShoppingCart()
        {
            Console.WriteLine("Varukorg:");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Name}, Pris: {product.Price}");
            }
            Console.WriteLine("---------------------------------");
        }

        public static void AddToShoppingCartMenu(Product product)
        {

            if (product != null)
            {


                Console.Write("Ange antal: ");

                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    if (product.UnitsInStock > quantity)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            shoppingCart.Add(product);
                        }
                        Console.WriteLine($"{product.Name}, Antal: {quantity} har lagts till i varukorgen");
                    }
                    else
                    {
                        Console.WriteLine("Antalet finns inte i lagret");
                    }

                }



            }
        }
    }
}
