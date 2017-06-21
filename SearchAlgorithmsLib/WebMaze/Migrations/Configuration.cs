namespace WebMaze.Migrations
{
    using System.Data.Entity.Migrations;
    using WebMaze.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebMazeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebMazeContext context)
        {
            context.Users.AddOrUpdate(
              u => u.Username,
              new User { Username = "Noam", Password = "123123", Email = "simo@mm", Losses = 1, Wins = 13 },
              new User { Username = "BBB", Password = "BBBrt", Email = "23@GMAIL.com", Losses = 3, Wins = 3 },
              new User { Username = "222", Password = "12ddd12", Email = "123nnn@gm.co.il", Losses = 0, Wins = 0 }
            );

        }
    }
}
