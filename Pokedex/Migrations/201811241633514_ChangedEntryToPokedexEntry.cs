namespace Pokedex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEntryToPokedexEntry : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Entries", newName: "PokedexEntries");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PokedexEntries", newName: "Entries");
        }
    }
}
