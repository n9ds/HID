namespace HID_PDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Setlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Band = c.String(),
                        Band_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bands", t => t.Band_Id)
                .Index(t => t.Band_Id);
            
            CreateTable(
                "dbo.SetlistEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SetOrder = c.Int(nullable: false),
                        Song_Id = c.Int(),
                        Setlist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.Song_Id)
                .ForeignKey("dbo.Setlists", t => t.Setlist_Id)
                .Index(t => t.Song_Id)
                .Index(t => t.Setlist_Id);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Artist = c.String(),
                        Instrument = c.String(),
                        Key = c.String(),
                        Major = c.Boolean(nullable: false),
                        FirstNote = c.String(),
                        Filepath = c.String(),
                        Filetype = c.String(),
                        Library_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Libraries", t => t.Library_Id)
                .Index(t => t.Library_Id);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Songs", "Library_Id", "dbo.Libraries");
            DropForeignKey("dbo.Setlists", "Band_Id", "dbo.Bands");
            DropForeignKey("dbo.SetlistEntries", "Setlist_Id", "dbo.Setlists");
            DropForeignKey("dbo.SetlistEntries", "Song_Id", "dbo.Songs");
            DropIndex("dbo.Songs", new[] { "Library_Id" });
            DropIndex("dbo.SetlistEntries", new[] { "Setlist_Id" });
            DropIndex("dbo.SetlistEntries", new[] { "Song_Id" });
            DropIndex("dbo.Setlists", new[] { "Band_Id" });
            DropTable("dbo.Libraries");
            DropTable("dbo.Songs");
            DropTable("dbo.SetlistEntries");
            DropTable("dbo.Setlists");
            DropTable("dbo.Bands");
        }
    }
}
