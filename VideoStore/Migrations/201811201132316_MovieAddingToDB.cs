namespace VideoStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieAddingToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        GanreId = c.Int(nullable: false),
                        DateReleased = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ganres", t => t.GanreId, cascadeDelete: true)
                .Index(t => t.GanreId);
            
            CreateTable(
                "dbo.Ganres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GanreId", "dbo.Ganres");
            DropIndex("dbo.Movies", new[] { "GanreId" });
            DropTable("dbo.Ganres");
            DropTable("dbo.Movies");
        }
    }
}
