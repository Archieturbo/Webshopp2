using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Webshop2.Models;

namespace Webshop2.Models
{
    public class Helpers
    {

        public static void DisplayMenu()
        {
            Console.WriteLine("Huvudmeny:");
            Console.WriteLine("1. Visa alla kategorier");
            Console.WriteLine("2. Visa alla produkter");
            Console.WriteLine("3. Visa varukorg");
            Console.WriteLine("4. Ändra antal i varukorgen");
            Console.WriteLine("5. Ta bort produkt från varukorgen");
            Console.WriteLine("6. Sök");
            Console.WriteLine("7. Betala");
            Console.WriteLine("8. Avsluta");
            Console.WriteLine("9. Admin");
        }

        public static MenuChoice GetMenuChoice()
        {
            while (true)
            {
                if (Enum.TryParse(Console.ReadLine(), out MenuChoice choice) &&
                    Enum.IsDefined(typeof(MenuChoice), choice))
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
            UpdateQuantity,
            RemoveFromCart,
            Search,
            Pay,
            Exit,
            Admin
        }


        public static void ShowAllCategories(MyDbContext db)
        {
            Console.WriteLine("Alla kategorier:");

            var categories = db.Category.ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"ID: {category.Id}, Kategori: {category.CategoryName}");
            }

            Console.WriteLine("Välj en kategori för att visa produkter (tryck 0 för att gå tillbaka):");
            if (int.TryParse(Console.ReadLine(), out int selectedCategoryId) && selectedCategoryId > 0)
            {

                ShowProductsInCategory(db, selectedCategoryId);
            }
            else
            {
                Console.Clear();
                
            }
        }

        public static void ShowProductsInCategory(MyDbContext db, int categoryId)
        {
            var category = db.Category
                .Include(c => c.Products)
                .FirstOrDefault(c => c.Id == categoryId);

            if (category != null)
            {
                Console.WriteLine($"Produkter i kategorin: {category.CategoryName}");


                foreach (var product in category.Products)
                {
                    switch (category.CategoryName)
                    {
                        case "Herr":
                            Console.WriteLine($"Herr - ID: {product.Id}, Produkt: {product.Name}, Pris: {product.Price}");
                            break;

                        case "Dam":
                            Console.WriteLine($"Dam - ID: {product.Id}, Produkt: {product.Name}, Pris: {product.Price}");
                            break;


                        default:
                            Console.WriteLine($"Junior - ID: {product.Id}, Produkt: {product.Name}, Pris: {product.Price}");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ogiltig kategori. Försök igen.");
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
        public static async Task ShowAllProductsAsync(MyDbContext db, string categories)
        {
            Console.WriteLine($"Alla produkter: ");
            var products = await db.Product.Include(p => p.Categories).ToListAsync();

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}, {product.Name}, " +
                    $"Pris: {product.Price}, " +
                    $"Lager: {product.UnitsInStock}, " +
                    $"Kategori: {Helpers.GetCategoryNames(product.Categories)}");

            }
           
            Console.WriteLine("---------------------------------");
            
        }


        public static async Task ShowProductDetailsAsync(MyDbContext db, int productId)
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
                string addToCartChoice = Console.ReadLine().ToLower();

                if (addToCartChoice == "ja")
                {
                    Shoppingcart.AddToShoppingCartMenu(product);


                }
                if (addToCartChoice == "nej")
                {
                    Console.Clear();
                    Helpers.ShowAllProductsAsync(db, "");
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
        public static void ShowProductMenu(MyDbContext db)
        {
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
                            Task.Run(() => ShowProductDetailsAsync(db, productId)).Wait();

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
                                Console.Write("Ange Antal: ");

                                if (int.TryParse(Console.ReadLine(), out int quantity))
                                {
                                    if (selectedProduct.UnitsInStock > quantity)
                                    {

                                        selectedProduct.UnitsInStock -= quantity;
                                        db.SaveChanges();

                                        for (int i = 0; i < quantity; i++)
                                        {
                                            Shoppingcart.shoppingCart.Add(selectedProduct);
                                        }


                                        Console.WriteLine("Produkten har lagts till i varukorgen.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Antalet finns inte i lager");

                                    }

                                }

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
                        Console.Clear();

                        break;


                }

            }
        }
    }
}