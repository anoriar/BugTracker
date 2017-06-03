using BugTracker.Models.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class AppDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<User>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем роли
            var adminRole = new IdentityRole { Name = "admin" };

            roleManager.Create(adminRole);
            foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
            {
                roleManager.Create(new IdentityRole { Name = role.ToString() });
            }
            // добавляем роли в бд
          

            // создаем пользователей
            var admin = new User { Email = "admin@mail.ru", UserName = "admin" };
            string password = "admin1234";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, adminRole.Name);
               
            }
            base.Seed(context);
        }
    }
}