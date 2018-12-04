namespace Pokedex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PokedexEntries", "Type1", c => c.String());
            AddColumn("dbo.PokedexEntries", "Type2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PokedexEntries", "Type2");
            DropColumn("dbo.PokedexEntries", "Type1");
        }
    }
}
