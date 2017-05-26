using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class UsersList
    {
        public static List<User> getUsersByRole(string roleStr)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<string> usersNames = new List<string>();
            List<User> users = new List<User>();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var role = roleManager.FindByName(roleStr).Users.FirstOrDefault();
            if (role != null)
            {
                users = db.Users.Where(u => u.Roles.Select(r => r.RoleId).Contains(role.RoleId)).ToList();
                foreach (User user in users)
                {
                    usersNames.Add(user.UserName);
                }
            }
            return users;
        }
    }


}