using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2.Models;

namespace Webshop2
{
    internal class AdminCustomer
    {
        public static void CustomerChange()
        {
            using (var db = new MyDbContext())
            {
                while (true)
                {


                    DisplayAllCustomers(db);

                    Console.WriteLine("Ange kundens ID för att ändra uppgifter: ");
                    int customerId = int.Parse(Console.ReadLine());

                    // Hämta kunden från databasen
                    Customer currentCustomer = db.Customer.FirstOrDefault(c => c.Id == customerId);

                    if (currentCustomer == null)
                    {
                        Console.WriteLine("Kunden med det angivna ID:t hittades inte.");
                        return;
                    }

                    DisplayCustomerChangeMenu(currentCustomer, db);
                    break;
                }
            }
        }

        private static void DisplayAllCustomers(MyDbContext db)
        {
            var customers = db.Customer.ToList();

            if (customers.Any())
            {
                Console.WriteLine("Lista över kunder:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"KundID: {customer.Id}, Namn: {customer.Name}, Email: {customer.Email}");
                }
            }
            else
            {
                Console.WriteLine("Det finns inga kunder i databasen.");
            }
        }

        public static void DisplayCustomerChangeMenu(Customer currentCustomer, MyDbContext db)
        {
            Console.WriteLine("1. Ändra Namn");
            Console.WriteLine("2. Ändra Adress");
            Console.WriteLine("3. Ändra Land");
            Console.WriteLine("4. Ändra Stad");
            Console.WriteLine("5. Ändra Födelsedatum");
            Console.WriteLine("6. Ändra Telefonnummer");
            Console.WriteLine("7. Ändra Email");
            Console.WriteLine("Ange ditt val: ");
            string adminChoice = Console.ReadLine();

            switch (adminChoice)
            {
                
                case "1":
                    Console.WriteLine("Ange nytt namn: ");
                    currentCustomer.Name = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Ange ny adress: ");
                    currentCustomer.Adress = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Ange nytt land: ");
                    currentCustomer.Country = Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Ange ny stad: ");
                    currentCustomer.City = Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Ange nytt födelsedatum (YYYY-MM-DD): ");
                    currentCustomer.Birthday = DateTime.Parse(Console.ReadLine());
                    break;
                case "6":
                    Console.WriteLine("Ange nytt telefonnummer: ");
                    currentCustomer.Phone = Console.ReadLine();
                    break;
                case "7":
                    Console.WriteLine("Ange ny email: ");
                    currentCustomer.Email = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }

            // Spara ändringarna i databasen
            db.SaveChanges();

            Console.WriteLine("Kunduppgifter har uppdaterats.");
        }

     
    public static void DisplayOrderHistory(int customerId, MyDbContext db)
        {
            // Hämta beställningshistoriken från databasen för den aktuella kunden
            var orderHistory = db.Order
                .Where(o => o.CustomerId == customerId)
                .ToList();

            if (orderHistory.Count > 0)
            {
                Console.WriteLine("Beställningshistorik:");

                foreach (var order in orderHistory)
                {
                    Console.WriteLine($"OrderID: {order.Id}, Datum: {order.OrderDate}, Totalt pris: {order.CalculateTotalAmount()}");
                }
            }
            else
            {
                Console.WriteLine("Ingen beställningshistorik hittad för kunden.");
            }
        }
    }
}


