using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cshop.Data;
using Cshop.Models;
using Microsoft.AspNetCore.Identity;
using Bogus;

namespace Cshop
{
    public static class SeedData
    {
        public const string AdministratorRole = "Administrator";
        public const string ShopOwnerRole = "ShopOwner";
        public const string CustomerRole = "Customer";

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            //            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            //           {
            //                if (!context.Categories.Any())
            //                    context.Categories.Add(new Category { Name="Category Abc"});
            //                    context.SaveChanges();
            //            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            await EnsureRolesAsync(roleManager, AdministratorRole);
            await EnsureRolesAsync(roleManager, ShopOwnerRole);
            await EnsureRolesAsync(roleManager, CustomerRole);
            await EnsureTestAdminAsync(userManager, "admin", "admin@admin.com", "11111111", AdministratorRole);
            await EnsureTestAdminAsync(userManager, "Abduladmin", "Abduladmin@admin.com", "11111111", AdministratorRole);
            await EnsureTestAdminAsync(userManager, "Anitaadmin", "Anitaadmin@admin.com", "11111111", AdministratorRole);
            await EnsureTestAdminAsync(userManager, "shopowner", "shopowner@shopowner.com", "11111111", ShopOwnerRole);
            await EnsureTestAdminAsync(userManager, "warehouseshopowner", "warehouseshopowner@shopowner.com", "11111111", ShopOwnerRole);
            await EnsureTestAdminAsync(userManager, "countdownshopowner", "countdownshopowner@shopowner.com", "11111111", ShopOwnerRole);
            await EnsureTestAdminAsync(userManager, "paknsaveshopowner", "paknsaveshopowner@shopowner.com", "11111111", ShopOwnerRole);
            await EnsureTestAdminAsync(userManager, "newworldshopowner", "newworldshopowner@shopowner.com", "11111111", ShopOwnerRole);
            await EnsureTestAdminAsync(userManager, "user", "user@shop.com", "11111111", CustomerRole);
            await EnsureTestAdminAsync(userManager, "Danuser", "Danuser@shop.com", "11111111", CustomerRole);
            await EnsureTestAdminAsync(userManager, "Clarissauser", "Clarissauser@shop.com", "11111111", CustomerRole);
            await EnsureTestAdminAsync(userManager, "Jugaluser", "Jugaluser@shop.com", "11111111", CustomerRole);
            await EnsureTestAdminAsync(userManager, "Salukuser", "Salukuser@shop.com", "11111111", CustomerRole);






            using (var context = new DatabaseContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseContext>>()))
            {

                if (!context.Categories.Any())

                    context.Categories.Add(new Category { Name = "Category Abc" });

                if (!context.Messages.Any())
                    context.Messages.AddRange(FakeMessages(100));

                context.SaveChanges();
            }



        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var alreadyExists = await roleManager.RoleExistsAsync(roleName);

            if (alreadyExists) return;

            await roleManager.CreateAsync(new IdentityRole(roleName));
        }



        private static async Task EnsureTestAdminAsync(UserManager<User> userManager, string username, string email, string pwd, string roleName)
        {
            var testUser = await userManager.Users
                .Where(x => x.UserName == username)
                .SingleOrDefaultAsync();

            if (testUser != null) return;

            testUser = new User
            {
                UserName = username,
                Email = email
            };
            await userManager.CreateAsync(testUser, pwd);
            await userManager.AddToRoleAsync(testUser, roleName);
        }


        private static List<Message> FakeMessages(int count)
        {

            var messageFaker = new Faker<Message>()
                .RuleFor(m => m.Email, f => f.Person.Email)
                .RuleFor(m => m.FullName, f => f.Person.FullName)
                .RuleFor(m => m.Body, f => f.Lorem.Paragraph())
                .RuleFor(m => m.CreatedAt, f => f.Date.Past());
            return messageFaker.Generate(count);

        }




    }
}


