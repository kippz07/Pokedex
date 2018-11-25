namespace Pokedex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNicknameAndMoves : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PokedexEntries", "Nickname", c => c.String(maxLength: 255));
            AddColumn("dbo.PokedexEntries", "Move1", c => c.String());
            AddColumn("dbo.PokedexEntries", "Move2", c => c.String());
            AddColumn("dbo.PokedexEntries", "Move3", c => c.String());
            AddColumn("dbo.PokedexEntries", "Move4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PokedexEntries", "Move4");
            DropColumn("dbo.PokedexEntries", "Move3");
            DropColumn("dbo.PokedexEntries", "Move2");
            DropColumn("dbo.PokedexEntries", "Move1");
            DropColumn("dbo.PokedexEntries", "Nickname");
        }
    }
}
