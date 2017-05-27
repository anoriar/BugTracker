namespace BugTracker.Migrations
{
    using BugTracker.Models;
    using BugTracker.Models.Enums;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BugTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BugTracker.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<User>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // ������� ����
            var adminRole = new IdentityRole { Name = "admin" };

            roleManager.Create(adminRole);
            foreach (UserRoles role in Enum.GetValues(typeof(UserRoles)))
            {
                roleManager.Create(new IdentityRole { Name = role.ToString() });
            }
            // ��������� ���� � ��


            // ������� �������������
            var admin = new User { Email = "admin@mail.ru", UserName = "admin" };
            string password = "admin1234";
            var result = userManager.Create(admin, password);

            // ���� �������� ������������ ������ �������
            if (result.Succeeded)
            {
                // ��������� ��� ������������ ����
                userManager.AddToRole(admin.Id, adminRole.Name);

            }

            base.Seed(context);
        }
    }
}
