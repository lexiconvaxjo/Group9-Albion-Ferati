using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityTest.Models
{
    public class AppContext : DbContext
    {

        public AppContext() : base("Session")
        {
            this.Database.CreateIfNotExists();
        }
        public DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<IdentityTest.Models.LoginViewModel> LoginViewModels { get; set; }
    }
}