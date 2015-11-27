namespace lab2_7_asp_webapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cinema",
                c => new
                    {
                        CinemaId = c.Int(nullable: false, identity: true),
                        CinemaName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CinemaId);
            
            CreateTable(
                "dbo.Seance",
                c => new
                    {
                        SeanceId = c.Int(nullable: false, identity: true),
                        CinemaId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        SeanceDT = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SeanceId)
                .ForeignKey("dbo.Cinema", t => t.CinemaId, cascadeDelete: true)
                .ForeignKey("dbo.Film", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.CinemaId)
                .Index(t => t.FilmId);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        FilmName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Seance", "FilmId", "dbo.Film");
            DropForeignKey("dbo.Seance", "CinemaId", "dbo.Cinema");
            DropIndex("dbo.Seance", new[] { "FilmId" });
            DropIndex("dbo.Seance", new[] { "CinemaId" });
            DropTable("dbo.Film");
            DropTable("dbo.Seance");
            DropTable("dbo.Cinema");
        }
    }
}
