namespace WebMaze.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SinglePlayers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SinglePlayers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mazename = c.String(),
                        mazeRows = c.Int(nullable: false),
                        mazeCols = c.Int(nullable: false),
                        mazeString = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
