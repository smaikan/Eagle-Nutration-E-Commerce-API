using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Model;
using Data.Data;


namespace Data
{
    public static class DbInitializer
    {
        public static async Task SeedUsers(AppDbContext context)
        {

             if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {

                        CategoryId = 1,
                        CategoryName = "Protein"
                    },
                    new Category
                    {

                        CategoryId = 2,
                        CategoryName = "Hacim"
                    },
                    new Category
                    {

                        CategoryId = 3,
                        CategoryName = "Zayıflama"
                    },
                    new Category
                    {

                        CategoryId = 4,
                        CategoryName = "Performans"

                    },
                    new Category
                    {

                        CategoryId = 5,
                        CategoryName = "Giyim"

                    },new Category
                    {

                        CategoryId = 6,
                        CategoryName = "Aksesuar & Malzeme"
                    }


                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            // if (!context.Products.Any())
            // {
            //     var path = Path.Combine(AppContext.BaseDirectory, "products.json");
            //     var json = File.ReadAllText(path);
            //     var products = JsonSerializer.Deserialize<List<Product>>(json);
            //     context.Products.AddRange(products);
            //     context.SaveChanges();
            // }

            if (!context.User.Any())
            {
                var users = new List<User>
                {
                    new User
                    {

                        UserName = "Admin",
                        UserEmail = "admin@example.com",
                        UserPassword = "admin123",
                        Role = "Admin",
                        UserAddress = new Address
                    {
                        Province = "Zordres",
                        District = "",
                        Neighbor = "",
                        Addressc = ""
                    },
                        UserPhone = "032323233223"
                    },
                    new User
                    {

                        UserName = "User",
                        UserEmail = "user@example.com",
                        UserPassword = "user123",
                        Role = "User",
                    UserAddress = new Address
                    {
                        Province = "Zordres",
                        District = "",
                        Neighbor = "",
                        Addressc = ""
                    },                        UserPhone = "05555555555"
                    }
                };

                context.User.AddRange(users);
                context.SaveChanges();
            }
           

        }
    }
}
