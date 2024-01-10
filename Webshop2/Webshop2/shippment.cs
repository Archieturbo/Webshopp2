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
        public static Customer GetCustomerInfo()
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



           return  new Customer
            {
                Name = customerName,
                Country = customerCountry,
                Adress = customerAddress,
                City = customerCity,
                Birthday = DateTime.Parse(customerBirthday),
                Phone = customerPhone.ToString(),
                Email = customerEmail
            };
        }

        public static decimal SelectShippingMethod()
        {
            Console.WriteLine("välj leverans metod:");
            Console.WriteLine("1. Postnord - 50 SEK");
            Console.WriteLine("2. DHL - 100 SEK");

            Console.Write("Enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int shippingChoice))
            {
                switch (shippingChoice)
                {
                    case 1:
                        return 50.0m;

                    case 2:
                        return 100.0m;

                    default:
                        Console.WriteLine("Invalid choice. Postnord selected.");
                        return 50.0m;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Postnord selected.");
                return 50.0m;
            }
        }

        public static void PlaceOrder(Customer customer, decimal shippingPrice)
        {
            using (var db = new MyDbContext())
            {
                db.Customer.Add(customer);
                db.SaveChanges();

                var shoppingCart = Shoppingcart.shoppingCart;

                var newOrder = new Order
                {
                    CustomerId = customer.Id,
                    OrderDate = DateTime.Now,
                    Shipaddress = customer.Adress,
                   

                    Orderdetails = shoppingCart.Select(product => new Orderdetail
                    {
                        ProductId = product.Id,
                        Quantity = product.UnitsInStock,
                        Price = Convert.ToDecimal(product.Price)
                    }).ToList()
                };

                db.Order.Add(newOrder);
                db.SaveChanges();

                Console.WriteLine($"vald frakt: {shippingPrice} SEK");
            }
        }
    }
}


