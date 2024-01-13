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



            return new Customer
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

        public static Delivery SelectShippingMethod()
        {
            Console.WriteLine("välj leverans metod:");
            Console.WriteLine("1. Postnord - 50 SEK");
            Console.WriteLine("2. DHL - 100 SEK");

            Console.Write("Ange ditt val: ");
            using (var db = new MyDbContext())
            {


                if (int.TryParse(Console.ReadLine(), out int shippingChoice))
                {
                    switch (shippingChoice)
                    {
                        case 1:
                            var Delivery1 = (from c in db.Delivery where c.Id == 1 select c).SingleOrDefault();
                            return Delivery1;

                        case 2:
                            var Delivery2 = (from c in db.Delivery where c.Id == 2 select c).SingleOrDefault();
                            return Delivery2;

                        default:
                            Console.WriteLine("Ogiltligt val. Postnord vald.");
                            var Delivery3 = (from c in db.Delivery where c.Id == 1 select c).SingleOrDefault();
                            return Delivery3;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltligt val. Postnord vald.");
                    var Delivery4 = (from c in db.Delivery where c.Id == 1 select c).SingleOrDefault();
                    return Delivery4;
                }
            }
        }
        public static void PlaceOrder(Customer customer, double? shippingPrice, Delivery delivery)
        {
            using (var db = new MyDbContext())
            {
                db.Customer.Add(customer);
                db.SaveChanges();

                var shoppingCart = Shoppingcart.shoppingCart;


                var newOrder = new Order
                {
                    DeliveryId = delivery.Id,
                    CustomerId = customer.Id,
                    OrderDate = DateTime.Now,
                    Shipaddress = customer.Adress,


                    Orderdetails = shoppingCart.Select(product => new Orderdetail
                    {
                        DeliveryID = delivery.Id,
                        ProductId = product.Id,
                        Quantity = 1,
                        Price = Convert.ToDecimal(product.Price)
                    }).ToList()
                };

                db.Order.Add(newOrder);
                db.SaveChanges();

                decimal totalAmount = Shoppingcart.CalculateTotalPrice() + (decimal)shippingPrice; // Lägg till frakten till det totala beloppet

                Console.WriteLine($"Totalpriset är: {totalAmount}");
                Console.WriteLine($"Frakten är vald: {shippingPrice} SEK");
            }
        }
    }
}


