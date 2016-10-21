namespace MyForum.Migrations.ApplicationDbContext
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyForum.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\ApplicationDbContext";
            ContextKey = "MyForum.Models.ApplicationDbContext";
        }

        protected override void Seed(MyForum.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //string[] roleNames = { "Admin", "Member" };
            //IdentityResult roleResult;
            //foreach (var roleName in roleNames)
            //{
            //    if (!RoleManager.RoleExists(roleName))
            //    {
            //        roleResult = RoleManager.Create(new IdentityRole(roleName));
            //    }
            //}

            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //UserManager.AddToRole("0581aa88-7f4b-4c45-bffd-7268fce5b8f2", "Admin");
        }
    }
}
