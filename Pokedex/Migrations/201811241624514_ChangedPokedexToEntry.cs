namespace Pokedex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPokedexToEntry : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pokedexes", newName: "Entries");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Entries", newName: "Pokedexes");
        }
    }
}
