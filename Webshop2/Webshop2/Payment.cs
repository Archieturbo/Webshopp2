using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2.Models;

namespace Webshop2
{
    internal class Payment
    {

        public static void ProcessPayment(List<Product> shoppingCart, decimal totalAmount, MyDbContext db)
        {

            // Visa betalningsmetoder
            ShowPaymentMethods();

            // Låt användaren välja betalningsmetod
            Console.Write("Välj betalningsmetod (1 eller 2): ");
            if (int.TryParse(Console.ReadLine(), out int paymentMethod))
            {
                // Utför betalning baserat på vald metod
                ProcessChosenPaymentMethod(paymentMethod);

                //Console.WriteLine("Totalpriset är: " + totalAmount);
                

                // Ta bort produkterna från databasen efter betalning
                RemoveProductsFromDatabase(shoppingCart, db);

                // Töm varukorgen efter betalning
                shoppingCart.Clear();
                Console.WriteLine("Varukorgen är nu tom.");
            }
            else
            {
                Console.WriteLine("Ogiltigt val.");
            }
        }

        private static void RemoveProductsFromDatabase(List<Product> shoppingCart, MyDbContext db)
        {
            foreach (var product in shoppingCart)
            {
                var productToRemove = db.Product.Find(product.Id);

                if (productToRemove != null)
                {
                    db.Product.Remove(productToRemove);
                }
            }

            db.SaveChanges();

        }


        private static void ShowProducts(List<Product> shoppingCart)
            {
                Console.WriteLine("Produkter i varukorgen:");

                foreach (var product in shoppingCart)
                {
                    Console.WriteLine($"{product.Name}, Pris: {product.Price:C}");
                }
            }

            //private static decimal CalculateTotalPrice(decimal subtotal)
            //{
            //    // Exempel: Lägg till moms och frakt här
            //    decimal taxRate = 0.25m; // 25% moms
            //    decimal shippingCost = 20.0m; // Fraktkostnad

            //    decimal totalPrice = subtotal * (1 + taxRate) + shippingCost;
            //    return totalPrice;
            //}

            private static void ShowPaymentMethods()
            {
                Console.WriteLine("Välj betalningsmetod:");
                Console.WriteLine("1. Kreditkort");
                Console.WriteLine("2. Swish");
            }

            private static void ProcessChosenPaymentMethod(int method)
            {
                switch (method)
                {
                    case 1:
                        Console.WriteLine("Kreditkortsbetalning genomförd.");
                        break;

                    case 2:
                        Console.WriteLine("Swishbetalning genomförd.");
                        break;

                    default:
                        Console.WriteLine("Ogiltig betalningsmetod.");
                        break;
                }
            }
        }


    }

