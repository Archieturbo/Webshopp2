using Microsoft.EntityFrameworkCore;
using Webshop2.Models;

namespace Webshop2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                Console.WriteLine("Välkommen till webbshopen!");
                Console.WriteLine();
                ShowPopularItems();
                ShowMainMenu(db);

                Console.ReadLine();
            }


        }


        public static void ShowPopularItems()
        {
            Console.WriteLine("Populära artiklar:");

            using (var db = new MyDbContext())
            {
                var popularItems = db.Product
                    .Where(p => p.IsPopular)
                    .Include(p => p.Categories)
                    .ToList();

                foreach (var item in popularItems)
                {
                    Console.Write($"{item.Name}, Pris: {item.Price}, Kategori: ");

                    foreach(var category in item.Categories)
                    {
                        Console.Write($"{category.CategoryName} ");
                    }
                    Console.WriteLine();
                }
            }
        }


        public static void ShowMainMenu(MyDbContext db)
        {
            bool running = true;
            List<Product> shoppingCart = new List<Product>();

            while (running)
            {
                Console.WriteLine("\nHuvudmeny:");
                Console.WriteLine("1. Visa alla kategorier");
                Console.WriteLine("2. Visa alla produkter");
                Console.WriteLine("3. Visa varukorg");
                Console.WriteLine("4. Ändra antal i varukorgen");
                Console.WriteLine("5. Ta bort produkt från varukorgen");
                Console.WriteLine("6. Sök");
                Console.WriteLine("7. Betala");
                Console.WriteLine("8. Avsluta");
                Console.WriteLine("9. Admin");

                Console.Write("Välj ett alternativ: ");
                string choice = Console.ReadLine();

                if (Enum.TryParse<Helpers.MenuChoice>(choice, out var menuChoice))
                {
                    switch (menuChoice)
                    {
                        case Helpers.MenuChoice.ShowAllCategories:
                            Console.Clear();
                            Helpers.ShowAllCategories(db);
                            Helpers.ShowProductMenu(db);
                            Thread.Sleep(3000);
                            Console.Clear();
                            ShowPopularItems();
                            break;

                        case Helpers.MenuChoice.ShowAllProducts:
                            Console.Clear();
                            Task.Run(() => Helpers.ShowAllProductsAsync(db, "")).Wait();
                            Helpers.ShowProductMenu(db);
                            Thread.Sleep(3000);
                            Console.Clear();
                            ShowPopularItems();
                            break;

                        case Helpers.MenuChoice.ShowShoppingCart:
                            Console.Clear();
                            Shoppingcart.ShowShoppingCart();
                            Console.WriteLine("Visar varukorgen");
                            break;

                        case Helpers.MenuChoice.Search:
                            Console.Clear();
                            Console.Write("Ange sökterm: ");
                            string searchTerm = Console.ReadLine();
                            Helpers.SearchProducts(db, searchTerm);
                            Helpers.ShowProductMenu(db);
                            ShowPopularItems();
                            break;

                        case Helpers.MenuChoice.UpdateQuantity:
                            Console.Clear();
                            Shoppingcart.UpdateQuantityInShoppingCart();
                            break;

                        case Helpers.MenuChoice.RemoveFromCart:
                            Console.Clear();
                            Shoppingcart.RemoveFromShoppingCart();
                            break;

                        case Helpers.MenuChoice.Pay:
                            Console.Clear();
                            if (Shoppingcart.shoppingCart.Count > 0)
                            {


                                Customer customerinfo = shippment.GetCustomerInfo();
                                Delivery delivery = shippment.SelectShippingMethod();
                                shippment.PlaceOrder(customerinfo, delivery.Price, delivery);
                                decimal totalAmount = Shoppingcart.CalculateTotalPrice();
                                Payment.ProcessPayment(shoppingCart, totalAmount, db);
                            }
                            else
                            {
                                Console.WriteLine("kontrollera varukorgen att den inte är tom");
                            }
                            break;
                        case Helpers.MenuChoice.Admin:
                            Console.Clear();
                            Admin.AddNewProductMenu();                          
                            break;

                        case Helpers.MenuChoice.Exit:
                            running = false;
                            Console.WriteLine("Webshopen stänger ner, ha en trevlig dag! :)");
                            break;


                        default:
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }


        }

    }
}



























