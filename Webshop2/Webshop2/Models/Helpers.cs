using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Webshop2.Models
{
    public class Helpers
    {
        private static List<Product> shoppingCart = new List<Product>();

        public static void DisplayMenu()
        {
            Console.WriteLine("Välj ett alternativ:");
            foreach (var menuChoice in Enum.GetValues(typeof(MenuChoice)))
            {
                Console.WriteLine($"{(int)menuChoice}. {menuChoice}");
            }
        }

        public static MenuChoice GetMenuChoice()
        {
            while (true)
            {
                if (Enum.TryParse(Console.ReadLine(), out MenuChoice choice))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                }
            }
        }

        public enum MenuChoice
        {
            ShowAllCategories = 1,
            ShowAllProducts,
            ShowShoppingCart,
            Pay,
            Search,
            Exit
        }

        public enum ChooseSize
        {
            Large = 1,
            Medium,
            Small,
        }

        public static void ShowAllCategories(MyDbContext db)
        {
            Console.WriteLine("Alla kategorier:");

            var categories = db.Category.ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"ID: {category.Id}, Kategori: {category.CategoryName}");
            }
        }
        public static string GetCategoryNames(ICollection<Category> categories)
        {
            if (categories == null || categories.Count == 0)
            {
                return "Inga kategorier tillgängliga";
            }

            var categoryNames = categories.Select(category => category.CategoryName);
            return string.Join(", ", categoryNames);
        }
        public static void ShowAllProducts(MyDbContext db, string categories)
        {
            Console.WriteLine($"Alla produkter: ");
            var products = db.Product.Include(p => p.Categories).ToList();

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, {product.Name}, " +
                    $"Pris: {product.Price}, " +
                    $"Lager: {product.UnitsInStock}, " +
                    $"Kategorier: {Helpers.GetCategoryNames(product.Categories)}");

            }

            Console.WriteLine("---------------------------------");
            Console.WriteLine("1. Visa detaljer för en produkt");
            Console.WriteLine("2. Lägg till i varukorgen");
            Console.WriteLine("3. Tillbaka till huvudmenyn");
            Console.Write("Ange ditt val: ");
            string actionChoice = Console.ReadLine();

            if (int.TryParse(actionChoice, out int action))
            {

                switch (action)
                {
                    case 1:

                        Console.Write("Ange ID för produkten du vill visa detaljer för: ");
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            Console.Clear();
                            ShowProductDetails(db, productId);

                        }

                        else
                        {
                            Console.WriteLine("Ogiltigt ID. Ange ett numeriskt värde.");
                        }
                        break;

                    case 2:

                        Console.Write("Ange ID för produkten du vill lägga till i varukorgen: ");
                        if (int.TryParse(Console.ReadLine(), out int selectedProductId))
                        {
                            var selectedProduct = db.Product.Find(selectedProductId);
                            if (selectedProduct != null)
                            {
                                Helpers.AddToShoppingCart(selectedProduct);
                                Console.WriteLine("Produkten har lagts till i varukorgen.");
                            }
                            else
                            {
                                Console.WriteLine("Produkt med angivet ID hittades inte.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt ID. Ange ett numeriskt värde.");
                        }
                        break;
                    case 3:
                        return;


                }

            }
        }

        public static void ShowShoppingCart()
        {
            Console.WriteLine("Varukorg:");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"{product.Name}, Pris: {product.Price}");
            }
            Console.WriteLine("---------------------------------");
        }

        public static void AddToShoppingCart(Product product)
        {

            shoppingCart.Add(product);

        }

        public static void AddToShoppingCartMenu(MyDbContext db)
        {
            while (true)
            {

                Console.Write("Ange ID för produkten du vill lägga till i varukorgen (eller 0 för att gå tillbaka): ");
                if (int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.Clear();
                    if (productId == 0)
                    {
                        return; // Gå tillbaka till huvudmenyn
                    }

                    var product = db.Product.Find(productId);
                    if (product != null)
                    {
                        Console.Write("Välj storlek");

                        Console.WriteLine("1.small");
                        Console.WriteLine("2. Medium");
                        Console.WriteLine("3.Large");
                        int SizeChoose = int.Parse(Console.ReadLine());
                        switch (SizeChoose)
                        {
                            case 1:
                                AddToShoppingCart(product, ChooseSize.Small);
                                Console.WriteLine("Small");
                                break;
                            case 2:
                                Console.WriteLine("Medium");
                                break;
                            case 3:
                                Console.WriteLine("Large");
                                break;

                        }

                        AddToShoppingCart(product);
                        Console.WriteLine("Produkten har lagts till i varukorgen.");
                    }
                    else
                    {
                        Console.WriteLine("Produkt med angivet ID hittades inte.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt ID. Ange ett numeriskt värde.");
                }
            }
        }

        public static void ShowProductDetails(MyDbContext db, int productId)
        {
            var product = db.Product.Find(productId);

            if (product != null)
            {
                Console.WriteLine($"ProduktID: {product.Id}");
                Console.WriteLine($" {product.Name}");
                Console.WriteLine($"Pris: {product.Price}");
                Console.WriteLine($"Färg: {product.Color}");
                Console.WriteLine($"Beskrivning: {product.Description}");
                Console.WriteLine($"Lagerstatus: {product.UnitsInStock}");

                Console.WriteLine("Vill du lägga till produkten i varukorgen? (Ja/Nej)");
                string addToCartChoice = Console.ReadLine();

                if (addToCartChoice == "ja")
                {
                    AddToShoppingCart(product);
                    Console.WriteLine($"{product.Name} har lagts till i varukorgen");
                }
                if (addToCartChoice == "nej")
                {
                    Console.Clear();
                    Helpers.ShowAllProducts(db, "herr");
                }
            }
            else
            {
                Console.WriteLine("Produkt med angivet ID hittades inte.");
            }
        }


        public static void SearchProducts(MyDbContext db, string searchTerm)
        {
            var matchingProducts = db.Product
                .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
                .ToList();

            Console.WriteLine($"Sökresultat för: {searchTerm}");

            foreach (var product in matchingProducts)
            {
                Console.WriteLine($"ID: {product.Id}, Namn: {product.Name}, Pris: {product.Price}");
                Console.WriteLine($"Beskrivning: {product.Description}");
            }
        }
    }
}








