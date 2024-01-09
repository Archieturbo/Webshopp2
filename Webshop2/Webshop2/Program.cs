using Microsoft.EntityFrameworkCore;
using Webshop2.Models;

namespace Webshop2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new MyDbContext())
            //{
            //    Console.WriteLine("Välkommen till webbshoppen!");

            //    // Visa populära artiklar
            //    ShowPopularItems();

            //    // Visa huvudmeny och hantera användarens val
            //    ShowMainMenu(db);


            //    Console.ReadLine(); // Håller kvar konsolfönstret öppet tills användaren trycker på Enter.
            //}

            //static void ShowPopularItems()
            //{
            //    Console.WriteLine("Populära artiklar:");

            //    var popularItems = new[]
            //    {
            //        new { Name = "T-shirt", Price = 452.78, Category = "Herr" },
            //        new { Name = "Nike Hoodie", Price = 845.56, Category = "Herr" },
            //        new { Name = "Jeans", Price = 1025.89, Category = "Dam" },
            //    };

            //    foreach (var item in popularItems)
            //    {
            //        Console.WriteLine($"{item.Name}, Pris: {item.Price}, Kategori: {item.Category}");
            //    }
            //}

            //static void ShowMainMenu(MyDbContext db)
            //{
            //    bool running = true;

            //    while (running)
            //    {
            //        Console.WriteLine("\nHuvudmeny:");
            //        Console.WriteLine($"{(int)Helpers.MenuChoice.ShowAllCategories}. Visa alla kategorier");
            //        Console.WriteLine($"{(int)Helpers.MenuChoice.ShowAllProducts}. Visa alla produkter");
            //        Console.WriteLine($"{(int)Helpers.MenuChoice.ShowShoppingCart}. Visa varukorg");
            //        Console.WriteLine($"{(int)Helpers.MenuChoice.UpdateQuantity}. Ändra antal i varukorgen");
            //        Console.WriteLine($"{(int)Helpers.MenuChoice.RemoveFromCart}. Ta bort produkt från varukorgen");
            //        Console.WriteLine($"{(int)Helpers.MenuChoice.Search}. Sök");
            //        Console.WriteLine($"{(int)Helpers.MenuChoice.Pay}. Betala");
            //        Console.WriteLine($"{(int)Helpers.MenuChoice.Exit}. Avsluta");

            //        Console.Write("Välj ett alternativ: ");
            //        string choice = Console.ReadLine();

            //        if (Enum.TryParse<Helpers.MenuChoice>(choice, out var menuChoice))
            //        {
            //            switch (menuChoice)
            //            {

            //                case Helpers.MenuChoice.ShowAllCategories:
            //                    Console.Clear();
            //                    Helpers.ShowAllCategories(db);
            //                    Console.WriteLine("Visar alla kategorier");
            //                    break;

            //                case Helpers.MenuChoice.ShowAllProducts:
            //                    Console.Clear();
            //                    Helpers.ShowAllProducts(db, "herr");
            //                    //Helpers.ShowproductinCategory(db,"herr");
            //                    //Helpers.AddToShoppingCartMenu(db);
            //                    //Console.WriteLine("Visar alla produkter");

            //                    break;

            //                case Helpers.MenuChoice.ShowShoppingCart:
            //                    Console.Clear();
            //                    Shoppingcart.ShowShoppingCart();
            //                    Console.WriteLine("Visar varukorgen");
            //                    break;
            //                case Helpers.MenuChoice.Search:
            //                    Console.Clear();
            //                    Console.Write("Ange sökterm: ");
            //                    string searchTerm = Console.ReadLine();
            //                    Helpers.SearchProducts(db, searchTerm);
            //                    Console.WriteLine($"Sökresultat för : {searchTerm}");
            //                    break;
            //                case Helpers.MenuChoice.UpdateQuantity:
            //                    Console.Clear();
            //                    Shoppingcart.UpdateQuantityInShoppingCart();
            //                    break;
            //                case Helpers.MenuChoice.RemoveFromCart:
            //                    Console.Clear();
            //                    Shoppingcart.RemoveFromShoppingCart();
            //                    break;

            //                case Helpers.MenuChoice.Pay:
            //                    Console.Clear();
            //                    Order order = new Order();
            //                    shippment.FraktView();
            //                    //shippment.BetalaView();
            //                    // Lägg till logik för att betala
            //                    Console.WriteLine("Betala");
            //                    break;

            //                case Helpers.MenuChoice.Exit:
            //                    running = false;
            //                    break;

            //                default:
            //                    Console.WriteLine("Ogiltigt val. Försök igen.");
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("Ogiltigt val. Försök igen.");
            //        }
            //    }
            //}

            using (var db = new MyDbContext())
            {
                var ForMen = new Category { CategoryName = "Herr" };
                var ForWomen = new Category { CategoryName = "Dam" };
                var ForJunior = new Category { CategoryName = "Junior" };

                var supplier1 = new Supplier
                {
                    CompanyName = "Fashion Suppliers AB",
                    Country = "Sweden",
                    City = "Stockholm",
                    Address = "Gillerbacken 67",
                    Phone = "+46-7454-7890",
                };
                var supplier2 = new Supplier
                {
                    CompanyName = "Style Trends AB",
                    Country = "Sweden",
                    City = "Gothenburg",
                    Address = "Backa Bergögata 1",
                    Phone = "+46-745-354",
                };
                var supplier3 = new Supplier
                {
                    CompanyName = "Scandinavian Fashion AB",
                    Country = "Norway",
                    City = "Oslo",
                    Address = "Dronning Eufemias gate 15, 0194 Oslo, Norge",
                    Phone = "+47-714-653",
                };

                var product1 = new Product
                {
                    Name = "T-shirt",
                    Price = 452.78,
                    Color = "Vit",
                    UnitsInStock = 5,
                    Categories = new List<Category> { ForMen },
                    CategoryId = 1,
                    Supplier = supplier1,
                    Description = "En bekväm vit T-shirt för herr med klassisk design."
                };

                var product2 = new Product
                {
                    Name = "Nike Hoodie",
                    Price = 845.56,
                    Color = "Svart",
                    UnitsInStock = 15,
                    Categories = new List<Category> { ForMen },
                    CategoryId = 1,
                    Supplier = supplier3,
                    Description = "En svart Nike Hoodie för herr med sportig och modern design."
                };

                var product3 = new Product
                {
                    Name = "Jeans",
                    Price = 1025.89,
                    Color = "Blå",
                    UnitsInStock = 8,
                    Categories = new List<Category> { ForMen, ForWomen },
                    CategoryId = 2,
                    Supplier = supplier3,
                    Description = "Stiliga blå jeans med perfekt passform. Tillverkade med högkvalitativt material för optimal komfort."
                };

                var product4 = new Product
                {
                    Name = "Skjorta",
                    Price = 743.89,
                    Color = "Vit",
                    UnitsInStock = 18,
                    Categories = new List<Category> { ForMen },
                    CategoryId = 1,
                    Supplier = supplier2,
                    Description = "En elegant vit skjorta för herr med snygg design och hög kvalitet."
                };

                var product5 = new Product
                {
                    Name = "Mjukis Byxa",
                    Price = 804.79,
                    Color = "Grå",
                    UnitsInStock = 7,
                    Categories = new List<Category> { ForMen },
                    CategoryId = 1,
                    Supplier = supplier2,
                    Description = "Sköna grå mjukisbyxor för herr. Perfekta för avslappnade dagar."
                };

                var product6 = new Product
                {
                    Name = "Klänning",
                    Price = 501.79,
                    Color = "Röd",
                    UnitsInStock = 10,
                    Categories = new List<Category> { ForWomen },
                    CategoryId = 2,
                    Supplier = supplier2,
                    Description = "Elegant röd klänning för damer. Passar för olika tillfällen och evenemang."
                };

                var product7 = new Product
                {
                    Name = "Kjol",
                    Price = 899.74,
                    Color = "Svart",
                    UnitsInStock = 8,
                    Categories = new List<Category> { ForWomen },
                    CategoryId = 2,
                    Supplier = supplier3,
                    Description = "Svart kjol med modern och stilren design för damer."
                };

                var product8 = new Product
                {
                    Name = "Stickad tröja",
                    Price = 401.66,
                    Color = "Lila",
                    UnitsInStock = 9,
                    Categories = new List<Category> { ForWomen },
                    CategoryId = 2,
                    Supplier = supplier3,
                    Description = "Lila stickad tröja för damer. Håller dig varm och bekväm."
                };

                var product9 = new Product
                {
                    Name = "Leggings",
                    Price = 456.99,
                    Color = "Gul",
                    UnitsInStock = 15,
                    Categories = new List<Category> { ForWomen },
                    CategoryId = 2,
                    Supplier = supplier1,
                    Description = "Gula leggings med snygg passform och hög komfort för damer."
                };

                var product10 = new Product
                {
                    Name = "Kappa",
                    Price = 1596.78,
                    Color = "Svart",
                    UnitsInStock = 10,
                    Categories = new List<Category> { ForWomen },
                    CategoryId = 2,
                    Supplier = supplier1,
                    Description = "Svart kappa för damer med elegant och tidlös design."
                };

                var product11 = new Product
                {
                    Name = "Spiderman Onepiece",
                    Price = 701.32,
                    Color = "Röd",
                    UnitsInStock = 8,
                    Categories = new List<Category> { ForJunior },
                    CategoryId = 3,
                    Supplier = supplier3,
                    Description = "Röd Spiderman Onepiece för juniors. Perfekt för lekfulla äventyr."
                };

                var product12 = new Product
                {
                    Name = "Overall",
                    Price = 369.94,
                    Color = "Orange",
                    UnitsInStock = 4,
                    Categories = new List<Category> { ForJunior },
                    CategoryId = 3,
                    Supplier = supplier2,
                    Description = "Orange overall för juniors. Praktisk och bekväm."
                };

                var product13 = new Product
                {
                    Name = "Shorts",
                    Price = 701.32,
                    Color = "Brun",
                    UnitsInStock = 8,
                    Categories = new List<Category> { ForJunior, ForMen },
                    CategoryId = 3,
                    Supplier = supplier3,
                    Description = "Bruna shorts för juniors och herrar. Perfekta för varma dagar."
                };

                var product14 = new Product
                {
                    Name = "Väst",
                    Price = 843.00,
                    Color = "Turkos",
                    UnitsInStock = 6,
                    Categories = new List<Category> { ForJunior },
                    CategoryId = 3,
                    Supplier = supplier2,
                    Description = "Turkos väst för juniors. Stilfull och trendig."
                };

                var product15 = new Product
                {
                    Name = "Overshirt",
                    Price = 276.84,
                    Color = "Beige",
                    UnitsInStock = 13,
                    Categories = new List<Category> { ForJunior },
                    CategoryId = 3,
                    Supplier = supplier1,
                    Description = "Beige overshirt för juniors. Perfekt för avslappnade stunder."
                };

                db.AddRange(product1, product2, product3, product4, product5, product6, product7, product8, product9, product10,
                             product11, product12, product13, product14, product15);
                db.SaveChanges();

                var delivery = new Delivery
                {
                    Name = "Postnord",
                    Price = 50,
                };
                var delivery2 = new Delivery
                {
                    Name = "DHL",
                    Price = 100,
                };
                db.AddRange(delivery, delivery2);
                db.SaveChanges();
            }



        }

    }
}
        
    

    //Problem som måste lösas!
    //1. Koppla rätt databaser mellan varandra Även fast man lägger i varukorgen så är antalet detsamma. 
    //2. Behöver ändra så det står id när man tar bort id istället för att skriva namnet på plagget
    //3. Kolla igenom frakt view delen för den länkas inte på rätt sätt
    //4. Betala view funkar inte än.
    //5. Hela admindelen är kvar 
