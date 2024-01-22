using Microsoft.EntityFrameworkCore;
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
                    Console.WriteLine("1: Historik för en kund.");
                    Console.WriteLine("2: Ändra uppgifter");
                    Console.WriteLine("3: Återgå till Huvudmeny");
                    var choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            DisplayAllCustomers(db);
                            DisplayOrderHistory();


                            break;
                        case 2:
                            Console.Clear();
                            DisplayAllCustomers(db);

                            Console.Write("Ange kundens ID för att ändra uppgifter: ");
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
                        case 3:
                            
                             
                            break;
                    }
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
                    Console.WriteLine($"KundID: {customer.Id} \n Namn: {customer.Name} \n Email: {customer.Email}\n Address: {customer.Adress}\n" +
                        $" Land: {customer.Country}\n Stad: {customer.City}\n Födelsedatum: {customer.Birthday}\n Tel: {customer.Phone} \n");
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
            Console.WriteLine("8: Återgå till adminsidan");
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
                    Console.Write("Ange nytt land: ");
                    currentCustomer.Country = Console.ReadLine();
                    break;
                case "4":
                    Console.Write("Ange ny stad: ");
                    currentCustomer.City = Console.ReadLine();
                    break;
                case "5":
                    Console.Write("Ange nytt födelsedatum (YYYY-MM-DD): ");
                    currentCustomer.Birthday = DateTime.Parse(Console.ReadLine());
                    break;
                case "6":
                    Console.Write("Ange nytt telefonnummer: ");
                    currentCustomer.Phone = Console.ReadLine();
                    break;
                case "7":
                    Console.Write("Ange ny email: ");
                    currentCustomer.Email = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    DisplayCustomerChangeMenu(currentCustomer, db);
                    break;
                case "8":
                    Console.Clear();
                    CustomerChange();
                    break;
            }
            db.SaveChanges();

            Console.WriteLine("Kunduppgifter har uppdaterats.");
        }
        public static void DisplayOrderHistory()
        {
            using (var db = new MyDbContext())
            {
                Console.Write("Välj Id för att se historik: ");
                if(int.TryParse(Console.ReadLine(), out var customerId))
                {
                  
                    var customer = db.Customer.FirstOrDefault(x => x.Id == customerId);

                    if(customer != null)
                    {
                        var orderhistory = db.Order.Include(o  => o.Orderdetails)
                            .Where(o => o.CustomerId == customerId)
                            .ToList();

                        Console.WriteLine($"Beställningshistorik för: {customer.Name} med Id: {customer.Id} \n");

                        foreach(var order in orderhistory)
                        {
                            Console.Write($"OrderID: {order.Id}, Datum: {order.OrderDate}, Totalt pris:");

                            foreach(var orderdetails in order.Orderdetails)
                            {
                                
                                Console.Write($"{orderdetails.Price:c2}");
                                
                               
                            }
                         
                        }
                       
                        
                    }
                }
            }

        }
    }
}


