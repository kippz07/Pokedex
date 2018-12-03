namespace Pokedex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoveIds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PokedexEntries", "Move1Id", c => c.Int());
            AddColumn("dbo.PokedexEntries", "Move2Id", c => c.Int());
            AddColumn("dbo.PokedexEntries", "Move3Id", c => c.Int());
            AddColumn("dbo.PokedexEntries", "Move4Id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PokedexEntries", "Move4Id");
            DropColumn("dbo.PokedexEntries", "Move3Id");
            DropColumn("dbo.PokedexEntries", "Move2Id");
            DropColumn("dbo.PokedexEntries", "Move1Id");
        }
    }
}
