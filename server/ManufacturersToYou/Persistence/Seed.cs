using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            // context.MeterDevices.RemoveRange(context.MeterDevices);
            // context.Companies.RemoveRange(context.Companies);
            // context.SaveChanges();
            if (!context.Products.Any())
            {
                var companies = new List<Product>
                {
                    new Product
                    {
                        Name = "IPhone 11",
                        Description = "Brand new iPhone 11",
                        Category = "Phones",
                        Price = 150.7M,
                        OldPrice = 160.5M,
                        ImageUrl = "some url"
                    },
                    new Product
                    {
                        Name = "IPhone 11 Pro",
                        Description = "Brand new iPhone 11 Pro",
                        Category = "Phones",
                        Price = 170.7M,
                        OldPrice = 180.5M,
                        ImageUrl = "some url"
                    },
                    new Product
                    {
                        Name = "IPhone X",
                        Description = "Brand new iPhone X",
                        Category = "Phones",
                        Price = 130.7M,
                        OldPrice = 140.5M,
                        ImageUrl = "some url"
                    },
                    new Product
                    {
                        Name = "IPhone 8",
                        Description = "Brand new iPhone 8",
                        Category = "Phones",
                        Price = 110.7M,
                        OldPrice = 110.5M,
                        ImageUrl = "some url"
                    }
                };
                context.Products.AddRange(companies);
                // context.SaveChanges();
                context.SaveChanges();
            }
        }
    }
}