namespace WebMaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Losses", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Wins", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "DefaultRows");
            DropColumn("dbo.Users", "DefaultCols");
            DropColumn("dbo.Users", "DefaultAlgo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DefaultAlgo", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "DefaultCols", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "DefaultRows", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Wins");
            DropColumn("dbo.Users", "Losses");
        }
    }
}
