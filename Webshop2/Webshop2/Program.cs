using Microsoft.EntityFrameworkCore;
using Webshop2.Models;

namespace Webshop2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {

                var ForMen = new Category { CategoryName = "Herr" };
                var ForWomen = new Category { CategoryName = "Dam" };
                var ForJunior = new Category { CategoryName = "junior" };

                var supplier1 = new Supplier
                {
                    CompanyName = "Fashion Suppliers AB",
                    Country = "Sweden",
                    City = "Stockholm",
                    Address = "Gillerbacken 67",
                    Phone = "+46-7454-7890",
                };
                var supplier2 = new Supplier
                {
                    CompanyName = "Style Trends AB",
                    Country = "Sweden",
                    City = "Gothenburg",
                    Address = "Backa Bergögata 1",
                    Phone = "+46-745-354",
                };
                var supplier3 = new Supplier
                {
                    CompanyName = "Scandinavian fashio AB",
                    Country = "Norge",
                    City = "Oslo",
                    Address = "Dronning Eufemias gate 15, 0194 Oslo, Norge",
                    Phone = "+47-714-653",
                };
                var product1 = new Product
                {
                    Name = "T-shirt",
                    Price = 452.78,
                    Color = "Vit",
                    UnitsInStock = 5,
                    Categories = new List<Category> { ForMen },
                    Supplier = supplier1
                };
                var product2 = new Product
                {
                    Name = "Nike Hoodie",
                    Price = 845.56,
                    Color = "svart",
                    UnitsInStock = 15,
                    Categories = new List<Category> { ForMen },
                    Supplier = supplier3
                };
                var product3 = new Product
                {
                    Name = "Jeans",
                    Price = 1025.89,
                    Color = "Blå",
                    UnitsInStock = 8,
                    Categories = new List<Category> { ForMen, ForWomen },
                    Supplier = supplier3

                };
                var product4 = new Product
                {
                    Name = "Skjorta",
                    Price = 743.89,
                    Color = "Vit",
                    UnitsInStock = 18,
                    Categories = new List<Category> { ForMen },
                    Supplier = supplier2
                };
                var product5 = new Product
                {
                    Name = "Mjukis Byxa",
                    Price = 804.79,
                    Color = "Grå",
                    UnitsInStock = 7,
                    Categories = new List<Category> { ForMen },
                    Supplier = supplier2
                };
                var product6 = new Product
                {
                    Name = "Klänning",
                    Price = 501.79,
                    Color = "Röd",
                    UnitsInStock = 10,
                    Categories = new List<Category> { ForWomen },
                    Supplier = supplier2
                };
                var product7 = new Product
                {
                    Name = "Kjol",
                    Price = 899.74,
                    Color = "Svart",
                    UnitsInStock = 8,
                    Categories = new List<Category> { ForWomen },
                    Supplier = supplier3
                };
                var product8 = new Product
                {
                    Name = "Stickad tröja",
                    Price = 401.66,
                    Color = "Lila",
                    UnitsInStock = 9,
                    Categories = new List<Category> { ForWomen },
                    Supplier = supplier3
                };
                var product9 = new Product
                {
                    Name = "Leggings",
                    Price = 456.99,
                    Color = "Gul",
                    UnitsInStock = 15,
                    Categories = new List<Category> { ForWomen },
                    Supplier = supplier1
                };
                var product10 = new Product
                {
                    Name = "Kappa",
                    Price = 1596.78,
                    Color = "Svart",
                    UnitsInStock = 10,
                    Categories = new List<Category> { ForWomen },
                    Supplier = supplier1
                };
                var product11 = new Product
                {
                    Name = "Spiderman Onepiece",
                    Price = 701.32,
                    Color = "Röd",
                    UnitsInStock = 8,
                    Categories = new List<Category> { ForJunior },
                    Supplier = supplier3
                };
                var product12 = new Product
                {
                    Name = "overall",
                    Price = 369.94,
                    Color = "Orange",
                    UnitsInStock = 4,
                    Categories = new List<Category> { ForJunior },
                    Supplier = supplier2
                };
                var product13 = new Product
                {
                    Name = "Short",
                    Price = 701.32,
                    Color = "Brun",
                    UnitsInStock = 8,
                    Categories = new List<Category> { ForJunior, ForMen },
                    Supplier = supplier3
                };
                var product14 = new Product
                {
                    Name = "Väst",
                    Price = 843.00,
                    Color = "Turkos",
                    UnitsInStock = 6,
                    Categories = new List<Category> { ForJunior },
                    Supplier = supplier2
                };
                var product15 = new Product
                {
                    Name = "Overshirt",
                    Price = 276.84,
                    Color = "Beige",
                    UnitsInStock = 13,
                    Categories = new List<Category> { ForJunior },
                    Supplier = supplier1
                };
                db.AddRange(product1, product2, product3, product4, product5, product6, product7, product8, product9, product10,
                             product11, product12, product13, product14, product15);
                db.SaveChanges();
            }
        }


        
    }
}