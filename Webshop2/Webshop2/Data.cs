using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2
{
    internal class Data
    {
        
     //            using (var db = new MyDbContext())
     //            {
     //                var ForMen = new Category { CategoryName = "Herr" };
     //                var ForWomen = new Category { CategoryName = "Dam" };
     //                var ForJunior = new Category { CategoryName = "Junior" };

     //                var supplier1 = new Supplier
     //                {
     //                    CompanyName = "Fashion Suppliers AB",
     //                    Country = "Sweden",
     //                    City = "Stockholm",
     //                    Address = "Gillerbacken 67",
     //                    Phone = "+46-7454-7890",
     //                };
     //                var supplier2 = new Supplier
     //                {
     //                    CompanyName = "Style Trends AB",
     //                    Country = "Sweden",
     //                    City = "Gothenburg",
     //                    Address = "Backa Bergögata 1",
     //                    Phone = "+46-745-354",
     //                };
     //                var supplier3 = new Supplier
     //                {
     //                    CompanyName = "Scandinavian Fashion AB",
     //                    Country = "Norway",
     //                    City = "Oslo",
     //                    Address = "Dronning Eufemias gate 15, 0194 Oslo, Norge",
     //                    Phone = "+47-714-653",
     //                };

     //                var product1 = new Product
     //                {
     //                    Name = "T-shirt",
     //                    Price = 452.78,
     //                    Color = "Vit",
     //                    UnitsInStock = 5,
     //                    Categories = new List<Category> { ForMen },
     //                    Supplier = supplier1,
     //                    Description = "En bekväm vit T-shirt för herr med klassisk design.",
     //                    CategoryId = 1
     //                };

     //                var product2 = new Product
     //                {
     //                    Name = "Nike Hoodie",
     //                    Price = 845.56,
     //                    Color = "Svart",
     //                    UnitsInStock = 15,
     //                    Categories = new List<Category> { ForMen },
     //                    Supplier = supplier3,
     //                    Description = "En svart Nike Hoodie för herr med sportig och modern design.",
     //                    CategoryId = 1
     //                };

     //                var product3 = new Product
     //                {
     //                    Name = "Jeans",
     //                    Price = 1025.89,
     //                    Color = "Blå",
     //                    UnitsInStock = 8,
     //                    Categories = new List<Category> { ForMen, ForWomen },
     //                    Supplier = supplier3,
     //                    Description = "Stiliga blå jeans med perfekt passform. Tillverkade med högkvalitativt material för optimal komfort.",
     //                    CategoryId = 2
     //                };

     //                var product4 = new Product
     //                {
     //                    Name = "Skjorta",
     //                    Price = 743.89,
     //                    Color = "Vit",
     //                    UnitsInStock = 18,
     //                    Categories = new List<Category> { ForMen },
     //                    Supplier = supplier2,
     //                    Description = "En elegant vit skjorta för herr med snygg design och hög kvalitet.",
     //                    CategoryId = 1
     //                };

     //                var product5 = new Product
     //                {
     //                    Name = "Mjukis Byxa",
     //                    Price = 804.79,
     //                    Color = "Grå",
     //                    UnitsInStock = 7,
     //                    Categories = new List<Category> { ForMen },
     //                    Supplier = supplier2,
     //                    Description = "Sköna grå mjukisbyxor för herr. Perfekta för avslappnade dagar.",
     //                    CategoryId = 1
     //                };

     //                var product6 = new Product
     //                {
     //                    Name = "Klänning",
     //                    Price = 501.79,
     //                    Color = "Röd",
     //                    UnitsInStock = 10,
     //                    Categories = new List<Category> { ForWomen },
     //                    Supplier = supplier2,
     //                    Description = "Elegant röd klänning för damer. Passar för olika tillfällen och evenemang.",
     //                    CategoryId = 2
     //                };

     //                var product7 = new Product
     //                {
     //                    Name = "Kjol",
     //                    Price = 899.74,
     //                    Color = "Svart",
     //                    UnitsInStock = 8,
     //                    Categories = new List<Category> { ForWomen },
     //                    Supplier = supplier3,
     //                    Description = "Svart kjol med modern och stilren design för damer.",
     //                    CategoryId = 2
     //                };

     //                var product8 = new Product
     //                {
     //                    Name = "Stickad tröja",
     //                    Price = 401.66,
     //                    Color = "Lila",
     //                    UnitsInStock = 9,
     //                    Categories = new List<Category> { ForWomen },
     //                    Supplier = supplier3,
     //                    Description = "Lila stickad tröja för damer. Håller dig varm och bekväm.",
     //                    CategoryId = 2
     //                };

     //                var product9 = new Product
     //                {
     //                    Name = "Leggings",
     //                    Price = 456.99,
     //                    Color = "Gul",
     //                    UnitsInStock = 15,
     //                    Categories = new List<Category> { ForWomen },
     //                    Supplier = supplier1,
     //                    Description = "Gula leggings med snygg passform och hög komfort för damer.",
     //                    CategoryId = 2
     //                };

     //                var product10 = new Product
     //                {
     //                    Name = "Kappa",
     //                    Price = 1596.78,
     //                    Color = "Svart",
     //                    UnitsInStock = 10,
     //                    Categories = new List<Category> { ForWomen },
     //                    Supplier = supplier1,
     //                    Description = "Svart kappa för damer med elegant och tidlös design.",
     //                    CategoryId = 2
     //                };

     //                var product11 = new Product
     //                {
     //                    Name = "Spiderman Onepiece",
     //                    Price = 701.32,
     //                    Color = "Röd",
     //                    UnitsInStock = 8,
     //                    Categories = new List<Category> { ForJunior },
     //                    Supplier = supplier3,
     //                    Description = "Röd Spiderman Onepiece för juniors. Perfekt för lekfulla äventyr.",
     //                    CategoryId = 3
     //                };

     //                var product12 = new Product
     //                {
     //                    Name = "Overall",
     //                    Price = 369.94,
     //                    Color = "Orange",
     //                    UnitsInStock = 4,
     //                    Categories = new List<Category> { ForJunior },
     //                    Supplier = supplier2,
     //                    Description = "Orange overall för juniors. Praktisk och bekväm.",
     //                    CategoryId = 3
     //                };

     //                var product13 = new Product
     //                {
     //                    Name = "Shorts",
     //                    Price = 701.32,
     //                    Color = "Brun",
     //                    UnitsInStock = 8,
     //                    Categories = new List<Category> { ForJunior, ForMen },
     //                    Supplier = supplier3,
     //                    Description = "Bruna shorts för juniors och herrar. Perfekta för varma dagar.",
     //                    CategoryId = 3
     //                };

     //                var product14 = new Product
     //                {
     //                    Name = "Väst",
     //                    Price = 843.00,
     //                    Color = "Turkos",
     //                    UnitsInStock = 6,
     //                    Categories = new List<Category> { ForJunior },
     //                    Supplier = supplier2,
     //                    Description = "Turkos väst för juniors. Stilfull och trendig.",
     //                    CategoryId = 3
     //                };

     //                var product15 = new Product
     //                {
     //                    Name = "Overshirt",
     //                    Price = 276.84,
     //                    Color = "Beige",
     //                    UnitsInStock = 13,
     //                    Categories = new List<Category> { ForJunior },
     //                    Supplier = supplier1,
     //                    Description = "Beige overshirt för juniors. Perfekt för avslappnade stunder.",
     //                    CategoryId = 3
     //                };

     //                db.AddRange(product1, product2, product3, product4, product5, product6, product7, product8, product9, product10,
     //                             product11, product12, product13, product14, product15);
     //                db.SaveChanges();

     //                var delivery = new Delivery
     //                {
     //                    Name = "Postnord",
     //                    Price = 50,
     //                };
     //                var delivery2 = new Delivery
     //                {
     //                    Name = "DHL",
     //                    Price = 100,
     //                };
     //                db.AddRange(delivery, delivery2);
     //                db.SaveChanges();
     //            }



     //        }

     //    }
     //}

    }
}
