using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Webshop2.Models.Helpers;

namespace Webshop2.Models
{
    class Webshop : Helpers
    {


        private void DisplayProducts()
        {
            using (var db = new MyDbContext())
            {
                var products = db.Product.ToList();

                Console.WriteLine("Produkter:");

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id}. {product.Name} - {product.Price:C}");
                }
            }
        }


        public void Run()
        {
            Console.WriteLine("Välkommen till webbshoppen!");

            while (true)
            {
                Helpers.DisplayMenu();
                var choice = Helpers.GetMenuChoice();

                switch (choice)
                {
                    case MenuChoice.ShowAllProducts:
                        DisplayProducts();
                        break;
                    case MenuChoice.ShowAllCategories:
                        ChooseProduct();
                        break;
                        // ... övriga case ...
                }
            }
        }

        private void ChooseProduct()
        {
            Console.Write("Ange ID för den produkt du vill välja: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                using (var db = new MyDbContext())
                {
                    var selectedProduct = db.Product.Find(productId);

                    if (selectedProduct != null)
                    {
                        Console.WriteLine($"Du har valt produkten: {selectedProduct.Name} - {selectedProduct.Price:C}");
                        // Implementera ytterligare logik för att lägga till produkten i kundkorgen, göra en beställning, etc.
                    }
                    else
                    {
                        Console.WriteLine("Produkten kunde inte hittas.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ogiltigt ID. Försök igen.");
            }
        }
    }
}

