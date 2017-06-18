namespace WebMaze.Migrations
{
    using System.Data.Entity.Migrations;
    using WebMaze.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.WebMazeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.WebMazeContext context)
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
            context.Users.AddOrUpdate(
                u => u.Username,
                new User { Username = "Noam", Email = "simon@gmail.com",  Password = "1234353" },
                new User { Username = "David", Email = "dd3@gmail.com", Password = "1452555" },
                new User { Username = "Moshe", Email = "ms@gmail.com", Password = "344444" }
            );
        }
    }
}
