using BugTracker.Models.Enums;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("bugtrackerDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return  new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BugTracker.Models.Issue> Issues { get; set; }
        public System.Data.Entity.DbSet<BugTracker.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<BugTracker.Models.ProjectViewModel> ProjectViewModels { get; set; }

        public System.Data.Entity.DbSet<BugTracker.Models.ProjectCreateModel> ProjectCreateModels { get; set; }
    }

    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Customer { get; set; }

        public int? Manager { get; set; }

        public virtual List<Issue> Issues { get; set; }

        public Project()
        {
            Issues = new List<Issue>();
        }

    }

    public class Issue
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IssueStatuses Status { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? ProjectId { get; set; }

        public Project Project { get; set; }

    }

    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync
                                    (UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this,
                                    DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public virtual List<Issue> Issues { get; set; }

        public User()
        {
            Issues = new List<Issue>();
        }

    }
}