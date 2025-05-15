using System;
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
        }
    }
}
