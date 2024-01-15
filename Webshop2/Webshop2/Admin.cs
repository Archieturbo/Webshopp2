using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2.Models;

namespace Webshop2
{  //Lägg till savechanges nånstans! 
    internal class Admin
    {
        private static int productId;
        public static void ChangeProductCategory(int productId, int categoryId)
        {
            using (var db = new MyDbContext())
            {
                // Hämta produkten från databasen
                var product = db.Product.FirstOrDefault(p => p.Id == productId);

                // Kontrollera om produkten hittades
                if (product == null)
                {
                    Console.WriteLine("Produkten har lagts till");
                    return;
                }

                // Kontrollera om kategori-ID:t finns i databasen
                var category = db.Category.FirstOrDefault(c => c.Id == categoryId);
                if (category == null)
                {
                    Console.WriteLine("Den angivna produktkategorin finns inte.");
                    return;
                }

                // Sätt produktens kategori-ID till det angivna värdet
                product.CategoryId = categoryId;

                // Spara ändringarna i databasen
                db.SaveChanges();

                Console.WriteLine($"Produktens kategori har ändrats till {category.CategoryName}.");
            }
        }


        public static void AddNewProductMenu()
        {
            using (var db = new MyDbContext())
            {

                Console.WriteLine("1. Lägg till ny produkt");
                Console.WriteLine("2. Ändra produkt");
                Console.WriteLine("3. Ta bort produkt");
                Console.WriteLine("4. Ändra uppgifter om kunden/Historik");
                Console.WriteLine("5. Butiksstatus");
                Console.WriteLine("6. Tillbaka till huvudmenyn");
                Console.Write("Ange ditt val: ");
                string subchoice = Console.ReadLine();

                if (subchoice == "1")
                {
                    Console.WriteLine("Lägg till namn på produkten: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Lägg till pris: ");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("Lägg till färg: ");
                    string color = Console.ReadLine();
                    Console.WriteLine("Lägg till lagersaldo: ");
                    int unitsInStock = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ange vilken kategori den tillhör (Herr: 1, Dam: 2, Junior: 3): ");
                    var categoryId = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ange leverantör: Fashion Supplier AB 1, Scandinavian Fashion AB 2, Style Trends Ab 3");
                    var supplierId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ange en kort beskrivning om produkten: ");
                    string description = Console.ReadLine();

                    var product1 = new Product
                    {
                        Name = name,
                        Price = price,
                        Color = color,
                        UnitsInStock = unitsInStock,
                        SupplierId = supplierId,
                        Description = description,
                        CategoryId = categoryId
                    };

                    var category = db.Category.Find(categoryId);
                    if (category != null)
                    {
                        product1.Categories.Add(category);
                    }

                    db.Add(product1);
                    db.SaveChanges();

                    ChangeProductCategory(productId, categoryId);


                }


                if (subchoice == "2")
                {
                    while (true)
                    {
                        Helpers.ShowAllProducts(db, subchoice);
                        Console.WriteLine("Ange produkt-ID (eller 0 för att avsluta): ");
                        int productId = int.Parse(Console.ReadLine());

                        if (productId == 0)
                        {
                            // Avsluta loopen om användaren väljer 0
                            break;
                        }

                        // Hämta produkten från databasen
                        Product product = db.Product.FirstOrDefault(p => p.Id == productId);

                        if (product == null)
                        {
                            Console.WriteLine("Produkten med det angivna ID:t hittades inte.");

                        }
                        while (true)
                        {
                            Console.WriteLine("1. Ändra produktnamn");
                            Console.WriteLine("2. Ändra infotext");
                            Console.WriteLine("3. Ändra pris");
                            Console.WriteLine("4. Ändra produktkategori");
                            Console.WriteLine("5. Ändra leverantör");
                            Console.WriteLine("6. Ändra lagersaldo");
                            Console.WriteLine("7. Tillbaka till huvudmenyn");
                            Console.Write("Ange ditt val: ");
                            subchoice = Console.ReadLine();

                            switch (subchoice)
                            {
                                case "1":
                                    Console.Write("Ange nytt produktnamn: ");
                                    product.Name = Console.ReadLine();
                                    break;
                                case "2":
                                    Console.Write("Ange ny infotext: ");
                                    product.Description = Console.ReadLine();
                                    break;
                                case "3":

                                    Console.Write("Ange nytt pris: ");
                                    product.Price = double.Parse(Console.ReadLine());
                                    break;
                                case "4":

                                    Console.Write("Ange ny produktkategori: ");
                                    product.CategoryId = int.Parse(Console.ReadLine());
                                    break;
                                case "5":

                                    Console.Write("Ange ny leverantör: ");
                                    product.SupplierId = int.Parse(Console.ReadLine());
                                    break;
                                case "6":

                                    Console.Write("Ange nytt lagersaldo: ");
                                    product.UnitsInStock = int.Parse(Console.ReadLine());
                                    break;
                                case "7":
                                    Console.Clear();
                                    Helpers.DisplayMenu();
                                    break;
                                default:

                                    Console.WriteLine("Ogiltigt val. Försök igen.");
                                    break;
                            }



                            db.SaveChanges();
                            Console.WriteLine("Ändringarna har sparats i databasen.");
                        }
                    }
                }

                if (subchoice == "3")
                {

                    Console.WriteLine("Ange produkt-ID: ");
                    int productId = int.Parse(Console.ReadLine());


                    db.Product.Remove(db.Product.FirstOrDefault(p => p.Id == productId));
                    db.SaveChanges();

                    Console.WriteLine("Produkten har tagits bort från databasen.");
                }
                if (subchoice == "4")
                {
                    Console.Clear();
                    AdminCustomer.CustomerChange();


                }
                if (subchoice == "5")
                {
                    
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("1. Bästsäljande produkter");
                        Console.WriteLine("2. Produkter sorterade på pris");
                        Console.WriteLine("3. Försäljning sorterat på leverantörer");
                        Console.WriteLine("4. De 10 senaste beställningarna");
                        Console.WriteLine("5. Återgå till huvudmeny");
                        string CompanyInfoChoice = Console.ReadLine();

                        switch (CompanyInfoChoice)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Bäst säljande produkter: ");
                                Console.WriteLine("-----------------------");
                                var bestSellingProducts = db.Orderdetail
                                    .GroupBy(od => od.Product)
                                    .OrderByDescending(group => group.Sum(od => od.Quantity))
                                    .Select(group => new
                                    {
                                        Product = group.Key,
                                        TotalQuantitySold = group.Sum(od => od.Quantity)
                                    })
                                    .Take(10)
                                    .ToList();

                                foreach (var item in bestSellingProducts)
                                {
                                    Console.WriteLine("Namn: " + item.Product.Name + " Pris: " + item.Product.Price + "kr");
                                    Console.WriteLine("Antal sålda: " + item.TotalQuantitySold);
                                    Console.WriteLine();
                                }
                                break;
                            case "2":
                                Console.Clear();
                                Console.WriteLine("Produkter sorterade på pris: ");
                                Console.WriteLine("---------------------------");
                                var productsSortedByPriceAsc = db.Product
                                    .OrderBy(p => p.Price)
                                    .ToList();
                                foreach (var product in productsSortedByPriceAsc)
                                {
                                    Console.WriteLine("Produktnamn: " + product.Name + " Pris: " + product.Price + "kr");
                                }
                                break;


                            case "3":
                                Console.Clear();
                                Console.WriteLine("Försäljning sorterat på leverantörer: ");
                                Console.WriteLine("------------------------------------");
                                var salesBySupplier = db.Orderdetail
                                     .GroupBy(od => od.Product.Supplier)
                                     .OrderByDescending(group => group.Sum(od => od.Quantity * od.Price))
                                     .Select(group => new { Supplier = group.Key, TotalSales = group.Sum(od => od.Quantity * od.Price) })
                                     .ToList();

                                foreach (var sales in salesBySupplier)
                                {
                                    Console.WriteLine($"{sales.Supplier.CompanyName}  {sales.TotalSales:C2}");
                                }
                                break;
                            case "4":
                                Console.Clear();
                                Console.WriteLine("De 10 senaste beställningarna: ");
                                Console.WriteLine("-----------------------------");

                                var latestOrders = db.Order
                                    .OrderByDescending(o => o.OrderDate).Include(o => o.Orderdetails)
                                    .Take(10)
                                    .Select(order => new
                                    {
                                        OrderId = order.Id,
                                        OrderDate = order.OrderDate,
                                        CustomerName = order.Customer != null ? order.Customer.Name : "Beställningen har ingen kund.",
                                        TotalAmount = order.CalculateTotalAmount()
                                    })
                                    .ToList();

                                foreach (var order in latestOrders)
                                {
                                    Console.WriteLine($"Order-ID: {order.OrderId}");
                                    Console.WriteLine($"Datum: {order.OrderDate}");
                                    Console.WriteLine($"Kund: {order.CustomerName}");
                                    Console.WriteLine($"Totalsumma: {order.TotalAmount} kr");
                                    Console.WriteLine("----------------");

                                }

                                break;

                                case "5":
                                Console.Clear();
                                AddNewProductMenu();
                                break;


                        }


                        break;



                    }
                }
                 if (subchoice == "6")
                {
                    Console.Clear();
                   
                }




            }
        }
    }
}

