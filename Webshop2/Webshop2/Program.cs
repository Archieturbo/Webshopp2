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
                            break;

                        case Helpers.MenuChoice.ShowAllProducts:
                            Console.Clear();
                            Helpers.ShowAllProducts(db, "");
                            Helpers.ShowProductMenu(db);
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
                            Console.WriteLine($"Sökresultat för: {searchTerm}");
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
                            Customer customerinfo = shippment.GetCustomerInfo();
                            Delivery delivery = shippment.SelectShippingMethod();
                            shippment.PlaceOrder(customerinfo, delivery.Price, delivery);
                            decimal totalAmount = Shoppingcart.CalculateTotalPrice();
                            Payment.ProcessPayment(shoppingCart, totalAmount, db);
                            break;
                        case Helpers.MenuChoice.Admin:
                            Console.Clear();
                            Admin.AddNewProductMenu();
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
           
            



        

    













//Problem som måste lösas!
///5. Hela admindelen är kvar 









//Problem som måste lösas!
//1. Koppla rätt databaser mellan varandra Även fast man lägger i varukorgen så är antalet detsamma. 
//2. Behöver ändra så det står id när man tar bort id istället för att skriva namnet på plagget
//3. Kolla igenom frakt view delen för den länkas inte på rätt sätt
//4. Betala view funkar inte än.
//5. Hela admindelen är kvar 
