namespace WebMaze.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebMaze.Models.WebMazeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebMaze.Models.WebMazeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.Users.AddOrUpdate(
              p => p.Username,
              new User {Id=1, Username = "Andrew Peters",Password="2",Email="d"
              },
              new User { Id = 2, Username = "Brice Lambson" ,Password = "csc", Email = "sd" },
              new User {Id=3 ,Username = "Rowan Miller", Password = "casdsc", Email = "wed" }
            );

        }
    }
}
