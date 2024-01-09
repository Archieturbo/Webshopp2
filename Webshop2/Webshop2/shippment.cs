using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2.Models;

namespace Webshop2
{
    internal class shippment
    {

        public static void FraktView()
        {
            using (var db = new MyDbContext())
            {


                Console.WriteLine("Fyll i leveransinformation:");

                Console.Write("Namn: ");
                string customerName = Console.ReadLine();

                Console.Write("Adress: ");
                string customerAddress = Console.ReadLine();

                Console.Write("Land: ");
                string customerCountry = Console.ReadLine();

                Console.Write("Stad: ");
                string customerCity = Console.ReadLine();

                Console.Write("Email: ");
                string customerEmail = Console.ReadLine();

                Console.Write("Födelsedatum (YYYY-MM-DD): ");
                string customerBirthday = Console.ReadLine();

                Console.Write("Tel: ");
                int customerPhone = int.Parse(Console.ReadLine());


                Console.WriteLine("Välj fraktalternativ:");
                Console.WriteLine("1. Postnord - 50 SEK");
                Console.WriteLine("2. DHL - 100 SEK");

                Console.Write("Ange ditt val: ");
                if (int.TryParse(Console.ReadLine(), out int fraktVal))
                {
                    decimal fraktPris;

                    switch (fraktVal)
                    {
                        case 1:
                            fraktPris = 50.0m;
                            break;

                        case 2:
                            fraktPris = 100.0m;
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val. Postnord har valts.");
                            fraktPris = 50.0m; // Standardfrakt som fallback
                            break;
                    }

                    var newCustomer = new Customer
                    {
                        Name = customerName,
                        Country = customerCountry,
                        City = customerCity,
                        Birthday = DateTime.Parse(customerBirthday),
                        Phone = customerPhone.ToString(),
                        Email = customerEmail
                    };

                    db.Customer.Add(newCustomer);
                    db.SaveChanges();

                    var shoppingCart = Shoppingcart.shoppingCart; // Hämta varukorgen

                    var newOrder = new Order
                    {
                        OrderDate = DateTime.Now,
                        Shipaddress = customerAddress,
                        Orderdetails = shoppingCart.Select(product => new Orderdetail
                        {
                            ProductId = product.Id,
                            Quantity = product.UnitsInStock > 0 ? 1 : 0, // Beställer 1 enhet om det finns i lager, annars 0
                            Price = Convert.ToDecimal(product.Price)
                        }).ToList()
                    };

                    db.Order.Add(newOrder);
                    db.SaveChanges();

                    Console.WriteLine($"Frakten är vald: {fraktVal}. Pris: {fraktPris}");
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Postnord har valts.");
                }
            }
        }
    }
}


