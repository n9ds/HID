namespace HID_PDF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManytoMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Songs", "Library_Id", "dbo.Libraries");
            DropIndex("dbo.Songs", new[] { "Library_Id" });
            CreateTable(
                "dbo.SongsLibraries",
                c => new
                    {
                        LibraryId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LibraryId, t.SongId })
                .ForeignKey("dbo.Libraries", t => t.LibraryId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.LibraryId)
                .Index(t => t.SongId);
            
            DropColumn("dbo.Songs", "Library_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Songs", "Library_Id", c => c.Int());
            DropForeignKey("dbo.SongsLibraries", "SongId", "dbo.Songs");
            DropForeignKey("dbo.SongsLibraries", "LibraryId", "dbo.Libraries");
            DropIndex("dbo.SongsLibraries", new[] { "SongId" });
            DropIndex("dbo.SongsLibraries", new[] { "LibraryId" });
            DropTable("dbo.SongsLibraries");
            CreateIndex("dbo.Songs", "Library_Id");
            AddForeignKey("dbo.Songs", "Library_Id", "dbo.Libraries", "Id");
        }
    }
}
