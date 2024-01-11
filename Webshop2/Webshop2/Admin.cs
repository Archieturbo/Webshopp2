﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2.Models;

namespace Webshop2
{  //Lägg till savechanges nånstans! 
    internal class Admin
    {
        public static void AddNewProductMenu()
        {
            using (var db = new MyDbContext())
            {

                Console.WriteLine("1. Lägg till ny produkt");
                Console.WriteLine("2. Ändra produkt");
                Console.WriteLine("3. Ta bort produkt");
                Console.WriteLine("4. Tillbaka till huvudmenyn");
                Console.Write("Ange ditt val: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Lägg till namn på produkten: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Lägg till pris: ");
                    double price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lägg till färg: ");
                    string color = Console.ReadLine();
                    Console.WriteLine("Lägg till lagersaldo: ");
                    int unitsInStock = int.Parse(Console.ReadLine());
                    Console.WriteLine("Ange vilken kategori den tillhör (Herr: 1, Dam: 2, Junior: 3): ");
                    var categoryId = int.Parse(Console.ReadLine());
                    switch (categoryId)
                    {
                        case 1: "Herr";
                           
                            break;
                        case 2: "Dam";
                            break;
                        case 3: "Junior";
                            break;
                        default:
                            break;
                    }
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
                        CategoryId = categoryId,
                        SupplierId = supplierId,
                        Description = description,

                    };
                    db.Add(product1);
                    db.SaveChanges();

                }
                else if (choice == "2")
                {
                    // Lägg till en menypunkt för att ändra produkt
                    Console.WriteLine("Ange produkt-ID: ");
                    int productId = int.Parse(Console.ReadLine());

                    // Hämta produkten från databasen
                    Product product = db.Product.FirstOrDefault(p => p.Id == productId);

                    // Lägg till en menypunkt för att ändra varje produktattribut
                    Console.WriteLine("1. Ändra produktnamn");
                    Console.WriteLine("2. Ändra infotext");
                    Console.WriteLine("3. Ändra pris");
                    Console.WriteLine("4. Ändra produktkategori");
                    Console.WriteLine("5. Ändra leverantör");
                    Console.WriteLine("6. Ändra lagersaldo");
                    Console.WriteLine("7. Tillbaka till huvudmenyn");
                    Console.Write("Ange ditt val: ");
                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            // Ändra produktnamn
                            Console.Write("Ange nytt produktnamn: ");
                            product.Name = Console.ReadLine();
                            break;
                        case "2":
                            // Ändra infotext
                            Console.Write("Ange ny infotext: ");
                            product.Description = Console.ReadLine();
                            break;
                        case "3":
                            // Ändra pris
                            Console.Write("Ange nytt pris: ");
                            product.Price = double.Parse(Console.ReadLine());
                            break;
                        case "4":
                            // Ändra produktkategori
                            Console.Write("Ange ny produktkategori: ");
                            product.CategoryId = int.Parse(Console.ReadLine());
                            break;
                        case "5":
                            // Ändra leverantör
                            Console.Write("Ange ny leverantör: ");
                            product.SupplierId = int.Parse(Console.ReadLine());
                            break;
                        case "6":
                            // Ändra lagersaldo
                            Console.Write("Ange nytt lagersaldo: ");
                            product.UnitsInStock = int.Parse(Console.ReadLine());
                            break;
                        case "7":
                            // Gå tillbaka till huvudmenyn
                            Helpers.DisplayMenu();
                            break;
                        default:
                            // Ogiltigt val
                            Console.WriteLine("Ogiltigt val. Försök igen.");
                            break;
                    }

                    // Spara ändringarna i databasen
                    db.SaveChanges();

                    Console.WriteLine("Ändringarna har sparats i databasen.");
                }
                else if (choice == "3")
                {
                    // Lägg till en menypunkt för att ta bort produkt
                    Console.WriteLine("Ange produkt-ID: ");
                    int productId = int.Parse(Console.ReadLine());

                    // Ta bort produkten från databasen
                    db.Product.Remove(db.Product.FirstOrDefault(p => p.Id == productId));
                    db.SaveChanges();

                    Console.WriteLine("Produkten har tagits bort från databasen.");
                }
                else if (choice == "4")
                {
                    // Gå tillbaka till huvudmenyn  
                    Helpers.DisplayMenu();
                }
                else
                {
                    // Ogiltigt val





                }
            }
        }
    }
}

