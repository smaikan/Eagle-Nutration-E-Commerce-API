﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;
using Data.Data;


namespace Data
{
    public static class DbInitializer
    {
        public static async Task SeedUsers(AppDbContext context)
        {
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
                        UserAddress = "zordres",
                        UserPhone = "032323233223"
                    },
                    new User
                    {
                       
                        UserName = "User",
                        UserEmail = "user@example.com",
                        UserPassword = "user123",
                        Role = "User",
                        UserAddress = "aedres",
                        UserPhone = "05555555555"
                    }
                };

                context.User.AddRange(users);
                context.SaveChanges();
            }
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
<<<<<<< HEAD
                        CategoryName = "Performans"
=======
                        CategoryName = "Enerji"
>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
                    },
                    new Category
                    {

                        CategoryId = 5,
                        CategoryName = "Giyim"
<<<<<<< HEAD
                    },new Category
                    {

                        CategoryId = 6,
                        CategoryName = "Aksesuar & Malzeme"
                    }


=======
                    }

>>>>>>> c8e2fb5ef3fe48ae811ce257204a35ad1610721d
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

        }
    }
}
