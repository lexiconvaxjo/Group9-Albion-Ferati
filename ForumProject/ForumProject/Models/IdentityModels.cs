using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace ForumProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Adding some new properties to my user table

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //The team of the user
        public Team Team { get; set; }

        //List of threads which user started
        public List<Thread> UserThreads { get; set; }

        //List of replies user wrote on threads
        public List<Reply> Replies { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Reply> Replies { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Changing the name of AspNetUsers Table to "Users" and changing the Id column name
            modelBuilder.Entity<ApplicationUser>().ToTable("Users").Property(x => x.Id).HasColumnName("UserID");
            
        }

        public System.Data.Entity.DbSet<ForumProject.Models.ViewModels.CreateSectionViewModel> CreateSectionViewModels { get; set; }
    }
}