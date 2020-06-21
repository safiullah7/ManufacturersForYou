using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            // context.Categories.RemoveRange(context.Categories);
            // context.Companies.RemoveRange(context.Companies);
            // context.SaveChanges();

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        Id = "b",
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        Id = "c",
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            // System.Diagnostics.Debugger.Launch();
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Id = new Guid("2f4790dd-62de-44d5-ab6a-d0bd201d6217"),
                        Name = "Automobiles"
                    },
                    new Category
                    {
                        Id = new Guid("5c61f53d-8cc6-48a2-a045-de7995073839"),
                        Name = "Laptops"
                    },
                    new Category
                    {
                        Id = new Guid("dc17f3b0-a038-4fcd-a000-5e4c153dc5e4"),
                        Name = "Mobile Phones"
                    }
                };
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();

                if (!context.Manufacturers.Any())
                {
                    var manufacturers = new List<Manufacturer>
                    {
                        new Manufacturer
                        {
                            Name = "Al-Khaba",
                            City = "Gujranwala",
                            // CategoryId1 = "2f4790dd-62de-44d5-ab6a-d0bd201d6217"
                        },
                        new Manufacturer
                        {
                            Name = "Pak Laptops",
                            City = "Lahore",
                            // CategoryId1 = "5c61f53d-8cc6-48a2-a045-de7995073839"
                        },
                        new Manufacturer
                        {
                            Name = "A-Z Mobiles",
                            City = "Islamabad",
                            // CategoryId1 = "dc17f3b0-a038-4fcd-a000-5e4c153dc5e4"
                        },
                    };
                    await context.Manufacturers.AddRangeAsync(manufacturers);
                    await context.SaveChangesAsync();
                }
            }
            // System.Diagnostics.Debugger.Launch();
            if (!context.Products.Any())
            {
                var manufacturers1 = await context.Manufacturers.ToListAsync();
                var userBob = await context.Users.SingleOrDefaultAsync(x => x.UserName == "bob");
                var userTom = await context.Users.SingleOrDefaultAsync(x => x.UserName == "tom");
                foreach (var manufacturer in manufacturers1)
                {
                    if (manufacturer.Name == "Al-Khaba")
                    {
                        var products = new List<Product>
                        {
                            new Product
                            {
                                Name = "Suzuki Spacia",
                                Description = "Imported car",
                                Price = 1500000m,
                                Discount = 0,
                                ImageUrl = "https://picture1.goo-net.com/110/1101423/J/1101423A30181229W00101.jpg",
                                AppUser = userBob,
                                Manufacturer = manufacturer
                            },
                            new Product
                            {
                                Name = "Suzuki Wagor R",
                                Description = "Local car",
                                Price = 1300000m,
                                Discount = 0,
                                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d8/Maruti_Suzuki_-_WagonR_LXi_%28front%29.JPG",
                                AppUser = userTom,
                                Manufacturer = manufacturer
                            }
                        };
                        await context.Products.AddRangeAsync(products);
                        await context.SaveChangesAsync();
                    }
                    if (manufacturer.Name == "Pak Laptops")
                    {
                        var products = new List<Product>
                        {
                            new Product
                            {
                                Name = "HP Envy",
                                Description = "Used laptop",
                                Price = 70000m,
                                Discount = 0,
                                ImageUrl = "https://www.mega.pk/items_images/t_19358.png",
                                AppUser = userBob,
                                Manufacturer = manufacturer
                            },
                            new Product
                            {
                                Name = "Macbook Pro",
                                Description = "New laptop",
                                Price = 110000,
                                Discount = 0,
                                ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp13touch-space-select-202005?wid=892&hei=820&&qlt=80&.v=1587460552755",
                                AppUser = userTom,
                                Manufacturer = manufacturer
                            }
                        };
                        await context.Products.AddRangeAsync(products);
                        await context.SaveChangesAsync();
                    }
                    if (manufacturer.Name == "A-Z Mobiles")
                    {
                        var products = new List<Product>
                        {
                            new Product
                            {
                                Name = "IPhone 11",
                                Description = "New Phone",
                                Price = 70000m,
                                Discount = 0,
                                ImageUrl = "https://cdn.vox-cdn.com/thumbor/SDDEa6E8l5Nu18-ZTkQa3n1Iev0=/1400x0/filters:no_upscale()/cdn.vox-cdn.com/uploads/chorus_asset/file/19206371/akrales_190914_3628_0262.jpg",
                                AppUser = userBob,
                                Manufacturer = manufacturer
                            },
                            new Product
                            {
                                Name = "Techno Camon 15",
                                Description = "New Phone",
                                Price = 21000,
                                Discount = 0,
                                ImageUrl = "https://www.pakmobizone.pk/wp-content/uploads/2020/03/TECNO-Camon-15-6-1024x714.png",
                                AppUser = userTom,
                                Manufacturer = manufacturer
                            }
                        };
                        await context.Products.AddRangeAsync(products);
                        await context.SaveChangesAsync();
                    }
                }
            }
            await context.SaveChangesAsync();
            
        }
    }
}