//     using (var db = new MyDbContext())
//        {
//            var ForMen = new Category { CategoryName = "Herr" };
//var ForWomen = new Category { CategoryName = "Dam" };
//var ForJunior = new Category { CategoryName = "Junior" };

//var supplier1 = new Supplier
//{
//    CompanyName = "Fashion Suppliers AB",
//    Country = "Sweden",
//    City = "Stockholm",
//    Address = "Gillerbacken 67",
//    Phone = "+46-7454-7890",
//};
//var supplier2 = new Supplier
//{
//    CompanyName = "Style Trends AB",
//    Country = "Sweden",
//    City = "Gothenburg",
//    Address = "Backa Bergögata 1",
//    Phone = "+46-745-354",
//};
//var supplier3 = new Supplier
//{
//    CompanyName = "Scandinavian Fashion AB",
//    Country = "Norway",
//    City = "Oslo",
//    Address = "Dronning Eufemias gate 15, 0194 Oslo, Norge",
//    Phone = "+47-714-653",
//};

//var product1 = new Product
//{
//    Name = "T-shirt",
//    Price = 452.78,
//    Color = "Vit",
//    UnitsInStock = 5,
//    Categories = new List<Category> { ForMen },
//    Supplier = supplier1,
//    Description = "En bekväm vit T-shirt för herr med klassisk design."
//};

//var product2 = new Product
//{
//    Name = "Nike Hoodie",
//    Price = 845.56,
//    Color = "Svart",
//    UnitsInStock = 15,
//    Categories = new List<Category> { ForMen },
//    Supplier = supplier3,
//    Description = "En svart Nike Hoodie för herr med sportig och modern design."
//};

//var product3 = new Product
//{
//    Name = "Jeans",
//    Price = 1025.89,
//    Color = "Blå",
//    UnitsInStock = 8,
//    Categories = new List<Category> { ForMen, ForWomen },
//    Supplier = supplier3,
//    Description = "Stiliga blå jeans med perfekt passform. Tillverkade med högkvalitativt material för optimal komfort."
//};

