namespace Mastermind.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        NumberOfPlayers = c.Int(nullable: false),
                        Sequence = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Guess",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Guid(nullable: false),
                        PlayerId = c.Guid(nullable: false),
                        Sequence = c.String(nullable: false, maxLength: 15),
                        NearCount = c.Int(nullable: false),
                        ExactCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .Index(t => new { t.GameId, t.PlayerId }, name: "idx_gId_pId");
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Winner = c.Boolean(nullable: false),
                        GameId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Game", t => t.GameId)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guess", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.Player", "GameId", "dbo.Game");
            DropForeignKey("dbo.Guess", "GameId", "dbo.Game");
            DropIndex("dbo.Player", new[] { "GameId" });
            DropIndex("dbo.Guess", "idx_gId_pId");
            DropTable("dbo.Player");
            DropTable("dbo.Guess");
            DropTable("dbo.Game");
        }
    }
}
