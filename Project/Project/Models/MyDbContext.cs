using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("ProjectDatabase")
        {
            this.Database.CreateIfNotExists();
        }

        public DbSet<Person> People { get; set; }
    }
}