//var product4 = new Product
//{
//    Name = "Skjorta",
//    Price = 743.89,
//    Color = "Vit",
//    UnitsInStock = 18,
//    Categories = new List<Category> { ForMen },
//    Supplier = supplier2,
//    Description = "En elegant vit skjorta för herr med snygg design och hög kvalitet."
//};

//var product5 = new Product
//{
//    Name = "Mjukis Byxa",
//    Price = 804.79,
//    Color = "Grå",
//    UnitsInStock = 7,
//    Categories = new List<Category> { ForMen },
//    Supplier = supplier2,
//    Description = "Sköna grå mjukisbyxor för herr. Perfekta för avslappnade dagar."
//};

//var product6 = new Product
//{
//    Name = "Klänning",
//    Price = 501.79,
//    Color = "Röd",
//    UnitsInStock = 10,
//    Categories = new List<Category> { ForWomen },
//    Supplier = supplier2,
//    Description = "Elegant röd klänning för damer. Passar för olika tillfällen och evenemang."
//};

//var product7 = new Product
//{
//    Name = "Kjol",
//    Price = 899.74,
//    Color = "Svart",
//    UnitsInStock = 8,
//    Categories = new List<Category> { ForWomen },
//    Supplier = supplier3,
//    Description = "Svart kjol med modern och stilren design för damer."
//};

//var product8 = new Product
//{
//    Name = "Stickad tröja",
//    Price = 401.66,
//    Color = "Lila",
//    UnitsInStock = 9,
//    Categories = new List<Category> { ForWomen },
//    Supplier = supplier3,
//    Description = "Lila stickad tröja för damer. Håller dig varm och bekväm."
//};

//var product9 = new Product
//{
//    Name = "Leggings",
//    Price = 456.99,
//    Color = "Gul",
//    UnitsInStock = 15,
//    Categories = new List<Category> { ForWomen },
//    Supplier = supplier1,
//    Description = "Gula leggings med snygg passform och hög komfort för damer."
//};

//var product10 = new Product
//{
//    Name = "Kappa",
//    Price = 1596.78,
//    Color = "Svart",
//    UnitsInStock = 10,
//    Categories = new List<Category> { ForWomen },
//    Supplier = supplier1,
//    Description = "Svart kappa för damer med elegant och tidlös design."
//};

//var product11 = new Product
//{
//    Name = "Spiderman Onepiece",
//    Price = 701.32,
//    Color = "Röd",
//    UnitsInStock = 8,
//    Categories = new List<Category> { ForJunior },
//    Supplier = supplier3,
//    Description = "Röd Spiderman Onepiece för juniors. Perfekt för lekfulla äventyr."
//};

//var product12 = new Product
//{
//    Name = "Overall",
//    Price = 369.94,
//    Color = "Orange",
//    UnitsInStock = 4,
//    Categories = new List<Category> { ForJunior },
//    Supplier = supplier2,
//    Description = "Orange overall för juniors. Praktisk och bekväm."
//};

//var product13 = new Product
//{
//    Name = "Shorts",
//    Price = 701.32,
//    Color = "Brun",
//    UnitsInStock = 8,
//    Categories = new List<Category> { ForJunior, ForMen },
//    Supplier = supplier3,
//    Description = "Bruna shorts för juniors och herrar. Perfekta för varma dagar."
//};

//var product14 = new Product
//{
//    Name = "Väst",
//    Price = 843.00,
//    Color = "Turkos",
//    UnitsInStock = 6,
//    Categories = new List<Category> { ForJunior },
//    Supplier = supplier2,
//    Description = "Turkos väst för juniors. Stilfull och trendig."
//};

//var product15 = new Product
//{
//    Name = "Overshirt",
//    Price = 276.84,
//    Color = "Beige",
//    UnitsInStock = 13,
//    Categories = new List<Category> { ForJunior },
//    Supplier = supplier1,
//    Description = "Beige overshirt för juniors. Perfekt för avslappnade stunder."
//};

//db.AddRange(product1, product2, product3, product4, product5, product6, product7, product8, product9, product10,
//             product11, product12, product13, product14, product15);
//            db.SaveChanges();


