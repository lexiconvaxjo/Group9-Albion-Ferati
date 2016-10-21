namespace MyForum.Migrations.ForumDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyForum.Models.ForumDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\ForumDbContext";
        }

        protected override void Seed(MyForum.Models.ForumDbContext context)
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

            context.Sections.AddOrUpdate(new Models.Section { Id = "1", Title = "Match", Description = "Here you can talk about matches" });
            context.Sections.AddOrUpdate(new Models.Section { Id = "2", Title = "Players", Description = "Feel free to talk about your favorite player" });
            context.Sections.AddOrUpdate(new Models.Section { Id = "3", Title = "History", Description = "When became you a barca fan and why?" });

            context.Posts.AddOrUpdate(new Models.Post { Id = "1", SectionId = "1", Topic = "Last match was awesome", Content = "I watched last match and was glad that we won. What did you think?", Username = "Albion", Published=true });
            context.Posts.AddOrUpdate(new Models.Post { Id = "2", SectionId = "2", Topic = "Messi is my favorite player", Content = "Messi is better than CR. Who do you think is the best barcelona player of all time?", Username = "Michael", Published = true });
            context.Posts.AddOrUpdate(new Models.Post { Id = "3", SectionId = "3", Topic = "When I became barcafan", Content = "First time I saw barca playing I became a barcafan.", Username = "Hajdar", Published = true });

            context.Comments.AddOrUpdate(new Models.Comment { Id = "1", SectionId = "1", PostId = "1", Body = "Yaeh I also liked how they played but i think they could have done it better", UserName = "Bashar", Deleted=false });
            context.Comments.AddOrUpdate(new Models.Comment { Id = "2", SectionId = "2", PostId = "2", Body = "I think suarez is better", UserName = "Amir", Deleted=false });
            context.Comments.AddOrUpdate(new Models.Comment { Id = "3", SectionId = "3", PostId = "3", Body = "I agree, it was the same for me. Became a fan 10 years ago.", UserName = "Omar", Deleted = false });
            context.Comments.AddOrUpdate(new Models.Comment { Id = "4", SectionId = "1", PostId = "1", Body = "Hopefully it goes this well in the next game too.", UserName = "Tom", Deleted = false });
        }
    }
}
