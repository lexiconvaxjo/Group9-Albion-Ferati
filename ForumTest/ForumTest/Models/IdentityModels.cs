using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ForumTest.Models {

	public class ApplicationUser : IdentityUser {
		public DateTime CreationDate { get; set; }
		public Boolean Approved { get; set; }
		public DateTime LastActivityDate { get; set; }
		public DateTime LastLockoutDate { get; set; }
		public DateTime LastLoginDate { get; set; }

        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager userManager)
        {
            throw new NotImplementedException();
        }
    }

	public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
		public ApplicationDbContext()
			: base("DefaultConnection") {
		}
	}
}