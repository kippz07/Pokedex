namespace Pokedex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMoveToTypeStat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PokedexEntries", "Move1Id");
            CreateIndex("dbo.PokedexEntries", "Move2Id");
            CreateIndex("dbo.PokedexEntries", "Move3Id");
            CreateIndex("dbo.PokedexEntries", "Move4Id");
            AddForeignKey("dbo.PokedexEntries", "Move1Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.PokedexEntries", "Move2Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.PokedexEntries", "Move3Id", "dbo.Stats", "Id");
            AddForeignKey("dbo.PokedexEntries", "Move4Id", "dbo.Stats", "Id");
            DropColumn("dbo.PokedexEntries", "Move1");
            DropColumn("dbo.PokedexEntries", "Move2");
            DropColumn("dbo.PokedexEntries", "Move3");
            DropColumn("dbo.PokedexEntries", "Move4");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PokedexEntries", "Move4", c => c.String());
            AddColumn("dbo.PokedexEntries", "Move3", c => c.String());
            AddColumn("dbo.PokedexEntries", "Move2", c => c.String());
            AddColumn("dbo.PokedexEntries", "Move1", c => c.String());
            DropForeignKey("dbo.PokedexEntries", "Move4Id", "dbo.Stats");
            DropForeignKey("dbo.PokedexEntries", "Move3Id", "dbo.Stats");
            DropForeignKey("dbo.PokedexEntries", "Move2Id", "dbo.Stats");
            DropForeignKey("dbo.PokedexEntries", "Move1Id", "dbo.Stats");
            DropIndex("dbo.PokedexEntries", new[] { "Move4Id" });
            DropIndex("dbo.PokedexEntries", new[] { "Move3Id" });
            DropIndex("dbo.PokedexEntries", new[] { "Move2Id" });
            DropIndex("dbo.PokedexEntries", new[] { "Move1Id" });
            DropTable("dbo.Stats");
        }
    }
}
