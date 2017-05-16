using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    

    public class ApplicationDbContext : IdentityDbContext<User>
    {


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
     
            return  new ApplicationDbContext();
        }

      

    }
}