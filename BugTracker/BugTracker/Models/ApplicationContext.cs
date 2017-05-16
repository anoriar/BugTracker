using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BugTracker.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("bugtrackerDB") { }
 
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public System.Data.Entity.DbSet<BugTracker.Models.Issue> Issues { get; set; }

        public System.Data.Entity.DbSet<BugTracker.Models.Project> Projects { get; set; }
      
    }
}