namespace SalesBlitz.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lead",
                c => new
                    {
                        LeadId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        Origin = c.String(),
                        Status = c.String(),
                        BlitzID = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.LeadId)
                .ForeignKey("dbo.Blitz", t => t.BlitzID, cascadeDelete: true)
                .Index(t => t.BlitzID);
            
            CreateTable(
                "dbo.RepsAtBlitz",
                c => new
                    {
                        RepsId = c.Int(nullable: false, identity: true),
                        RepName = c.String(),
                        RepId = c.Int(nullable: false),
                        BlitzId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepsId)
                .ForeignKey("dbo.Blitz", t => t.BlitzId, cascadeDelete: true)
                .ForeignKey("dbo.Rep", t => t.RepId, cascadeDelete: true)
                .Index(t => t.RepId)
                .Index(t => t.BlitzId);
            
            CreateTable(
                "dbo.Rep",
                c => new
                    {
                        RepId = c.Int(nullable: false, identity: true),
                        RepName = c.String(nullable: false),
                        Position = c.String(),
                        HomeArea = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.RepId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RepsAtBlitz", "RepId", "dbo.Rep");
            DropForeignKey("dbo.RepsAtBlitz", "BlitzId", "dbo.Blitz");
            DropForeignKey("dbo.Lead", "BlitzID", "dbo.Blitz");
            DropIndex("dbo.RepsAtBlitz", new[] { "BlitzId" });
            DropIndex("dbo.RepsAtBlitz", new[] { "RepId" });
            DropIndex("dbo.Lead", new[] { "BlitzID" });
            DropTable("dbo.Rep");
            DropTable("dbo.RepsAtBlitz");
            DropTable("dbo.Lead");
        }
    }
}
