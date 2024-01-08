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
                Console.WriteLine("Välkommen till webbshoppen!");

                // Visa populära artiklar
                ShowPopularItems();

                // Visa huvudmeny och hantera användarens val
                ShowMainMenu(db);


                Console.ReadLine(); // Håller kvar konsolfönstret öppet tills användaren trycker på Enter.
            }

            static void ShowPopularItems()
            {
                Console.WriteLine("Populära artiklar:");

                var popularItems = new[]
                {
                new { Name = "T-shirt", Price = 452.78, Category = "Herr" },
                new { Name = "Nike Hoodie", Price = 845.56, Category = "Herr" },
                new { Name = "Jeans", Price = 1025.89, Category = "Dam" },
            };

                foreach (var item in popularItems)
                {
                    Console.WriteLine($"{item.Name}, Pris: {item.Price}, Kategori: {item.Category}");
                }
            }

            static void ShowMainMenu(MyDbContext db)
            {
                bool running = true;

                while (running)
                {
                    Console.WriteLine("\nHuvudmeny:");
                    Console.WriteLine($"{(int)Helpers.MenuChoice.ShowAllCategories}. Visa alla kategorier");
                    Console.WriteLine($"{(int)Helpers.MenuChoice.ShowAllProducts}. Visa alla produkter");
                    Console.WriteLine($"{(int)Helpers.MenuChoice.ShowShoppingCart}. Visa varukorg");
                    Console.WriteLine($"{(int)Helpers.MenuChoice.Search}. Sök");
                    Console.WriteLine($"{(int)Helpers.MenuChoice.Pay}. Betala");
                    Console.WriteLine($"{(int)Helpers.MenuChoice.Exit}. Avsluta");

                    Console.Write("Välj ett alternativ: ");
                    string choice = Console.ReadLine();

                    if (Enum.TryParse<Helpers.MenuChoice>(choice, out var menuChoice))
                    {
                        switch (menuChoice)
                        {

                            case Helpers.MenuChoice.ShowAllCategories:
                                Console.Clear();
                                Helpers.ShowAllCategories(db);
                                Console.WriteLine("Visar alla kategorier");
                                break;

                            case Helpers.MenuChoice.ShowAllProducts:
                                Console.Clear();
                                Helpers.ShowAllProducts(db,"herr");
                                //Helpers.ShowproductinCategory(db,"herr");
                                //Helpers.AddToShoppingCartMenu(db);
                                Console.WriteLine("Visar alla produkter");
                                
                                break;

                            case Helpers.MenuChoice.ShowShoppingCart:
                                Console.Clear();
                                Helpers.ShowShoppingCart();
                                Console.WriteLine("Visar varukorgen");
                                break;
                            case Helpers.MenuChoice.Search:
                                Console.Clear();
                                Console.Write("Ange sökterm: ");
                                string searchTerm = Console.ReadLine();
                                Helpers.SearchProducts(db, searchTerm);
                                Console.WriteLine($"Sökresultat för : {searchTerm}");
                                break;

                            case Helpers.MenuChoice.Pay:
                                // Lägg till logik för att betala
                                Console.WriteLine("Betala");
                                break;

                            case Helpers.MenuChoice.Exit:
                                running = false;
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
}