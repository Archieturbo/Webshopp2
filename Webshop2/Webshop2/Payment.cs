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

            
            Console.Write("Välj betalningsmetod (1 eller 2): ");
            if (int.TryParse(Console.ReadLine(), out int paymentMethod))
            {
                // Utför betalning baserat på vald metod
                ProcessChosenPaymentMethod(paymentMethod);

              // sänker kvantitet av produkten
                ReduceUnitsInStock(shoppingCart, db);

                // Töm varukorgen efter betalning
                Shoppingcart.EmptyShoppingCartAfterPurchase();
            }
            else
            {
                Console.WriteLine("Ogiltigt val.");
            }
        }
        private static void ReduceUnitsInStock(List<Product> shoppingCart, MyDbContext db)
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

