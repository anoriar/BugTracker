using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BugTracker.Models
{
    public class UsersList
    {
        public static IEnumerable<SelectListItem> getUsersByRole(string roleStr)
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
            return GetSelectListItems(users);
        }

        private static IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<User> elements)
        {
            var selectList = new List<SelectListItem>();

            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id,
                    Text = element.UserName
                });
            }

            return selectList;
        }
    }


}